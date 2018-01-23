using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DbConnection;
using login_registration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Identity;

namespace login_registration.Controllers {
    public class UserController : Controller {
        // GET: /Home/
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        [Route ("register")]
        public IActionResult Register (UserViewModels model) {

            // Console.WriteLine(model.Reg.First_Name);

            if (ModelState.IsValid) {
                string fname = "'" + model.Reg.First_Name + "'";
                string lname = "'" + model.Reg.Last_Name + "'";
                string email = "'" + model.Reg.Email + "'";
                string password = "'" + model.Reg.Password + "'";
                string insert = $"INSERT INTO user(first_name, last_name, email, password) VALUES ({fname}, {lname}, {email}, {password})";
                DbConnector.Execute (insert);
                return RedirectToAction ("Success");
            } else {
                return View ("Index");
            }
        }

        [HttpPost]
        [Route ("login")]
        public IActionResult Login (UserViewModels model) {
            if (ModelState.IsValid) {
                string email = model.Log.Email;
                string password = model.Log.Password;
                string e_query = $"SELECT * FROM user WHERE email = '{email}'";
                var email_query = DbConnector.Query (e_query);
                Console.WriteLine (email_query);
                // Console.WriteLine(email_query[0]);

                if (email_query.Count != 0) {
                    var user_pw = email_query[0]["password"];
                    if ((string) user_pw == password) {
                        return RedirectToAction ("Success");
                    } else {
                        ModelState.AddModelError (string.Empty, "This password is incorrect");
                        return View ("Index");
                    }
                } 
                else {
                    ModelState.AddModelError (string.Empty, "This user does not exist");
                    return View ("Index");
                }

            } 
            else {
                return View ("Index");
            }
        }

        [HttpGet]
        [Route ("success")]
        public IActionResult Success () {
            return View ();
        }
    }
}