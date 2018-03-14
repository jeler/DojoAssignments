const mongoose = require("mongoose");

// const User = mongoose.model("User")

var Schema = mongoose.Schema;

var BoardGameSchema = new mongoose.Schema({
    title: 
    {
        type: String, required: true, minlength: [2, "title must be longer than 2 characters!"] 
    },
    description: 
    {
        type: String,  required: true, minlength: [5, "description must be longer than 5 characters"]
    },
    price:
    {
        type: Number, required: true
    },
    location:
    {
        type: String, required: true
    },
    condition:
    {
        type: String, required: true
    },
    _user: {type: Schema.Types.ObjectId, ref: 'User'},
})


mongoose.model('BoardGame', BoardGameSchema);

mongoose.model("BoardGame")

mongoose.Promise = global.Promise;
