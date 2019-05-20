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

});