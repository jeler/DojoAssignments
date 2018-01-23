using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace quotes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Quotes(string NameField, string QuoteField)
        {
            string NameCheck = NameField; 
            string QuoteCheck = QuoteField;
            List<string> errors = new List<string>();
            if (NameCheck == null) {
                errors.Add("Name Field Can't Be Blank!");
            } 
            if (QuoteCheck == null) {
                errors.Add("Quote can not be blank!");
            }

            if(errors.Count != 0) {
                ViewBag.errors = errors;
                Console.WriteLine(errors[0]);
                Console.WriteLine("---------- got here! -----------");
                return View("Index");
            }

            else {
            string FString = '"' + NameField + '"';
            // char FString2 = 'J';
            // Console.Write( "----------------" + FString + "___________________");
            string QString = '"' + QuoteField + '"';
    
            string insert = $"INSERT INTO quotes (name, quote) VALUES ({FString}, {QString})";
            // Console.WriteLine(insert + "---------------");
            DbConnector.Execute(insert);
            return RedirectToAction("quotes");
            }
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult QuotesShow()
        {
            string query = "SELECT * from quotes";
            var AllQuotes = DbConnector.Query(query);
            ViewBag.quotes = AllQuotes;
            Console.WriteLine("+++++++++++++++++++" + AllQuotes);
            foreach (var user in AllQuotes) {
                Console.WriteLine( "--------" + user["name"] + " ________________");
                ViewBag.name = user["name"];
            }
            // List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes");
            // ViewData["AllQuotes"] = AllQuotes;

            return View();
        }
    }
}
