using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeShow { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}