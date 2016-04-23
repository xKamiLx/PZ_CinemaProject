using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime DateTimeShow { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}