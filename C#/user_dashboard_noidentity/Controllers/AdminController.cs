using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_dashboard.Models;

namespace user_dashboard.Controllers {
    public class AdminController : Controller {

        private user_dashboardContext _context;
        public AdminController (user_dashboardContext context) {
            _context = context;
        }

        [HttpGet]
        [Route ("dashboard/admin")]
        public IActionResult Admin_Dashboard () {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            if (Session == null) {
                ModelState.AddModelError (string.Empty, "You haven't logged in!");
                return View ("Views/User/Index.cshtml");
            } else {
                User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
                if (RetrievedUser.user_level != 9) {
                    ModelState.AddModelError (string.Empty, "You are not an admin!");
                    return RedirectToAction ("Index", "User");
                } else {
                    List<User> AllUsers = _context.Users.OrderBy(u=>u.UserId).ToList ();
                    ViewBag.AllUsers = AllUsers;
                    ViewBag.user = RetrievedUser;
                    return View ("AdminDashboard");
                }
            }
        }

        [HttpGet]
        [Route ("users/edit/{user_id}")]
        public IActionResult Admin_Edit (int user_id) {
            int? Session = HttpContext.Session.GetInt32 ("session_id");                       
            User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == user_id);
            ViewBag.user = RetrievedUser;
            return View ("AdminEdit");
        }

        [HttpPost]
        [Route ("users/edit_process")]
        public IActionResult Admin_Edit_Process (UserViewModels model, int user_id) {
            int? Session = HttpContext.Session.GetInt32 ("session_id");           
            if (ModelState.IsValid) {
                User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == user_id);
                RetrievedUser.email = model.AdminEditInfo.email;
                RetrievedUser.first_name = model.AdminEditInfo.first_name;
                RetrievedUser.last_name = model.AdminEditInfo.last_name;
                RetrievedUser.user_level = model.AdminEditInfo.user_level;
                _context.SaveChanges ();
                return RedirectToAction ("Admin_Dashboard");
            } else {
                int id = user_id;
                User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == id);
                ViewBag.user = RetrievedUser;
                return View ("AdminEdit");
            }
        }

        [HttpPost]
        [Route ("users/change_password_process")]
        public IActionResult Admin_Change_Password (UserViewModels model, int user_id) 
        {
            int? Session = HttpContext.Session.GetInt32 ("session_id");          
            if(ModelState.IsValid) 
            {               
            User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == user_id);
            RetrievedUser.password = model.AdminPass.password;
            _context.SaveChanges();
            return RedirectToAction ("Admin_Dashboard");
            }
            else 
            {
            User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == user_id);
            ViewBag.user = RetrievedUser;
            return View("AdminEdit");
            }
        }
        [HttpGet]
        [Route("delete/{user_id}")]
        public IActionResult Delete_User(int user_id) 
        {
            User RetrievedUser = _context.Users.SingleOrDefault(u=>u.UserId == user_id);
            _context.Users.Remove(RetrievedUser);
            _context.SaveChanges();
            return RedirectToAction("Admin_Dashboard");
        }

        [HttpGet]
        [Route("users/new")]
        public IActionResult Admin_Add_User() 
        {
            int? Session = HttpContext.Session.GetInt32 ("session_id");                       
            User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
            ViewBag.user = RetrievedUser;
            return View("AdminNewUser");
        }

        [HttpPost]
        [Route("useres/new_user/process")]
        public IActionResult Admin_Add_User_Process(UserViewModels model) {
            if(ModelState.IsValid) 
            {
                User NewUser = new User
                {
                    first_name = model.Reg.first_name,
                    last_name = model.Reg.last_name,
                    email = model.Reg.email,
                    password = model.Reg.password,
                    user_level = 0,
                    created_at = DateTime.Now
                };
                _context.Add(NewUser);
                _context.SaveChanges();
                return RedirectToAction("Admin_Dashboard");
            }
            else
            {
                return View("AdminNewUser");
            }
        }
    }
}