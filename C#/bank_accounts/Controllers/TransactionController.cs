using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank_accounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bank_accounts.Controllers {
    public class TransactionController : Controller {

        private BankAccountContext _context;

        public TransactionController (BankAccountContext context) {
            _context = context;
        }

        [HttpGet]
        [Route ("account/{id}")]
        public IActionResult AccountPage () {
            int? Session = HttpContext.Session.GetInt32 ("id_session");
            User ReturnedValue = _context.users.SingleOrDefault (user => user.id == Session);
            ViewBag.user = ReturnedValue;
            // List<User> Transactions = _context.transactions.Include(u => u.amount).ToList();
            // Transactions Transactions = _context.transactions.SingleOrDefault(t => t.Userid == Session);
            List<User> Transactions = _context.users.Include(u => u.Transactions).ToList();            
            ViewBag.transactions = Transactions;
            // var AllTransactions = _context.transactions.OrderByDescending(t => t.created_at).Include(user => user.Userid).Where(u => u.Userid == ReturnedValue.id);
            // ViewBag.transactions = AllTransactions;
            return View ("AccountPage");
        }

        [HttpGet]
        [Route ("logout")]
        public IActionResult Logout () {
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index", "User");
        }

        [HttpPost]
        [Route("transact")]
        public IActionResult Transact(Transactions model) {
            if(ModelState.IsValid) {
            int? Session = HttpContext.Session.GetInt32 ("id_session");
            User ReturnedValue = _context.users.SingleOrDefault (user => user.id == Session);
            ViewBag.user = ReturnedValue;                
            Transactions NewTransaction = new Transactions 
                {
                    amount = model.amount,
                    Userid = (long)Session

                };

                if(model.amount + ReturnedValue.balance < 0) {
                    ModelState.AddModelError(string.Empty, "You can't withdraw more money than you have!");
                    return View("AccountPage");                    
                }

                else {
                _context.transactions.Add (NewTransaction);
                _context.SaveChanges ();
                ReturnedValue.balance += model.amount;
                _context.SaveChanges();
                return Redirect($"account/{ReturnedValue.id}");
                }
            }
            else {
            int? Session = HttpContext.Session.GetInt32 ("id_session");
            User ReturnedValue = _context.users.SingleOrDefault (user => user.id == Session);
            ViewBag.user = ReturnedValue;
            User current_user = _context.users.Where(user => user.id == Session).Include(u => u.Transactions).SingleOrDefault();
            // List<Transactions> transactions = _context.transactions.Include(u=> u.Userid).OrderByDescending(s => s.created_at);
            // current_user.Transactions = transactions.ToList();
            
            // Transactions Transactions = _context.transactions.SingleOrDefault(t => t.Userid == Session);
            // context.users (users = table name)
            ViewBag.user = current_user;
            // ViewBag.transactions =transactions;
            return View("AccountPage");
            }
        }
    }
}