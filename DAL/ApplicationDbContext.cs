using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Portal.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole,
        int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}