using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wedding_planner.Models;

namespace wedding_planner.Controllers {
    public class UserController : Controller {
        private wedding_plannerContext _context;

        public UserController (wedding_plannerContext context) {
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
                User ReturnedValue = _context.Users.SingleOrDefault(user => user.email == model.Reg.email);
                if (ReturnedValue != null) {
                    ModelState.AddModelError (string.Empty, "This email already exists!");
                    return View ("Index");
                }
                
                else

                {

                    User NewUser = new User {
                        first_name = model.Reg.first_name,
                        last_name = model.Reg.last_name,
                        email = model.Reg.email,
                        password = model.Reg.password,
                    };
                    _context.Users.Add (NewUser);
                    _context.SaveChanges ();
                    // User Returned = _context.Users.SingleOrDefault (user => user.email == model.Reg.email);
                    // List<User> ReturnedValues = _context.users.Where(user => user.email == model.Reg.email).ToList();
                    // TempData["user_info"] = ReturnedValue.id;
                    HttpContext.Session.SetInt32 ("session_id", (int) NewUser.UserId);
                    // return RedirectToAction ("AccountPage", "Transaction");
                    return RedirectToAction ("Dashboard");

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
                    HttpContext.Session.SetInt32 ("session_id", (int) ReturnedValue.UserId);
                    return RedirectToAction ("Dashboard");
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
        [Route ("Dashboard")]
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
                List<Wedding> ReturnedWeddings = _context.Weddings.Include(u=>u.RSVPS).ToList();
                List<RSVP> ReturnedRSVPs = _context.RSVPS.Where(r => r.UserId == Session).ToList();
                // Returned all weddings and RSVPs
                ViewBag.weddings = ReturnedWeddings;
                ViewBag.RSVPs = ReturnedRSVPs;

            }
            return View ("Dashboard");
        }

        [HttpGet]
        [Route ("logout")]
        public IActionResult Logout () {
            HttpContext.Session.Clear ();
            // Find way to display error message you're not logged in!
            return RedirectToAction ("Dashboard");
        }
    }
}