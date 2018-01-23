using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace YourNamespace.Controllers {
    public class dojodachiController : Controller {
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            bool play = true;
            // HttpContext.Session.SetInt32 ("fullness", 20);   
            // HttpContext.Session.SetInt32 ("happiness", 20);
            // HttpContext.Session.SetInt32 ("meal", 3);
            // HttpContext.Session.SetInt32 ("energy", 50);
               
            if (HttpContext.Session.GetInt32 ("fullness") < 1 || HttpContext.Session.GetInt32 ("happiness") < 1) {
                play = false;
                TempData["message"] = "Your Dojodachi has died!";                
            }
            ViewBag.Game = play;
            HttpContext.Session.SetString("Message", "");
            string message = HttpContext.Session.GetString("message");

            if (HttpContext.Session.GetInt32 ("happiness") >= 99 && HttpContext.Session.GetInt32 ("fullness") >= 99 && HttpContext.Session.GetInt32 ("energy") >=99 ) {
                play = false;
                TempData["message"] = "Congratulations! You won!";                                
            }
            int? FullnessVariable = HttpContext.Session.GetInt32 ("fullness");            
            if (HttpContext.Session.GetInt32 ("fullness") == null) {
                HttpContext.Session.SetInt32 ("fullness", 20);
            }
            int? HappinessVariable = HttpContext.Session.GetInt32 ("happiness");            
            if (HttpContext.Session.GetInt32 ("happiness") == null) {
                HttpContext.Session.SetInt32 ("happiness", 20);

            }
            int? MealsVariable = HttpContext.Session.GetInt32 ("meal");            
            if (HttpContext.Session.GetInt32 ("meal") == null) {
                HttpContext.Session.SetInt32 ("meal", 3);
            }
            int? EnergyVariable = HttpContext.Session.GetInt32 ("energy");            
            if (HttpContext.Session.GetInt32 ("energy") == null) {
                HttpContext.Session.SetInt32 ("energy", 50);

            }

            TempData["fullness"] = HttpContext.Session.GetInt32 ("fullness");
            TempData["happiness"] = HttpContext.Session.GetInt32 ("happiness");
            TempData["meal"] = HttpContext.Session.GetInt32 ("meal");
            TempData["energy"] = HttpContext.Session.GetInt32 ("energy");

            return View ();
        }

        [HttpPost]
        [Route ("processfeed")]
        public IActionResult Process (int feed) {
            bool action = true;
            Random rand = new Random ();
            int randomfullness_feed = rand.Next(5,10);
            int randomnumber = rand.Next(1,4);
            int meal_loss_feed = 1;
            // Console.WriteLine(randomnumber);
            int? MealsVariable = HttpContext.Session.GetInt32 ("meal");
            int? FullnessVariable = HttpContext.Session.GetInt32 ("fullness"); 
            if(randomnumber  == 2) {
                action = false;
                MealsVariable -= meal_loss_feed;

            }
            else {
                action = true;
                MealsVariable -=meal_loss_feed;                    
                FullnessVariable += randomfullness_feed;
            }
            TempData["message"] = "You played with your Dojodachi. Fullness =" + " " + randomfullness_feed + "Meals" + " " + meal_loss_feed;
            HttpContext.Session.SetInt32 ("fullness", (int)FullnessVariable);
            HttpContext.Session.SetInt32 ("meal", (int)MealsVariable);  
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route ("processplay")]
        public IActionResult ProcessPlay (int play) {
            // bool want_to_play = true;
            Random rand = new Random ();
            int energyloss = 5;            
            int randomnumber = rand.Next(1,4);
            int play_happinessincrease = rand.Next(5,10);
            int? EnergyVariable = HttpContext.Session.GetInt32 ("energy");
            int? HappinessVariable = HttpContext.Session.GetInt32 ("happiness");
            if(randomnumber == 2) {
                want_to_play = false;
                EnergyVariable -= energyloss;                   
            }
            else {
                want_to_play = true;
                EnergyVariable -= energyloss;                   
                HappinessVariable += play_happinessincrease; 
            }          
            // int? FullnessVariable = HttpContext.Session.GetInt32 ("fullness"); 
            // int? MealsVariable = HttpContext.Session.GetInt32 ("meal");
            TempData["message"] = "You played with your Dojodachi. Happiness =" + " " + play_happinessincrease + " " + "Energy Loss =" + " " + energyloss;
            HttpContext.Session.SetInt32 ("happiness", (int)HappinessVariable);
            HttpContext.Session.SetInt32 ("energy", (int)EnergyVariable);  
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route ("processwork")]
        public IActionResult ProcessWork (int work) {
            Random rand = new Random ();
            int work_meal_increase = rand.Next(1,3);
            // int? FullnessVariable = HttpContext.Session.GetInt32 ("fullness"); 
            int? MealsVariable = HttpContext.Session.GetInt32 ("meal");
            int? EnergyVariable = HttpContext.Session.GetInt32 ("energy");
            // int? HappinessVariable = HttpContext.Session.GetInt32 ("happiness");
            int energyloss = 5;            
            EnergyVariable -= energyloss;                     
            MealsVariable += work_meal_increase;
            TempData["message"] = "Your Dojodachi worked. Meal =" + " " + work_meal_increase + " " + "Energy Loss =" + " " + energyloss;
            HttpContext.Session.SetInt32 ("meal", (int)MealsVariable);
            HttpContext.Session.SetInt32 ("energy", (int)EnergyVariable);  
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route ("processsleep")]
        public IActionResult ProcessSleep (int sleep) {
            int? FullnessVariable = HttpContext.Session.GetInt32 ("fullness"); 
            int? EnergyVariable = HttpContext.Session.GetInt32 ("energy");
            int? HappinessVariable = HttpContext.Session.GetInt32 ("happiness");
            int energygain = 15;
            int fullnessloss = 5;
            int happinessloss = 5;            
            EnergyVariable += energygain;                     
            FullnessVariable -= fullnessloss;
            HappinessVariable -= happinessloss;
            TempData["message"] = "Your Dojodachi slept. Energy =" + "+" + energygain + " " + "Happiness Loss =" + "-" + happinessloss + "Fullness Loss =" + "-" + fullnessloss;
            HttpContext.Session.SetInt32 ("fullness", (int)FullnessVariable);
            HttpContext.Session.SetInt32 ("energy", (int)EnergyVariable);  
            HttpContext.Session.SetInt32 ("happiness", (int)HappinessVariable);            
            return RedirectToAction("Index");
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

//     public class dojodachi {
//         public int happiness = 20;
//         public int fullness = 20;
//         public int energy = 50;

//         public int meals = 3;

//         public dojodachi (int h, int f, int e, int m) {
//             happiness = h;
//             fullness = f;
//             energy = e;
//             meals = m;

//         }

//     }
// }
// }