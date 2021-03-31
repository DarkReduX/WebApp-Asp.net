using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Models;
using WebApplicationProject.Repository;

namespace WebApplicationProject.Controllers
{
    public class NewsController : Controller
    {
        private NewsContext db = new NewsContext();

        // GET: News
        public ActionResult Index(int page=1, int pageSize = 10)
        {
            var repository = new PostRepository();
            var post = repository.GetByPostId(1);

            List<News> allPosts = db.news.ToList();
            List<News> postsPerPage = allPosts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = allPosts.Count };
<<<<<<< Updated upstream
            NewsViewModel newsViewModel = new NewsViewModel() { PageInfo = pageInfo, posts = postsPerPage };
=======
            foreach (News item in allPosts)
            {
                createdByNames.Add(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(item.UserId).UserName);
            }
            NewsViewModel newsViewModel = new NewsViewModel() { PageInfo = pageInfo, Posts = postsPerPage, CreatedByNames = createdByNames, PostLikes = post.PostLikes.Count(e => e.UserLike)};
>>>>>>> Stashed changes
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
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,header,info")] News news)
        {
            if (ModelState.IsValid)
            {
                db.news.Add(news);
<<<<<<< Updated upstream
=======
                db.Ips.Add(ipInfo);               
>>>>>>> Stashed changes
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
