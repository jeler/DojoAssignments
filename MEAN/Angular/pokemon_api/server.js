var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));

app.use(express.static( __dirname + '/pokemon/dist' ));

const bodyParser = require('body-parser');

var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/restful_task');

mongoose.Promise = global.Promise;

app.use(bodyParser.json());

app.get('/', function(req, res) {
    res.json({data})
})

app.listen(5000, function () {
    console.log("listening on port 5000");
})
