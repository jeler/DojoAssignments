var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));

var bodyParser = require('body-parser');

var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/message_board');

var Schema = mongoose.Schema;
var MessageSchema = new mongoose.Schema({
    name: {type: String, required: [true, "You need to enter a name!"], minlength: [4, "Name must be at least 4 characters!"]},
    text: {type: String, required: [true, "You need to enter a message!"], minlength: [2, "Message must be at least 2 characters"]},
    comments: [{type: Schema.Types.ObjectId, ref: 'Comment'}]
}, { timestamps: true });

var CommentSchema = new mongoose.Schema({
    name: {type: String, required: [true, "You need to enter a name!"], minlength: [4, "Name must be at least 4 characters!"]},    
    _message: {type: Schema.Types.ObjectId, ref: 'Message'},
    text: {type: String, required: [true, "You need to enter a comment!" ]}
}, { timestamps: true });

mongoose.model('Message', MessageSchema);
mongoose.model('Comment', CommentSchema);

var Message = mongoose.model("Message");
var Comment = mongoose.model("Comment");

mongoose.Promise = global.Promise;

app.use(bodyParser.urlencoded({ extended: true }));


app.set('views', __dirname + '/views');

app.set('view engine', 'ejs');

app.get('/', function (req, res) {
    Message.find({}).populate('comments').exec(function(err, messages) {
        console.log("This should have everything but it maybe doesn't", messages);
        if (err) {
            console.log("something went wrong!")
            res.render('index', { errors: [err] })
        }
        else {
            console.log(messages);
            res.render('index', { results: messages })
        }
    });
});

app.post('/post_message', function(req, res) {
    var message = new Message({ name: req.body.name, text: req.body.text });
    message.save(function (err)
    {
    if(err) 
    {
    // error.push(err);
    // console.log("This is line 66", err);
    // var error = err;
    // console.log("something went wrong");
    // // res.render("index", {errors: [err]})
    // Message.find({}, function (err, messages) {
    //     if (err) {
    //         console.log("something went wrong!")
    //         res.render('index', {errors: [err]})
    //     }
    //     else {
    //         console.log(error, "line 73")            
    //         res.render('index', {results: messages, errors: [error]})
    //     }
    // });        
    res.render('index', {errors: [err]})
    // can not get messages to render - find does not produce errors from original message validation
    }
    else
    {    
    res.redirect('/');
    }
});
});

app.post('/post_comment/:id', function(req, res) 
{
    Message.findOne({_id: req.params.id}, function(err, message) {
        console.log(req.params.id);
        var comment = new Comment({name: req.body.comment_name, text: req.body.comment})
        comment._message = message._id
        message.comments.push(comment); 
        console.log("this is message_id", message._id);
        comment.save(function(err) {
        message.save(function(err) {
            if(err) 
            {
                console.log("theres a problem here");
                res.render("index", {errors: [err]});
            }
            else
            {
                console.log("i got here!")
                res.redirect('/')
            }
            });
        });
    });
});

app.listen(5000, function () {
    console.log("listening on port 5000");
});