using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank_accounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bank_accounts.Controllers {
    public class UserController : Controller {

        private BankAccountContext _context;

        public UserController (BankAccountContext context) {
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
                User ReturnedValue = _context.users.SingleOrDefault (user => user.email == model.Reg.email);
                // List<User> ReturnedValues = _context.users.Where(user => model.Reg.email == user.email).ToList();
                // Console.WriteLine("+++++++" + ReturnedValue.email + "++++++++");

                // Console.WriteLine("+++++++" + model.Reg.email + "++++++++++");
                if (ReturnedValue != null) {
                    ModelState.AddModelError (string.Empty, "This email already exists!");
                    return View ("Index");
                } else 
                
                {

                    User NewUser = new User {
                        first_name = model.Reg.first_name,
                        last_name = model.Reg.last_name,
                        email = model.Reg.email,
                        password = model.Reg.password,
                        balance = 0.0

                    };
                    _context.users.Add (NewUser);
                    _context.SaveChanges ();
                    User Returned = _context.users.SingleOrDefault (user => user.email == model.Reg.email);
                    // List<User> ReturnedValues = _context.users.Where(user => user.email == model.Reg.email).ToList();
                    // TempData["user_info"] = ReturnedValue.id;
                    HttpContext.Session.SetInt32 ("id_session", (int) Returned.id);
                    // return RedirectToAction ("AccountPage", "Transaction");
                    return Redirect($"/account/{Returned.id}");
                    
                }
            } else

            {
                return View ("Index");
            }
        }

        [HttpPost]
        [Route ("login")]
        public IActionResult Login (UserViewModels model) {
            User ReturnedValue = _context.users.SingleOrDefault (user => user.email == model.Log.email);
            if(ReturnedValue != null) 
            {
                if(ReturnedValue.password == model.Log.password) 
                {
                HttpContext.Session.SetInt32 ("id_session", (int) ReturnedValue.id);
                return Redirect($"account/{ReturnedValue.id}");
                }
                else {
                    ModelState.AddModelError(string.Empty, "Password incorrect!");
                    return View("Index");
                }
            }
            else {
                ModelState.AddModelError(string.Empty, "User does not exist!");
                return View ("Index");
            }   
        }
    }
}