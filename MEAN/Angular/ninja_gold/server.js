var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static( __dirname + '/AngularApp/dist' ));

var bodyParser = require('body-parser');

var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/ninja_gold');

var UserSchema = new mongoose.Schema({
    name: String,
    gold: Number,
    log: Array
})
mongoose.model('User', UserSchema); // We are setting this Schema in our Models as 'User'
var User = mongoose.model('User')

mongoose.Promise = global.Promise;

app.use(bodyParser.json());

app.set('views', __dirname + '/views');

app.listen(5000, function () {
    console.log("listening on port 5000");
})

app.post(function(req, res) {

}
)
