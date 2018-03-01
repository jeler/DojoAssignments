const mongoose = require("mongoose")
const User = mongoose.model("User")

class QuoteController 
{

    index(req, res)
    {
        res.render("index");
    }

    create(req, res)
    {
        var user = new User({ name: req.body.name, quote: req.body.quote });
        user.save(function (err) {
            if (err) {
                console.log('something went wrong');
                console.log(err);
                res.render('index', {errors: [err]})
            } else { 
                console.log('successfully added a user!');
                res.redirect('/quotes');
            }
        });
    }
    retrieve(req, res)
    {
        User.find( {}, function(err, users)    
            {
                if(err) 
                {
                    console.log("something went wrong!");           
                }
                else 
                {
                    console.log("success");
                    console.log(users)
                    res.render("quotes", {user: users});
                }
            }).sort('-createdAt');
    }
    
}
    module.exports = new QuoteController
    {

    }