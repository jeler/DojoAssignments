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

        //  public IActionResult Check_Session() 
        // {
        //     int? Session = HttpContext.Session.GetInt32 ("session_id");
        //     if (Session == null) 
        //     {
        //         ModelState.AddModelError (string.Empty, "You haven't logged in!");
        //         return View ("Views/User/Index.cshtml");
        //     }
        //     else
        //     {

        //     }
        // }

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
                ViewBag.user = RetrievedUser;
                List<User> AllUsers = _context.Users.OrderBy (u => u.UserId).ToList ();
                ViewBag.AllUsers = AllUsers;
            }
            return View ("Dashboard");
        }

        [HttpGet]
        [Route ("users/show/{user_id}")]
        public IActionResult UserPage (int user_id) {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            User CurrentUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
            User SpecificUser = _context.Users.SingleOrDefault (u => u.UserId == user_id);
            ViewBag.logged_in_user = CurrentUser;
            ViewBag.user = SpecificUser;
            List<Message> ReceivedMessages = _context.Messages.Where (u => u.ReceiverId == user_id).Include (x => x.User).Include(c=>c.Comments).ThenInclude(y=>y.User).ToList ();
            ViewBag.messages = ReceivedMessages;
            // List<Comment> ReceivedComments = _context.Messages.Where(u => u.ReceiverId).Include(c=>c.Comments).ThenInclude(u => u.Users).ToList();
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
        public IActionResult Message (CommunicationViewModels model, int user_id, int specific_user_page_id) {
            int id = user_id;
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            User CurrentUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
            User SpecificUser = _context.Users.SingleOrDefault (u => u.UserId == specific_user_page_id);
            ViewBag.logged_in_user = CurrentUser;
            ViewBag.user = SpecificUser;
            List<Message> ReceivedMessages = _context.Messages.Where (u => u.ReceiverId == user_id).Include (x => x.User).ToList ();
            ViewBag.messages = ReceivedMessages;
            if (ModelState.IsValid) {
                if (specific_user_page_id == user_id) {
                    ModelState.AddModelError (string.Empty, "You can't leave a message for yourself!");
                    return View ("SpecificUser");
                } else {
                    Message NewMessage = new Message {
                        message = model.Mess.message,
                        created_at = DateTime.Now,
                        UserId = (int) Session,
                        ReceiverId = (int) specific_user_page_id
                    };
                    _context.Messages.Add (NewMessage);
                    _context.SaveChanges ();
                    return Redirect ($"users/show/{specific_user_page_id}");
                }
            } else {
                return View ("SpecificUser");
            }
        }

        [HttpPost]
        [Route ("commentprocess")]
        public IActionResult Comment (CommunicationViewModels model, int specific_user_page_id, int message_id, int user_id) 
        {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            User CurrentUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
            User SpecificUser = _context.Users.SingleOrDefault (u => u.UserId == user_id);
            ViewBag.logged_in_user = CurrentUser;
            ViewBag.user = SpecificUser;
            List<Message> ReceivedMessages = _context.Messages.Where (u => u.ReceiverId == user_id).Include (x => x.User).ToList ();
            ViewBag.messages = ReceivedMessages;
            if (ModelState.IsValid) 
            {
                
                Comment newComment = new Comment {
                    comment = model.Comm.comment,
                    UserId = (int) Session,
                    MessageId = message_id,
                    created_at = DateTime.Now

                };
                _context.Comments.Add (newComment);
                _context.SaveChanges ();
                return Redirect ($"users/show/{specific_user_page_id}");
            }
             else 
            
            {
                return View ("SpecificUser");
            }
        }


        [HttpGet]
        [Route ("users/edit")]
        public IActionResult User_Edit () {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            User CurrentUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
            ViewBag.user = CurrentUser;
            return View ("Edit_User");
        }

        [HttpPost]
        [Route ("users/edit_process_user")]
        public IActionResult User_Edit_Process (UserViewModels model) {
            if (ModelState.IsValid) {
                int? Session = HttpContext.Session.GetInt32 ("session_id");
                User CurrentUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
                ViewBag.user = CurrentUser;
                User ReturnedValue = _context.Users.SingleOrDefault (user => user.email == model.UserEdit.email);
                if (ReturnedValue == null) {
                    CurrentUser.first_name = model.UserEdit.first_name;
                    CurrentUser.last_name = model.UserEdit.last_name;
                    CurrentUser.email = model.UserEdit.email;
                    _context.SaveChanges ();
                    return RedirectToAction ("Dashboard", "User");
                } else {
                    ModelState.AddModelError (string.Empty, "This email is already taken!");
                    return View ("Edit_User");
                }
            } else {
                return View ("Edit_User");
            }
        }

        [HttpPost]
        [Route ("users/user_change_pw")]
        public IActionResult Change_PW_User (UserViewModels model) {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            if (ModelState.IsValid) {
                User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
                RetrievedUser.password = model.AdminPass.password;
                _context.SaveChanges ();
                return RedirectToAction ("Dashboard");
            } else {
                User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
                ViewBag.user = RetrievedUser;
                return View ("Edit_User");
            }
        }

        [HttpPost]
        [Route ("users/change_description")]
        public IActionResult Description (string Description_Field) {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
            RetrievedUser.description = Description_Field;
            _context.SaveChanges ();
            return RedirectToAction ("Dashboard");
        }
    }
}