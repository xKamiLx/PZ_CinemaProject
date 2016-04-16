using System.Collections.Generic;

namespace DAL.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Places { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}