using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojo_league.Models;
using dojo_league.Factory;

namespace dojo_league.Controllers
{
    public class HomeController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;

        public HomeController () {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory ();
        }

        // GET: /Home/
        [HttpGet]
        [Route("Ninjas")]
        public IActionResult Ninja()
        {
            ViewBag.dojos_list = dojoFactory.FindAll();
            ViewBag.ninjas = ninjaFactory.FindAll();
            return View();
        }

        [HttpPost]
        [Route("ninjaprocess")]
        public IActionResult ninjaprocess(Ninja ninja) {
            if(ModelState.IsValid) {
                ninjaFactory.Add(ninja);
                return RedirectToAction("Ninja");
            }
            else {
                ViewBag.ninjas = ninjaFactory.FindAll();
                ViewBag.dojos_list = dojoFactory.FindAll();  
                return View("Ninja");
            }
        }

        [HttpGet]
        [Route("Ninjas/{id}")]
        public IActionResult ninja_page(int id) {
            ViewBag.ninjas = ninjaFactory.FindById(id);
            Console.WriteLine(ViewBag.ninjas);
            return View();
        }

        [HttpGet]
        [Route("Dojos")]
        public IActionResult Dojos() {
            ViewBag.dojos = dojoFactory.FindAll();
            return View();
        }

        [HttpGet]
        [Route("Dojos/{id}")]
        public IActionResult dojo_page(int id) {
            ViewBag.specific_dojo = dojoFactory.FindById(id);
            ViewBag.specific_ninja = ninjaFactory.NinjasForDojoById(id);
            ViewBag.rogue_ninjas = ninjaFactory.FindRogue();
            return View("Dojoinfo");
        }

        [HttpPost]
        [Route ("dojoprocess")]
        public IActionResult dojoprocess(Dojo dojo) {
            if(ModelState.IsValid) {
                dojoFactory.Add(dojo);
                return RedirectToAction("Dojos");
            }
            else {
            ViewBag.dojos = dojoFactory.FindAll();
            return View("Dojos");
            }
        }

        [HttpGet]
        [Route("banish/{id}")]

        public IActionResult banish(long id) {
            ninjaFactory.Banish(id);
            return RedirectToAction("Dojos");
        }

        [HttpGet]
        [Route ("recruit/{id}/{dojos_id}")]
        public IActionResult recruit(long id, long dojos_id) {
            ninjaFactory.Recruit(id, dojos_id);
            return RedirectToAction("Ninja");
        }
    }
}
