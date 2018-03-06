using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bright_ideas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bright_ideas.Controllers {
    public class UserController : Controller {

        private bright_ideasContext _context;
        public UserController (bright_ideasContext context) {
            _context = context;
        }

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

                    User NewUser = new User {
                        name = model.Reg.name,
                        alias = model.Reg.alias,
                        email = model.Reg.email,
                        password = model.Reg.password,
                    };
                    _context.Users.Add (NewUser);
                    _context.SaveChanges ();
                    HttpContext.Session.SetInt32 ("session_id", (int) NewUser.UserId);
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
        [Route ("bright_ideas")]
        public IActionResult Dashboard () {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            // Get session variable
            if (Session == null) {
                ModelState.AddModelError (string.Empty, "You haven't logged in!");
                return View ("Index");
            } else {
                User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
                ViewBag.user = RetrievedUser;
                List<Idea> AllIdeas = _context.Ideas.Include (r => r.Creator).Include(l => l.Likes).ThenInclude (u => u.User).OrderByDescending(l=>l.Likes.Count).ToList();
                ViewBag.ideas = AllIdeas;
                return View ("Dashboard");
            }
        }

        [HttpPost]
        [Route ("create")]
        public IActionResult Create (Idea model) {
            if (ModelState.IsValid) {
                int? Session = HttpContext.Session.GetInt32 ("session_id");
                Idea NewIdea = new Idea {
                    idea = model.idea,
                    CreatorId = (int) Session
                };
                _context.Add (NewIdea);
                _context.SaveChanges ();
                // return Redirect ($"bright_ideas/{NewIdea.IdeaId}");
                return RedirectToAction("Dashboard", "User");

            } else {
                int? Session = HttpContext.Session.GetInt32 ("session_id");
                User RetrievedUser = _context.Users.SingleOrDefault (u => u.UserId == Session);
                ViewBag.user = RetrievedUser;
                // List<Idea> AllIdeas = _context.Ideas.Include (r => r.Likes).ThenInclude (u => u.User).ToList ();
                List<Idea> AllIdeas = _context.Ideas.Include (r => r.Creator).Include(l => l.Likes).ThenInclude (u => u.User).OrderByDescending(l=>l.Likes.Count).ToList();             
                ViewBag.ideas = AllIdeas;
                ModelState.AddModelError (string.Empty, "Idea needs to be longer than 3 characters!");
                return View ("Dashboard");
            }
        }

        [HttpGet]
        [Route ("users/{user_id}")]
        public IActionResult SpecificUser (int user_id) {
            int id = user_id;
            User ThisUser = _context.Users.Where (u => u.UserId == id).SingleOrDefault ();
            List<User> LikesPosts = _context.Users.Where (u => u.UserId == user_id).Include (i => i.Ideas).Include (l => l.Likes).ToList ();
            ViewBag.user = ThisUser;
            ViewBag.likes = LikesPosts;
            return View ("SpecificUser");

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