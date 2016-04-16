using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using Portal.Models;
using Portal.ViewModels;

namespace Portal.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News
        public ActionResult Index()
        {
            List<News> dbNewses = db.Newses.ToList();
            List<NewsViewModel> Newses = dbNewses.Select(dbNews => new NewsViewModel(dbNews)).ToList();

            return View(Newses);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsViewModel newsViewModel)
        {
            if (ModelState.IsValid)
            {
                News news = new News()
                {
                    Title = newsViewModel.Title,
                    Description = newsViewModel.Description,
                    AddedDateTime = DateTime.Now,
                    ApplicationUser = db.Users.First(x => x.UserName == User.Identity.Name)
                };
                db.Newses.Add(news);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(newsViewModel);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            NewsViewModel newsViewModel = new NewsViewModel(news);
            return View(newsViewModel);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsViewModel newsViewModel)
        {
            if (ModelState.IsValid)
            {
                News news = db.Newses.Find(newsViewModel.Id);
                news.Title = newsViewModel.Title;
                news.Description = newsViewModel.Description;
                //news.AddedDateTime = newsViewModel.AddedDateTime;
                //news.ApplicationUser = newsViewModel.ApplicationUser;
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(newsViewModel);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            NewsViewModel newsViewModel = new NewsViewModel(news);
            return View(newsViewModel);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.Newses.Find(id);
            db.Newses.Remove(news);
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
