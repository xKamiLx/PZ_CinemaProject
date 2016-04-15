using System;
using System.Collections.Generic;
using Portal.Models;

namespace DAL.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDateTime { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}