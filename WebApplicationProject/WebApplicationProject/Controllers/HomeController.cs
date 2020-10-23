using System;
using System.Collections.Generic;
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
            return View(db.news);
        }
    }
}