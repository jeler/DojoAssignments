using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bright_ideas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace bright_ideas.Controllers {
    public class IdeaController : Controller {

        private bright_ideasContext _context;
        public IdeaController (bright_ideasContext context) {
            _context = context;
        }

        [HttpGet]
        [Route ("bright_ideas/{idea_id}")]
        public IActionResult IdeaPage (int idea_id) {
            int id = idea_id;
            Idea Idea = _context.Ideas.Where(i => i.IdeaId == idea_id).Include(w=>w.Creator).SingleOrDefault();
            List<Idea> AllLikes = _context.Ideas.Where (i => i.IdeaId == id).Include(r => r.Likes).ThenInclude (u => u.User).ToList ();
            ViewBag.idea = Idea;
            ViewBag.likes = AllLikes;
            return View ("Idea");
        }

        [HttpGet]
        [Route ("like/{idea_id}")]
        public IActionResult LikeIdea (int idea_id) 
        {
            int id = idea_id;
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            List<Like> ReturnedLikes = _context.Likes.Where(i => i.IdeaId == idea_id).Where(u=>u.UserId == Session).ToList();
            if(ReturnedLikes.Count != 0) {
                // return View("Dashboard", "User");
                return RedirectToAction("Dashboard", "User");
                
            }
            else 
            {

            Like NewLike = new Like {
                IdeaId = idea_id,
                UserId = (int)Session

            };
            _context.Add(NewLike);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "User");
            }
        }
        [HttpGet]
        [Route("unlike/{idea_id}")]
        public IActionResult Unlike(int idea_id) 
        {
            int? Session = HttpContext.Session.GetInt32 ("session_id");
            int id = idea_id;   
            Like RetrievedLike = _context.Likes.Where(i=>i.IdeaId == id).Where(j=>j.UserId == Session).FirstOrDefault();
            if(RetrievedLike == null) 
            {
            return RedirectToAction("Dashboard","User");          
            }
            else 
            {

            _context.Likes.Remove(RetrievedLike);
            _context.SaveChanges();
            return RedirectToAction("Dashboard","User");
            }
        }


        [HttpGet]
        [Route("delete/{idea_id}")]
        public IActionResult DeleteIdea(int idea_id) 
        {
            int id = idea_id;
            Idea RetrievedIdea = _context.Ideas.SingleOrDefault(idea => idea.IdeaId == idea_id);
            _context.Ideas.Remove(RetrievedIdea);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "User");
        }
    }
}