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
    public class ShowsController : BaseController
    {
        // GET: Shows
        public ActionResult Index()
        {
            List<Show> dbShows = Db.Shows.ToList();
            List<ShowViewModel> shows = dbShows.Select(dbShow => new ShowViewModel(dbShow)).ToList();

            return View(shows);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ShowViewModel showViewModel = new ShowViewModel();
            var moviesList = Db.Movies.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
            showViewModel.MovieList = moviesList;
            var roomsList = Db.Rooms.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            showViewModel.RoomList = roomsList;

            return View(showViewModel);
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowViewModel showViewModel)
        {
            if (ModelState.IsValid)
            {
                Room room = Db.Rooms.Find(showViewModel.SelectedRoomId);
                Movie movie = Db.Movies.Find(showViewModel.SelectedMovieId);
                Show show = new Show()
                {
                    DateTimeShow = DateTime.Now,
                    Places = "00000000000000000000000000000000000000000000000000",
                    Room = room,
                    Movie = movie,
                };
                Db.Shows.Add(show);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(showViewModel);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = Db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }

            ShowViewModel showViewModel = new ShowViewModel(show);
            var moviesList = Db.Movies.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
            showViewModel.MovieList = moviesList;
            showViewModel.SelectedMovieId = show.Movie.Id;

            var roomsList = Db.Rooms.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            showViewModel.RoomList = roomsList;
            showViewModel.SelectedRoomId = show.Room.Id;

            return View(showViewModel);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShowViewModel showViewModel)
        {
            if (ModelState.IsValid)
            {
                Room room = Db.Rooms.Find(showViewModel.SelectedRoomId);
                Movie movie = Db.Movies.Find(showViewModel.SelectedMovieId);

                Show show = Db.Shows.Find(showViewModel.Id);
                show.DateTimeShow = showViewModel.DateTimeShow;
                show.Movie = movie;
                show.Room = room;

                Db.Entry(show).State = EntityState.Modified;
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(showViewModel);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = Db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ShowViewModel showViewModel = new ShowViewModel(show);

            return View(showViewModel);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = Db.Shows.Find(id);
            Db.Shows.Remove(show);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
