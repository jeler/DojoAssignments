using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wedding_planner.Models;

namespace wedding_planner.Controllers {
    public class WeddingController : Controller {
        private wedding_plannerContext _context;

        public WeddingController (wedding_plannerContext context) {
            _context = context;
        }

        [HttpGet]
        [Route ("newwedding")]
        public IActionResult NewWedding () {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            User ReturnedValue = _context.Users.SingleOrDefault (user => user.UserId == Session);
            ViewBag.user = ReturnedValue;
            return View ("Create");
        }

        [HttpPost]
        [Route ("createwedding")]

        public IActionResult Create (Wedding model) {
            if (ModelState.IsValid) {
                int? Session = HttpContext.Session.GetInt32 ("session_id");
                ViewBag.session = Session;
                Wedding CreateWedding = new Wedding {
                    wedder_one = model.wedder_one,
                    wedder_two = model.wedder_two,
                    date = model.date,
                    address = model.address,
                    CreatorId = (int) Session
                };
                _context.Weddings.Add(CreateWedding);
                _context.SaveChanges();
                return Redirect($"wedding/{CreateWedding.WeddingId}");
            } else {
                return View("Create");

            }
        }

        [HttpGet]
        [Route ("wedding/{id}")]
        public IActionResult SpecificWedding (int id) {
            int wedding_id = id;
            Wedding ReturnedWedding = _context.Weddings.SingleOrDefault (w => w.WeddingId == wedding_id);
            ViewBag.wedding = ReturnedWedding;
            List<Wedding> Guests = _context.Weddings.Where (w => w.WeddingId == wedding_id).Include (r => r.RSVPS).ThenInclude (u => u.User).ToList ();
            ViewBag.guests = Guests;
            return View ("SpecificWedding");
        }

        [HttpGet]
        [Route ("rsvp/{wedding_id}")]
        public IActionResult RSVP (int wedding_id) {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            // check whether user has already RSVPed to wedding
            RSVP ReturnedValue = _context.RSVPS.Where (w => w.WeddingId == wedding_id).SingleOrDefault (u => u.UserId == Session);
                if (ReturnedValue == null) {
                    RSVP NewRSVP = new RSVP {
                    WeddingId = wedding_id,
                    UserId = (int) Session
                    };
                    _context.Add (NewRSVP);
                    _context.SaveChanges ();
                    return RedirectToAction ("Dashboard", "User");
                }
            else {
                return RedirectToAction("Dashboard", "User");
            }
        }
        [HttpGet]
        [Route ("delete/{wedding_id}")]
        public IActionResult Delete(int wedding_id) {
            Wedding RetrievedWedding =_context.Weddings.SingleOrDefault(w => w.WeddingId == wedding_id);
            _context.Weddings.Remove(RetrievedWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "User");
        }
        [HttpGet]
        [Route("unrsvp/{wedding_id}")]
        public IActionResult UnRSVP(int wedding_id) {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            RSVP RetrievedRSVP = _context.RSVPS.Where(r=> r.WeddingId == wedding_id).Where(u => u.UserId == Session).SingleOrDefault();
            _context.Remove(RetrievedRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "User");
        }
    }
}