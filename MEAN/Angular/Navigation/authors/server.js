var express = require("express");

var app = express();

app.use(express.static(__dirname + '/client/dist'));

const bodyParser = require('body-parser');

var path = require("path")

var mongoose = require('mongoose');

//IF USING MONGOOSE:
mongoose.connect('mongodb://localhost/authors_db');
var AuthorSchema = new mongoose.Schema({
    name: { type: String, index: { unique: true }, minlength: [2, "Name must be at least 2 characters!"] }
}, { timestamps: true });

mongoose.model('Author', AuthorSchema);
var Author = mongoose.model('Author')

app.use(bodyParser.json());

app.get('/authors', function (req, res) {
    Author.find({}, function (err, authors) {
        if (err) {
            res.json({ message: "Error", error: err })
        }
        else {
            console.log(authors);
            res.json({ authors })
        }
    })
})

app.post('/createnewauthor', function (req, res) {
    var author = new Author
        ({
            name: req.body.name
        })
    author.save(function (err) {
        if (err) {
            console.log(err)
            res.json(err)
        }
        else {
            return res.json({ message: "author successfully added!" })
        }
    })
})

app.post('/updateuser', function (req, res) 
{
    console.log("this is req.body", req.body)
    Author.findOne({ _id: req.body._id }, function (err, author) 
    {
        if (err) 
        {
            console.log(err)
        }
        else 
        {
            console.log("this is author", author)
            console.log(req.body.name)
            author.name = req.body.name;
            author.save(function(err)
            {
                if(err)
                {
                    console.log("this is errors", err)
                    return res.json(err)
                }
                else{
                    return res.json({message: "author updated!"})
                }
            })
        }
    })
})


app.get('/authors/:id', function (req, res) {
    console.log("this is req.body.id", req.params.id)
    Author.findOne({ _id: req.params.id }, function (err, author) {
        if (err) {
            console.log(err);
            res.json(err)
        }
        else {
            console.log(author)
            res.json({ author })
        }
    })
})

app.get('/delete/:id', function (req, res) {
    console.log("this is id in server", req.params.id);
    Author.findByIdAndRemove(req.params.id, function (err, author) {
        if (err) {
            console.log(err)
            res.json(err)
        }
        else {
            res.json({ message: "author deleted!" });
        }
    })
})


app.all("*", (req, res, next) => {
    res.sendFile(path.resolve("./client/dist/index.html"))
})

app.listen(8000, function () {
    console.log("listening on port 8000");
})