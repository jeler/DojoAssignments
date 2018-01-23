using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers {
    public class dojo_survey2Controller : Controller {
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            return View ();
            //OR
            // return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }

        [HttpPost]
        [Route ("result")]
        public IActionResult Result (string NameField, string LocationField, string LanguageField, string CommentField) {
            // Do something with form input
            ViewBag.Name = NameField;
            ViewBag.Location = LocationField;
            ViewBag.Langauge = LanguageField;
            ViewBag.Comment = CommentField;
            return View("Result");
        }
    }
}