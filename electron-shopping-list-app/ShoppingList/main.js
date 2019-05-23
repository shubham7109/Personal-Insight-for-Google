const electron = require('electron');
const url = require('url');
const path = require('path');

const {app, BrowserWindow, Menu, ipcMain} = electron;

// SET ENV
process.env.NODE_ENV = 'production';

let mainWindow;
let addWindow;

//Listen for the app to be ready
app.on('ready',function(){
    // Create new window
    mainWindow = new BrowserWindow({
        webPreferences:{
            nodeIntegration: true
        }
    });

    //Load the HTML file 
    mainWindow.loadURL(url.format({
        pathname: path.join(__dirname, 'mainWindow.html'),
        protocol:'file:',
        slashes: true
    }));

    //Quit app when closed
    mainWindow.on('closed',function(){
        app.quit();
    });

    //Build menu from the template
    const mainMenu = Menu.buildFromTemplate(mainMenuTemplate);

    //Insert the menu
    Menu.setApplicationMenu(mainMenu)

});

// Handle create add window:
function createAddWindow(){
    // Create new window
    addWindow = new BrowserWindow({
        webPreferences:{
            nodeIntegration: true
        },
        width: 300,
        height: 200,
        title: 'Add shopping list item'
    });

    //Load the HTML file 
    addWindow .loadURL(url.format({
        pathname: path.join(__dirname, 'addWindow.html'),
        protocol:'file:',
        slashes: true
    }));

    //Garbage collection handle
    addWindow.on('close',function(){

    });
}

// Catch item being added
ipcMain.on('item:add',function(e,item){
    mainWindow.webContents.send('item:add',item);
    addWindow.close();
});


// Create menu template
const mainMenuTemplate = [
    {
        label:'File',
        submenu: [
            {
                label:'Add Item',
                click(){
                    createAddWindow();
                }
            },
            {
                label:'Clear Items',
                click(){
                    mainWindow.webContents.send('item:clear');  
                }
            },
            {
                label:'Quit',
                accelerator: process.platform == 'darwin' ? 'Command+Q' : 'Ctrl+Q',
                click(){
                    app.quit();
                }
            }
        ]
    }
];

//If mac add empty obj to menu
if(process.platform == 'darwin'){
    mainMenuTemplate.unshift({});
}

//Add dev tools if not in production
if(process.env.NODE_ENV !== 'production'){
    mainMenuTemplate.push({
        label: 'Developer Tools',
        submenu: [
            {
                label: 'Toggle DevTools',
                accelerator: process.platform == 'darwin' ? 'Command+I' : 'Ctrl+I',
                click(item, focusedWindow){
                    focusedWindow.toggleDevTools();
                }
            },
            {
                role: 'reload'
            }
        ]

    });
}