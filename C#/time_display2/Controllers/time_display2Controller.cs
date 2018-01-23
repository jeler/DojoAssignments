using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers {
    public class time_display2Controller : Controller {
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            return View ("Index");
        }
    }
}