const mongoose = require("mongoose");

const BoardGame = mongoose.model("BoardGame");

var Schema = mongoose.Schema,
    bcrypt = require('bcrypt-as-promised'),
    mongooseAccountLocking = require("mongoose-account-locking")
    

// import model created

var UserSchema = new mongoose.Schema({
    email: {
        type: String, required: true, index: { unique: true },
        validate: {
            validator: function (value) {
                return /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/.test(value);
            },
            message: "Invalid Email Address!"
        }
    },
    first_name: { type: String, required: [true, "You need to enter a  first name!"], minlength: [2, "first_name must be longer than 2 characters!"] },
    last_name: { type: String, required: [true, "You need to enter a last name!"], minlength: [2, "last_name must be longer than 2 characters!"] },
    password: {
        type: String, required: [true, "You need to enter a password!"], minlength: [8, "Password must be longer than 8 characters"], maxlength: 32
    },
    loginAttempts: {type: Number, required: true, default: 0},
    lockUntil: {type: Number},
    boardgames: [{ type: Schema.Types.ObjectId, ref: 'BoardGame' }]
},
    { timestamps: true });

    
    UserSchema.pre('save', function (next) {
        bcrypt.hash(this.password, 10)
        .then(hashed_pw => {
            this.password = hashed_pw;
            next();
        })
        .catch(function (errors) {
            console.log(errors)
        });
    });
    
    // UserSchema.virtual('isLocked').get(function() {
    //     // check for future lockUntil timestamp
    //     return !!(this.lockUntil && this.lockUntil > Date.now());
    //     // Date.now = time in milliseconds value
    // });

mongoose.model('User', UserSchema);
// var User = mongoose.model('User')

// create model using above defined schema

// module.exports = {
//     User: User
// }

mongoose.Promise = global.Promise;
