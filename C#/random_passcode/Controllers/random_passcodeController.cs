using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers {
    public class random_passcodeController : Controller {
        [HttpGet]
        [Route ("Index")]
        public IActionResult Index () {
            int? CountVariable = HttpContext.Session.GetInt32 ("count");
            TempData["count"] = HttpContext.Session.GetInt32 ("count");
            // ViewBag.count = TempData["count"]; 
            // int count = 0; 

            if (HttpContext.Session.GetInt32 ("count") == null) {
                HttpContext.Session.SetInt32 ("count", 1);
            } else {
                CountVariable += 1;
                HttpContext.Session.SetInt32 ("count", (int) CountVariable);
            }
            // string character = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string[] letters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string randomword = "";
            Random rand = new Random ();
            for (int i = 0; i < 15; i++) {
                int random = rand.Next (0, letters.Length);
                randomword += (letters[random]);
            }
            ViewBag.word = randomword;
            return View ();
        }

        [HttpGet]
        [Route ("Reset")]
        public IActionResult Reset () {
            // Will redirect to the "OtherMethod" method
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index");
        }
    }
}