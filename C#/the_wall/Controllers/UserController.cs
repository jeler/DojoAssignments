using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using the_wall.Models;

namespace the_wall.Controllers {
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
                string email_reg_2 = model.Reg.Email;
                Console.WriteLine("+++++++" + email_reg_2 + "++++++++++++");
                string e_query = $"SELECT * FROM users WHERE email = '{email_reg_2}'";
                var email_query = DbConnector.Query(e_query);
                if (email_query.Count != 0) {
                    ModelState.AddModelError (string.Empty, "This user already exists!");
                    return View ("Index");
                }
                else {
                string fname = "'" + model.Reg.First_Name + "'";
                string lname = "'" + model.Reg.Last_Name + "'";
                string email_reg = "'" + model.Reg.Email + "'";
                string password = "'" + model.Reg.Password + "'";
                string insert = $"INSERT INTO users(first_name, last_name, email, password) VALUES ({fname}, {lname}, {email_reg}, {password})";
                string email_reg_3 = model.Reg.Email;
                DbConnector.Execute (insert);
                // var email_query_session = $"SELECT * FROM users WHERE email = '{email_reg_2}'";
                // var email_query_2 = DbConnector.Query(email_query_session);
                // var id = email_query_session[0]["id"];
                // Console.WriteLine(email_query_2);

                
                return RedirectToAction("Success");
                }
            } else {
                return View("Index");
            }
        }

        [HttpPost]
        [Route ("login")]
        public IActionResult Login (UserViewModels model) {
            if (ModelState.IsValid) {
                string email = model.Log.Email;
                string password = model.Log.Password;
                string e_query = $"SELECT * FROM users WHERE email = '{email}'";
                var email_query = DbConnector.Query (e_query);
                Console.WriteLine (email_query);
                // Console.WriteLine(email_query[0]);

                if (email_query.Count != 0) {
                    var user_pw = email_query[0]["password"];
                    if ((string) user_pw == password) {
                        var id = email_query[0]["id"];
                        var name = email_query[0]["first_name"];
                        HttpContext.Session.SetInt32("id_session", (int)id);
                        // Console.WriteLine("+++++++" + session_id + "++++++++++++");
                        TempData["id"] = HttpContext.Session.GetInt32("id_session");
                        // TempData["name"] = name;
                        return RedirectToAction ("Success");
                    } else {
                        ModelState.AddModelError (string.Empty, "This password is incorrect");
                        return View ("Index");
                    }
                } else {
                    ModelState.AddModelError (string.Empty, "This user does not exist");
                    return View ("Index");
                }

            } else {
                return View ("Index");
            }
        }

        [HttpGet]
        [Route ("success")]
        public IActionResult Success () {
            int? SessionSearch = HttpContext.Session.GetInt32 ("id_session");
            if (HttpContext.Session.GetInt32 ("id_session") == null) {
                TempData["errors"] = "You need to login"; 
                return RedirectToAction("Index");
                // need to display you're not logged in message!
            }
            else 
            {            
            TempData["id"] = HttpContext.Session.GetInt32("id_session");
            string user_info = $"SELECT * FROM users WHERE id = '{TempData["id"]}'";
            ViewBag.user_info = DbConnector.Query(user_info);
            string join_message_query = $"SELECT CONCAT(first_name, ' ',  last_name) as 'name', message, messages.created_at as 'DATE', messages.id from users JOIN messages ON messages.users_id = users.id ORDER BY messages.created_at DESC";
            ViewBag.join_message_query = DbConnector.Query(join_message_query);
            string join_comment_query = $"SELECT CONCAT(users.first_name, ' ', users.last_name) as 'name', comments.comment, comments.created_at as 'DATE', comments.messages_id, messages.id FROM comments JOIN users ON comments.users_id = users.id JOIN messages ON messages.id = comments.messages_id ORDER BY comments.created_at DESC";
            ViewBag.join_comment_query = DbConnector.Query(join_comment_query);
            return View ("Success");
            }
        }

        [HttpPost]
        [Route ("messageprocess")]
        public IActionResult Message_Process(string Message_Field, int user_id) {
            string message = Message_Field;
            if(message ==  null) {
                TempData["message_errors"] = "You need to add a message!";
                return RedirectToAction("Success");
            }
            else {
                int user_id_message = user_id;
                string insert_2 = $"INSERT INTO messages(users_id, message) VALUES ('{user_id_message}', '{message}')";
                DbConnector.Execute(insert_2);
                TempData["id"] = HttpContext.Session.GetInt32("id_session");
                string user_info = $"SELECT * FROM users WHERE id = '{TempData["id"]}'";
                ViewBag.user_info = DbConnector.Query(user_info);
                string join_message_query = $"SELECT CONCAT(first_name, ' ',  last_name) as 'name', message, messages.created_at as 'DATE', messages.id from users JOIN messages ON messages.users_id = users.id ORDER BY messages.created_at DESC";
                ViewBag.join_message_query = DbConnector.Query(join_message_query);
                string join_comment_query = $"SELECT CONCAT(users.first_name, ' ', users.last_name) as 'name', comments.comment, comments.created_at as 'DATE', comments.messages_id, messages.id FROM comments JOIN users ON comments.users_id = users.id JOIN messages ON messages.id = comments.messages_id ORDER BY comments.created_at DESC";
                ViewBag.join_comment_query = DbConnector.Query(join_comment_query);
                return RedirectToAction("Success");            
            }
        }

        [HttpPost]
        [Route("commentprocess")]
        public IActionResult Comment_Process(string Comment_Field, int message_id, int user_id_comment) {
            string comment = Comment_Field;
            if(comment == null) {
                TempData["comment_errors"] = "Comment can not be blank!";
                return RedirectToAction("Success");
            }
            else {
                int message_id_message = message_id; 
                int users_id_comment = user_id_comment;
                string insert_comment = $"INSERT INTO comments(comment, users_id, messages_id) VALUES ('{comment}', '{users_id_comment}', '{message_id_message}')";
                DbConnector.Execute(insert_comment);
                TempData["id"] = HttpContext.Session.GetInt32("id_session");
                string user_info = $"SELECT * FROM users WHERE id = '{TempData["id"]}'";
                ViewBag.user_info = DbConnector.Query(user_info);
                string join_message_query = $"SELECT CONCAT(first_name, ' ',  last_name) as 'name', message, messages.created_at as 'DATE', messages.id from users JOIN messages ON messages.users_id = users.id ORDER BY messages.created_at DESC";
                ViewBag.join_message_query = DbConnector.Query(join_message_query);
                string join_comment_query = $"SELECT CONCAT(users.first_name, ' ', users.last_name) as 'name', comments.comment, comments.created_at as 'DATE', comments.messages_id, messages.id FROM comments JOIN users ON comments.users_id = users.id JOIN messages ON messages.id = comments.messages_id ORDER BY comments.created_at DESC";
                ViewBag.join_comment_query = DbConnector.Query(join_comment_query);
                return RedirectToAction("Success");
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear ();
            return RedirectToAction("Index");

        }
    }
}
