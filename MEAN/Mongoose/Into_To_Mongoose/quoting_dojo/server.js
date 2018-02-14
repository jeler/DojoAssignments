var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));

var bodyParser = require('body-parser');

var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/quotes');

var UserSchema = new mongoose.Schema({
    name: { type: String, required: [true, "You need to enter a name!"], minlength: [2, "Name must be at least 2 characters"]
},
    quote: { type: String, required: [true, "You need to enter a quote!"], minlength: [10, "Quote must be at least 10 characters!"]}
}, {timestamps: true});

mongoose.model('User', UserSchema); // We are setting this Schema in our Models as 'User'
var User = mongoose.model('User')

mongoose.Promise = global.Promise;

app.use(bodyParser.urlencoded({ extended: true }));


app.set('views', __dirname + '/views');

app.set('view engine', 'ejs');

app.get('/', function (req, res, err) 
{
    res.render('index', {errors: err});
});

// post route for adding a user
app.post('/quotes', function (req, res) {
    // create a new User with the name and age corresponding to those from req.body
    var user = new User({ name: req.body.name, quote: req.body.quote });
    user.save(function (err) {
        if (err) {
            console.log('something went wrong');
            console.log(err);
            res.render('index', {errors: [err]})
        } else { 
            console.log('successfully added a user!');
            res.redirect('/quotes');
        }
    });
});

app.get('/quotes', function(req, res){
    User.find( {}, function(err, users)    
    {
        if(err) 
        {
            console.log("something went wrong!");           
        }
        else 
        {
            console.log("success");
            console.log(users)
            res.render("quotes", {user: users});
        }
    }).sort('-createdAt');
});

app.listen(5000, function () {
    console.log("listening on port 5000");
})