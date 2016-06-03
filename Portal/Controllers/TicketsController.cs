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
    [Authorize(Roles = "U¿ytkownik, Administrator")]
    public class TicketsController : BaseController
    {
        // GET: Shows
        public ActionResult Index()
        {
            List<Show> dbShows = Db.Shows.ToList();
            List<ShowViewModel> shows = dbShows.Select(dbShow => new ShowViewModel(dbShow)).ToList();

            return View(shows);
        }

        
        // GET: Ticket/Buy
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

            ApplicationUser applicationuser = Db.Users.First(x => x.UserName == User.Identity.Name);
            ticketsViewModel.ApplicationUser = applicationuser;
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
        public ActionResult Buy(TicketsViewModel ticketsViewModel)
        {
            if (ModelState.IsValid)
            {
                Ticket ticket = new Ticket()
                {

                Place = ticketsViewModel.Place,
                IsPaid = false,
                Discount = false,
                Price = ticketsViewModel.SummaryPrice,
                ApplicationUser = Db.Users.First(x => x.UserName == User.Identity.Name),
                Show = ticketsViewModel.Show
                };

                Db.Tickets.Add(ticket);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
           
            return View(ticketsViewModel);
        }
    
    }
}
