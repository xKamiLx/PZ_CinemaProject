using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Models;
using Portal.ViewModels;

namespace Portal.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class NewsController : BaseController
    {
        // GET: News
        public ActionResult Index()
        {
            List<News> dbNewses = Db.Newses.ToList();
            List<NewsViewModel> newses = dbNewses.Select(dbNews => new NewsViewModel(dbNews)).ToList();

            return View(newses);
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
                    ApplicationUser = Db.Users.First(x => x.UserName == User.Identity.Name)
                };
                Db.Newses.Add(news);
                Db.SaveChanges();

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
            News news = Db.Newses.Find(id);
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
                News news = Db.Newses.Find(newsViewModel.Id);
                news.Title = newsViewModel.Title;
                news.Description = newsViewModel.Description;
                news.AddedDateTime = DateTime.Now;
                //news.ApplicationUser = newsViewModel.ApplicationUser;
                Db.Entry(news).State = EntityState.Modified;
                Db.SaveChanges();

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
            News news = Db.Newses.Find(id);
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
            News news = Db.Newses.Find(id);
            Db.Newses.Remove(news);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
