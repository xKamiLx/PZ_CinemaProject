using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class TicketsViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateTimeShow { get; set; }

        public Room Room { get; set; }

        public Movie Movie { get; set; }

        public Show Show { get; set; }

        public String Places { get; set; }

        public Ticket Ticket { get; set; }

        public int SelectedMovieId { get; set; }
        public IEnumerable<SelectListItem> MovieList { get; set; }

        public int SelectedRoomId { get; set; }
        public IEnumerable<SelectListItem> RoomList { get; set; }

        public TicketsViewModel()
        {
        }

        public TicketsViewModel(Show show)
        {
            Id = show.Id;
            DateTimeShow = show.DateTimeShow;
            Room = show.Room;
            Movie = show.Movie;
            Places = show.Places;

           
    }
    }
}