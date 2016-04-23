using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime DateTimeShow { get; set; }
        public string Places { get; set; }
        public virtual Room Room { get; set; }
        public virtual Movie Movie { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}