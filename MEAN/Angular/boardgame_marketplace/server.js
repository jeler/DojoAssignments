var express = require("express"),
    app = express(),
    session = require('express-session'),
    bodyParser = require('body-parser'),
    path = require('path');
    mongoose = require('mongoose')    
    
app.use(session({ secret: 'codingdojorocks' }));

app.use(bodyParser.json())

bcrypt = require('bcrypt-as-promised')
    
require('./server/config/mongoose.js')
    
require('./server/config/routes.js')(app)

app.use(express.static(path.join(__dirname, '/client/dist')));

app.all("*", (req, res, next) => {
    res.sendFile(path.resolve("./client/dist/index.html"))
})

app.listen(1337, function () {
    console.log("listening on port 1337");
})
