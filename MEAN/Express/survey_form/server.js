var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({secret: 'codingdojorocks'}));

app.use(express.static(__dirname + "/static"));

var bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({extended: true}));


app.set('views', __dirname + '/views'); 

app.set('view engine', 'ejs');


app.get('/', function(req, res) {
    res.render("index");
   })
   
app.post('/result', function(req, res) {
    console.log("POST DATA", req.body);
    console.log(req.body.name);
    var result =
    {
        name: req.body.name,
        location: req.body.location,
        language: req.body.language,
        comment: req.body.comment
    }
    res.render('result', {result});
   })
   
   app.listen(8000, function() 
   {
       console.log("listening on port 8000");
   })