using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers {

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    namespace YourNamespace.Controllers {
        public class HelloController : Controller {
            // [HttpGetAttribute]
            // public string Index () {
            //     return "Hello World!";
            // }
            // [HttpGet]
            // [Route ("index")]
            // public string Index () {
            //     return "Hello World!";
            // }

            [HttpGet]
            [Route ("{fname}/{lname}/{a}/{favecolor}")]
            public JsonResult Display (string fname, string lname, string a, string favecolor) {
                var AnonObject = new {
                    FirstName = fname,
                    LastName = lname,
                    Age = a,
                    FavoriteColor = favecolor
                };
                return Json (AnonObject);
            }

            [HttpGet]
            [Route ("index")]
            public IActionResult Index () {
                return View ();
                //OR
                // return View ("Index");
                //Both of these returns will render the same view (You only need one!)
            }
        }
    }
}