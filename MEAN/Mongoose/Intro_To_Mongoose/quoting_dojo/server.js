var express = require("express"),
    app = express(),
    session = require('express-session'),
    bodyParser = require('body-parser')
    
require('./server/config/mongoose.js')

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));


// var mongoose = require('mongoose');

// mongoose.connect('mongodb://localhost/quotes');

// var UserSchema = new mongoose.Schema({
//     name: { type: String, required: [true, "You need to enter a name!"], minlength: [2, "Name must be at least 2 characters"]
// },
//     quote: { type: String, required: [true, "You need to enter a quote!"], minlength: [10, "Quote must be at least 10 characters!"]}
// }, {timestamps: true});

// mongoose.model('User', UserSchema); // We are setting this Schema in our Models as 'User'
// var User = mongoose.model('User')

// mongoose.Promise = global.Promise;

app.use(bodyParser.urlencoded({ extended: true }));

app.set('views', __dirname + '/views');

app.set('view engine', 'ejs');

require('./server/config/routes.js')(app)

app.listen(5000, function () {
    console.log("listening on port 5000");
})