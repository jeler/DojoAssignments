using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_dashboard.Models;

namespace user_dashboard.Controllers {
    public class UserController : Controller {

        private user_dashboardContext _context;
        public UserController (user_dashboardContext context) {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        [Route ("register")]
        public IActionResult Register (UserViewModels model) {
            if (ModelState.IsValid) {
                User ReturnedValue = _context.Users.SingleOrDefault (user => user.email == model.Reg.email);
                if (ReturnedValue != null) {
                    ModelState.AddModelError (string.Empty, "This email already exists!");
                    return View ("Index");
                } else

                {
                    List<User> AllUsers = _context.Users.ToList ();
                    if (AllUsers.Count == 0) {
                        User NewUser = new User {
                        first_name = model.Reg.first_name,
                        last_name = model.Reg.last_name,
                        email = model.Reg.email,
                        password = model.Reg.password,
                        user_level = 9,
                        created_at = DateTime.Now
                        };
                        _context.Users.Add (NewUser);
                        _context.SaveChanges ();
                        HttpContext.Session.SetInt32 ("session_id", (int) NewUser.UserId);
                        return RedirectToAction ("Admin_Dashboard", "Admin");
                    } else {

                        User NewUser = new User {
                            first_name = model.Reg.first_name,
                            last_name = model.Reg.last_name,
                            email = model.Reg.email,
                            password = model.Reg.password,
                            user_level = 0,
                            created_at = DateTime.Now

                        };
                        _context.Users.Add (NewUser);
                        _context.SaveChanges ();
                        HttpContext.Session.SetInt32 ("session_id", (int) NewUser.UserId);
                        return RedirectToAction ("Dashboard");
                    }
                }
            } else

            {
                return View ("Index");
            }
        }

        [HttpPost]
        [Route ("login")]
        public IActionResult Login (UserViewModels model) {
            User ReturnedValue = _context.Users.SingleOrDefault (user => user.email == model.Log.email);
            if (ReturnedValue != null) {
                if (ReturnedValue.password == model.Log.password) {
                    if (ReturnedValue.user_level == 9) {
                        HttpContext.Session.SetInt32 ("session_id", (int) ReturnedValue.UserId);
                        return RedirectToAction ("Admin_Dashboard", "Admin");
                    } else {
                        HttpContext.Session.SetInt32 ("session_id", (int) ReturnedValue.UserId);
                        return RedirectToAction ("Dashboard");
                    }
                } else {
                    ModelState.AddModelError (string.Empty, "Password incorrect!");
                    return View ("Index");
                }
            } else {
                ModelState.AddModelError (string.Empty, "User does not exist!");
                return View ("Index");
            }
        }

        [HttpGet]
        [Route ("dashboard")]
        public IActionResult Dashboard () {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            // Get session variable
            if (Session == null) {
                ModelState.AddModelError (string.Empty, "You haven't logged in!");
                return View ("Index");
            } else {
                User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
                // Get info on user with session id
                ViewBag.user = RetrievedUser;
            }
            return View ("Dashboard");
        }

        [HttpGet]
        [Route ("users/show/{user_id}")]
        public IActionResult UserPage (int user_id) {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            User CurrentUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
            User SpecificUser = _context.Users.SingleOrDefault (u => u.UserId == user_id);
            // Get info on user with session id
            // List<Message> Messages = _context.Users.Where(u => U.UserId == Session).In
            ViewBag.logged_in_user = CurrentUser;
            ViewBag.user = SpecificUser;
            return View ("SpecificUser");
        }

        [HttpGet]
        [Route ("logout")]
        public IActionResult Logout () {
            HttpContext.Session.Clear ();
            // Find way to display error message you're not logged in!
            return RedirectToAction ("Dashboard");
        }

        [HttpPost]
        [Route ("messagepost")]
        public IActionResult Message (Message model, int user_id) {
            if (ModelState.IsValid) {
                int? Session = HttpContext.Session.GetInt32 ("session_id");
                User CurrentUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
                ViewBag.logged_in_user = CurrentUser;  
                Message NewMessage = new Message 
                {
                    message = model.message,
                    created_at = DateTime.Now,
                    UserId = (int)Session
                };
                _context.Messages.Add (NewMessage);
                _context.SaveChanges ();
                return Redirect ($"users/show/{user_id}");
            } 
            else 
            {
                return View ("SpecificUser");
            }
        }
    }
}