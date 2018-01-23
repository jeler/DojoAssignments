using System;
using System.Collections.Generic;
using lost_in_woods.Factory;
using lost_in_woods.Models;
using Microsoft.AspNetCore.Mvc; //Need to include reference to new Factory Namespace

namespace lost_in_woods.Controllers {
    public class HomeController : Controller {
        private readonly HikeFactory hikeFactory;
        public HomeController () {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            hikeFactory = new HikeFactory ();
        }
        // GET: /Home/
        [HttpGet]
        [Route ("lostinthewoods")]
        public IActionResult Index () {
            //We can call upon the methods of the userFactory directly now.
            ViewBag.hikes = hikeFactory.FindAll();
            return View ("Index");
        }

        [HttpGet]
        [Route ("lostinthewoods/NewTrail")]
        public IActionResult NewTrailCreation () {
            return View ("NewTrail");
        }

        [HttpPost]
        [Route ("CreateHike")]
        public IActionResult CreateHike (Hike hike) {
            if (ModelState.IsValid) {
                hikeFactory.Add (hike);
                return RedirectToAction ("Index");
            } else {
                return View("NewTrail");
            }
        }

        [HttpGet]
        [Route ("lostinthewoods/trails/{id}")]
        public IActionResult ShowHike (int id) {
            Console.WriteLine("+++++++++" + id + "++++++++++++");
            ViewBag.hikes = hikeFactory.FindByID(id);
            return View("ShowHike");
        }
    }
}