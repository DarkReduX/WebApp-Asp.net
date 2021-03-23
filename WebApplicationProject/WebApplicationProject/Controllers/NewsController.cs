using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers
{
    public class NewsController : Controller
    {
        private NewsContext db = new NewsContext();

        // GET: News
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<News> allPosts = db.news.ToList();
            List<string> createdByNames = new List<string>();
            List<News> postsPerPage = allPosts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = allPosts.Count };
            foreach (News item in allPosts)
            {
                createdByNames.Add(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(item.UserId).UserName);
            }
            NewsViewModel newsViewModel = new NewsViewModel() { PageInfo = pageInfo, Posts = postsPerPage, CreatedByNames = createdByNames };
            return View(newsViewModel);
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "ID,header,info")] News news, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                string userId = User.Identity.GetUserId();
                byte[] imageData = null;
                using (BinaryReader binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                news.Image = imageData;
                news.UserId = userId;

                Ip ipInfo = getIpInfo(getCurrentIPv4Address.ToString());
                ipInfo.NewsId = news.ID;

                db.news.Add(news);
                db.Ips.Add(ipInfo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News post = db.news.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: News/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,header,info")] News post)
        {
            if (ModelState.IsValid)
            {
                post.UserId = User.Identity.GetUserId();
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: News/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News post = db.news.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: News/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.news.Find(id);
            db.news.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddComment(int? newsId)
        {
            if (!newsId.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var news = db.news.FirstOrDefault(n => n.ID == newsId.Value);

            if (news == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            ViewBag.NewsId = newsId;

            return PartialView("_AddComment");
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddComment(CommentAddViewModel vm)
        {
            Comment comment = new Comment
            {
                Id = Guid.NewGuid(),
                NewsId = vm.NewsId,
                Message = vm.Message,
                //Topic = vm.Topic,


                UserId = User.Identity.GetUserId()
            };

            db.Comments.Add(comment);

            db.SaveChanges();

            return Json(new { Success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //ipstack code
        private static IPAddress getCurrentIPv6Address => (IPAddress)System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(0);

        public static IPAddress getCurrentIPv4Address => getCurrentIPv6Address.MapToIPv4();

        public static Ip getIpInfo(string IP_adress)
        {
            const string IP_STACK_API_KEY = "7bf69112c979a5fcaab766926395eee4"; ;
            //var url = "http://freegeoip.net/json/" + IP;
            //var url = "http://freegeoip.net/json/" + IP;
            string url = "http://api.ipstack.com/" + IP_adress + $"?access_key={IP_STACK_API_KEY}";
            var request = System.Net.WebRequest.Create(url);
            Ip ip = new Ip();
            using (WebResponse wrs = request.GetResponse())
            using (Stream stream = wrs.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                JObject obj = JObject.Parse(json);
                ip.ip = (string)obj["ip"];
                ip.type = (string)obj["type"];
                ip.continentCode = (string)obj["continent_code"];
                ip.continentName = (string)obj["continent_name"];
                ip.countryCode = (string)obj["country_code"];
                ip.countryName = (string)obj["country_name"];
                ip.regionCode = (string)obj["region_code"];
                ip.regionName = (string)obj["region_name"];
                ip.city = (string)obj["city"];
                ip.zip = (string)obj["zip"];
                ip.latitude = (string)obj["latitude"];
                ip.longitude = (string)obj["longitude"];

                /*string City = (string)obj["city"];
                string Country = (string)obj["region_name"];
                string CountryCode = (string)obj["country_code"];
                string ContinentName = (string)obj["continent_name"];
                string RegionName = (string)obj["region_name"];
                String Location = (string)obj["ip"];*/

                //return (CountryCode + " - " + Country + "," + City);
                return ip;
            }
        }
    }
}
