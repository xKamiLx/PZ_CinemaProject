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
    [Authorize(Roles = "Administrator")]
    public class MoviesController : BaseController
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> dbMovies = Db.Movies.ToList();
            List<MovieViewModel> movies = dbMovies.Select(dbMovie => new MovieViewModel(dbMovie)).ToList();

            return View(movies);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie()
                {
                    Title = movieViewModel.Title,
                    Description = movieViewModel.Description
                };
                Db.Movies.Add(movie);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(movieViewModel);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = Db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            MovieViewModel movieViewModel = new MovieViewModel(movie);
            return View(movieViewModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                Movie movie = Db.Movies.Find(movieViewModel.Id);
                movie.Title = movieViewModel.Title;
                movie.Description = movieViewModel.Description;
                Db.Entry(movie).State = EntityState.Modified;
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(movieViewModel);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = Db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            MovieViewModel movieViewModel = new MovieViewModel(movie);

            return View(movieViewModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = Db.Movies.Find(id);
            Db.Movies.Remove(movie);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
