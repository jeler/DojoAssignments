const mongoose = require("mongoose")
const User = mongoose.model("User")

class UserController {
    createnewuser(req, res) {
        User.find({ email: req.body.email }, function (err, user) {
            console.log(user)
            if (user.length != 0) {
                console.log("user exists")
                res.json({ err: "User already exists!" })
            }
            else {

                var user = new User
                    ({
                        email: req.body.email,
                        first_name: req.body.first_name,
                        last_name: req.body.last_name,
                        password: req.body.password,
                        birthday: req.body.birthday
                    })
                user.save(function (err) {
                    if (err) {
                        res.json(err);
                    }
                    else {
                        req.session.user_id = user.id;
                        var session_user = req.session.user_id
                        console.log(session_user, "this is session user!")
                        console.log(req.session.user_id)
                        res.json({ message: "Successfully added user!" });
                    }
                })
            }
        })
    };

    loginuser(req, res) {
        User.find({ email: req.body.email }, function (err, user)
        // find user in db
        {
            console.log(user, "in conroller!")
            if (user.length == 0)
            // check if user exists
            {
                res.json({ err: "User does not exist!" })
            }
            else {
                bcrypt.compare(req.body.password, user[0].password)
                    .then(same => {
                        res.json(user);
                    })
                    .catch(function (err) {
                        console.log(err);
                        console.log("got here in catch!")
                        res.json({ pw_error: "Incorrect password!" })
                    })
            }
        })
    }

    logout(req, res) {
        req.session.destroy();
    }

    checkSessionId(req, res) {
        console.log(session_user);
        if (session_user == null) {
            session_user = false
            res.json({ user: session_user })
        }
        else {
            res.json({ user: session_user })
        }
    }
}
module.exports = new UserController
{

}