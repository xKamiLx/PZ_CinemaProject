﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using Portal.Models;
using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class TicketsViewModel
    {
        public int Id { get; set; }

        public DateTime DateTimeShow { get; set; }

        public Room Room { get; set; }

        public Movie Movie { get; set; }

        public Show Show { get; set; }

        public string Places { get; set; }

        public string Place { get; set; }

        public bool IsPaid { get; set; }

        public bool Discount { get; set; }

        public decimal Price { get; set; }

        public float SummaryPrice { get; set; }

        public Ticket Ticket { get; set; }

        
        public int SelectedMovieId { get; set; }
        public IEnumerable<SelectListItem> MovieList { get; set; }

        public int SelectedRoomId { get; set; }
        public IEnumerable<SelectListItem> RoomList { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        //public string ApplicationUser { get; set; }

        public TicketsViewModel()
        {
        }

        public TicketsViewModel(string place, float SummaryPrice)
        {
            this.SummaryPrice = SummaryPrice;
            this.Place = place;
        }


        public TicketsViewModel(Show show)
        {
            this.Show = show;
            Id = show.Id;
            DateTimeShow = show.DateTimeShow;
            Room = show.Room;
            Movie = show.Movie;
            Places = show.Places;
            Price = show.Price;

        }
    }
}