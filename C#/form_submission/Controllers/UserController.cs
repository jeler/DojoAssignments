using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class UserController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string First_Name_Field, string Last_Name_Field, int Age_Field, string Email_Field, string Password_Field)
        {
            User NewUser = new User 
            {
                First_Name = First_Name_Field,
                Last_Name = Last_Name_Field,
                Age = Age_Field,
                Email = Email_Field,
                Password = Password_Field

            };
            if(TryValidateModel(NewUser) == false) {
                ViewBag.errors = ModelState.Values;
                return View("Errors");  
            }
            else {
                return View("Success");
            }
        }

        [HttpGet]
        [Route("errors")]
        public IActionResult Errors()
        {
            return View();
        }
    }
}
