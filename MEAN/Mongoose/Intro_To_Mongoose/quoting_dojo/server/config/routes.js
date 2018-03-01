var mongoose = require("mongoose");

var User = require('./../models/quotes.js');

const path = require('path');

const quote = require('../controllers/quote')


module.exports = function(app) {
    
    // app.get('/', function (req, res, err) 
    // {
    //     res.render('index', {errors: err});
    // });

    app.get('/', function (req, res) 
    {
        quote.index(req, res);
    });
    
    // post route for adding a user
    app.post('/quotes', function (req, res) {
        quote.create(req, res);
    });
    
    app.get('/quotes', function(req, res){
        quote.retrieve(req, res);
    });
}