var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));

const bodyParser = require('body-parser');

var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/1955_api');

var UserSchema = new mongoose.Schema({
    name: String
})
mongoose.model('User', UserSchema); // We are setting this Schema in our Models as 'User'
var User = mongoose.model('User')

mongoose.Promise = global.Promise;

app.use(bodyParser.json());

app.get('/', function (req, res) {
    User.find({}, function (err, users) {
        if (err) {
            console.log("returned err", err)
            res.json({ message: "Error", error: err })
        }
        else {
            res.json({ users })
        }
    });
});

app.get('/new/:name', function (req, res) {
    var user = new User({ name: req.params.name })
    user.save(function (err) {
        if (err) {
            res.json({ error: err })
        }
        else {
            res.json({ data: user })
        }
    });
});

app.get('/remove/:name', function (req, res) {
    User.remove({ name: req.params.name }, function (err) {
        if (err) {
            res.json({ error: err });
        }
        else {
            res.redirect('/')
        }
    })
})

app.get('/:name', function (req, res) {
    User.findOne({ name: req.params.name }, function (err, user) {
        if (err) {
            res.json({ errors: err })
        }
        else {
            res.json({user})
        }
    })
})

app.listen(5000, function () {
    console.log("listening on port 5000");
})

