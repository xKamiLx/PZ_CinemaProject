using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Portal.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole,
        int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}