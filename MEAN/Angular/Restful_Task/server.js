var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));

app.use(express.static( __dirname + '/PracticeAngular/dist' ));

const bodyParser = require('body-parser');

var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/restful_task');

var TaskSchema = new mongoose.Schema({
    title: {type: String, default: ""},
    description: {type: String, default: ""},
    completed: {type: Boolean, default: false}
}, {timestamps: true });

mongoose.model('Task', TaskSchema);
var Task = mongoose.model('Task')

mongoose.Promise = global.Promise;

app.use(bodyParser.json());

app.get('/tasks', function (req, res) {
    Task.find({}, function (err, tasks) {
        if (err) {
            console.log("returned err", err)
            res.json({ message: "Error", error: err })
        }
        else {
            res.json({ tasks })
        }
    });
});

app.post('/tasks', function (req, res) {
    console.log(req.body);
    var task = new Task({ title: req.body.title, description: req.body.description, completed: req.body.completed })
    task.save(function (err) {
        if (err) {
            res.json({ error: err })
        }
        else {
            res.json({ data: task })
        }
    });
});
// works with the following get route
app.get('/tasks/:id', function (req, res) {
    Task.findById(req.params.id, function(err, task){
        if(err){
            res.json({error: err})
        }
        else {
            res.json({ data: task })
        }
    });
});

app.put('/tasks/:id/', function(req, res){
    Task.findById(req.params.id, function(err, task){
        if(err){
            res.json({error: err})
        }
        else{
            task.title = req.body.title || task.title;
            task.description = req.body.description || task.description;
            task.completed = req.body.completed || task.completed;
            task.save(function(err){
                if(err)
                {
                    res.json({error: err})
                }
                else{
                    res.json({message: 'Task updated!'})
                }
            })
        }
    })
})
// could not get delete to work
app.delete('/tasks/:id', function (req, res) {
    Task.remove({id: req.params.id }, function (err) {
        console.log("got here!")
        if (err) {
            console.log("in here?")
            res.json({ error: err });
        }
        else {
            console.log("Delete successful!")
            res.json({message: 'Task deleted!'})
        }
    })
})


app.listen(5000, function () {
    console.log("listening on port 5000");
})

