using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers {
    public class portfolio2Controller : Controller {
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            //OR
            return View ("Index");
        }

        [HttpGet]
        [Route ("Projects")]
        public IActionResult Projects () {
            //OR
            return View ("Projects");
        }

        [HttpGet]
        [Route ("Form")]
        public IActionResult Form () {
            //OR
            return View ("Form");
        }
    }
}