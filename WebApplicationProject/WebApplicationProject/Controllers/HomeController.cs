using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        NewsContext db = new NewsContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult News()
        {
            return View(db.News);
        }
        public ActionResult Post()
        {
            return View();
        }
        public ActionResult CreatePost()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditPost(int? post_id)
        {
            if (post_id == null)
            {
                return HttpNotFound();
            }
            News post = db.News.Find(post_id);
            if (post != null)
            {
                return View(post);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditPost(News post)
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("News");
        }
    }
}