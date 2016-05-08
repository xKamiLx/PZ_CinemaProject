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
    //[Authorize(Roles = "Administrator")]
    public class TicketsController : BaseController
    {
        // GET: Shows
        public ActionResult Index()
        {
            List<Show> dbShows = Db.Shows.ToList();
            List<ShowViewModel> shows = dbShows.Select(dbShow => new ShowViewModel(dbShow)).ToList();

            return View(shows);
        }


        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Ticket1(ShowViewModel showViewModel)
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
        public ActionResult Buy(int? id)
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

            TicketsViewModel ticketsViewModel = new TicketsViewModel(show);
            var moviesList = Db.Movies.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
            ticketsViewModel.MovieList = moviesList;
            ticketsViewModel.SelectedMovieId = show.Movie.Id;

            var roomsList = Db.Rooms.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ticketsViewModel.RoomList = roomsList;
            ticketsViewModel.SelectedRoomId = show.Room.Id;

            return View(ticketsViewModel);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_ticket(TicketsViewModel ticketsViewModel)
        {
            if (ModelState.IsValid)
            {
                Room room = Db.Rooms.Find(ticketsViewModel.SelectedRoomId);
                Movie movie = Db.Movies.Find(ticketsViewModel.SelectedMovieId);

                Show show = Db.Shows.Find(ticketsViewModel.Id);
                show.DateTimeShow = ticketsViewModel.DateTimeShow;
                show.Movie = movie;
                show.Room = room;


                // tworzenie nowego biletu

               
                // podmiana zajętych miejsc




                Db.Entry(show).State = EntityState.Modified;
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(ticketsViewModel);
        }
    
    }
}
