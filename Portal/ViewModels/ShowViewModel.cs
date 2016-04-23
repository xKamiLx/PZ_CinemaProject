using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;

namespace Portal.ViewModels
{
    public class ShowViewModel
    {
        public int Id { get; set; }
        public DateTime DateTimeShow { get; set; }
        public Room Room { get; set; }
        public Movie Movie { get; set; }

        public int SelectedMovieId { get; set; }
        public IEnumerable<SelectListItem> MovieList { get; set; }

        public int SelectedRoomId { get; set; }
        public IEnumerable<SelectListItem> RoomList { get; set; }

        public ShowViewModel()
        {
        }

        public ShowViewModel(Show show)
        {
            Id = show.Id;
            DateTimeShow = show.DateTimeShow;
            Room = show.Room;
            Movie = show.Movie;
        }
    }
}