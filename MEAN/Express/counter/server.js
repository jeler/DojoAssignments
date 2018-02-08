var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({secret: 'codingdojorocks'}));

app.use(function(req, res, next) {
    res.locals.user = req.session.counter;
    next();
  });


app.listen(8000, function() 
{
    console.log("listening on port 8000");
})


app.use(express.static(__dirname + "/static"));
console.log(__dirname);

// require body-parser
var bodyParser = require('body-parser');
// use it!
app.use(bodyParser.urlencoded({extended: true}));

// This sets the location where express will look for the ejs views
app.set('views', __dirname + '/views'); 
// Now lets set the view engine itself so that express knows that we are using ejs as opposed to another templating engine like jade
app.set('view engine', 'ejs');



app.get('/', function (req, res)
{
    // let counter = 0;
    // req.session.counter = counter;
    if (req.session.counter == null)
    {
        var counter = 0;
        req.session.counter = counter;
        console.log(req.session.counter);
    }
    else 
    {
        req.session.counter += 1;
        var session_counter = 
        {
            count: req.session.counter
        }
    }
    
    res.render('index', {session_counter});
    // console.log("session is" + req.session.counter);
  });

  app.get('/reset', function (req, res)
  {
    // req.session.destroy();
    // req.session == null;
    req.session.counter = 0;
    res.redirect('/');
  });
  
  app.get('/increment', function(req, res)
  {
    req.session.counter+= 1;
    res.redirect('/');
  });

