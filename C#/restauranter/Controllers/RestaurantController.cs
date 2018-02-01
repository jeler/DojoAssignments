using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restauranter.Models;
using System.Linq;
// Other usings
 
public class RestaurantController : Controller
{
    private restauranterContext _context;
 
    public RestaurantController(restauranterContext context)
    {
        _context = context;
    }
 
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View ("Index");
    }

    [HttpPost]
    [Route("processreview")]
    public IActionResult Process(Restaurant model) {
        if(ModelState.IsValid) {
            Restaurant NewRestaurant = new Restaurant 
            {
                user_name = model.user_name,
                restaurant_name = model.restaurant_name,
                visit_date =  model.visit_date,
                stars = model.stars,
                review = model.review
            };
            _context.Add(NewRestaurant);
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }
        else {
            return View("Index");
        }
    }

    [HttpGet]
    [Route("reviews")]
    public IActionResult Reviews() {
        List<Restaurant> AllInfo = _context.restaurants.ToList();
        ViewBag.data = AllInfo;        
        return View("Reviews");
    }
}