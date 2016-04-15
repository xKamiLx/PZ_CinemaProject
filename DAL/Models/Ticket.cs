using System.Collections.Generic;
using Portal.Models;

namespace DAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public bool IsPaid { get; set; }
        public bool Discount { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}