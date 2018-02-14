var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));

var bodyParser = require('body-parser');

var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/animals');

var MongooseSchema = new mongoose.Schema({
    name:
        {
            type: String, required: [true, "You need to enter a name!"], minlength: [2, "Name must be at least 2 characters"]
        },
    home_town: { type: String, required: [true, "You need to enter a quote!"], minlength: [2, "Hometown must be at least 2 characters!"] },

    age: { type: Number, required: [true, "You need to enter an age!"], min: [1, "Number must be positive!"] }

}, { timestamps: true });

mongoose.model('Mongoose', MongooseSchema); // We are setting this Schema in our Models as 'Mongoose'
var Mongoose = mongoose.model('Mongoose')

mongoose.Promise = global.Promise;

app.use(bodyParser.urlencoded({ extended: true }));


app.set('views', __dirname + '/views');

app.set('view engine', 'ejs');

app.get('/', function (req, res, err) {
    Mongoose.find({}, function (err, mongooses) {
        if (err) {
            console.log("something went wrong!")
            res.render('index', { errors: [err] })
        }
        else {
            res.render('index', { results: mongooses })
        }
    });
});

app.get('/mongooses/new', function (req, res, err) {
    if (err) {
        console.log("something went wrong!")
        res.render('create_mongoose', { errors: err })
    }
    else {
        res.render('create_mongoose', { errors: [err] })
    }
});


app.post('/mongooses', function (req, res) {
    // create a new Mongoose with the name and age corresponding to those from req.body
    var mongoose = new Mongoose({ name: req.body.name, home_town: req.body.home_town, age: req.body.age });
    mongoose.save(function (err) {
        if (err) {
            console.log('something went wrong');
            res.render('create_mongoose', { errors: [err] })
        } else {
            console.log('successfully added a Mongoose!');
            res.redirect('/');
        }
    });
});

app.get('/mongooses/:id', function (req, res) {
    Mongoose.findOne({ _id: req.params.id }, function (err, mongoose) {
        if (err) {
            console.log("something went wrong!");
            res.render('mongoose_page');
        }
        else{
            res.render('mongoose_page', {results: mongoose});
        }
    });
});
app.get('/mongooses/destroy/:id', function(req, res) {
    Mongoose.remove({_id: req.params.id}, function(err) {
        if(err) {
            console.log("something went wrong!")
            res.redirect('/');
        }
        else 
        {
            res.redirect('/');
        }
    });
});

app.get('/mongooses/edit/:id', function(req, res){
    res.render('edit_mongoose', {data: req.params.id});
});

app.post('/mongooses/:id', function(req, res){
    Mongoose.findOne({_id: req.params.id}, function(err, mongoose) {
        if(err)
        {
            console.log("something is not quite right...")
            res.redirect('/');
        }
        else
        {
            console.log("successfully updated!")
            mongoose.name = req.body.name || mongoose.name;
            mongoose.home_town = req.body.home_town || mongoose.home_town;
            mongoose.age = req.body.age || mongoose.age;
            mongoose.save();
            res.redirect('/');     
        }
        });
   });

app.listen(5000, function () {
    console.log("listening on port 5000");
})