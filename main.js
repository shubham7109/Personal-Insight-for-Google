var app = require('electron').remote;
var dialog = app.dialog;
var fs = require('fs');

document.getElementById('createButton').onclick = () =>  {
    dialog.showSaveDialog( (fileName) => {
        if(fileName === undefined){
            alert("You didn't save the file");
            return;
        }

        var content = document.getElementById('content').value;

        fs.writeFile(fileName, content, (err) => {
            if(err){
                console.log(err);
            } else{
                alert("The file has been successfully saved.");
            }
        })
    });
};