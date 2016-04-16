using DAL.Models;
using Portal.Models;

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Portal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Portal.Models.ApplicationDbContext context)
        {
            InitializeShows(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        public void InitializeShows(ApplicationDbContext context)
        {
            if (context.Shows == null || !context.Shows.Any())
            {
                Show show1 = new Show()
                {
                    Id = 1,
                    Title = "Nienawistna osemka",
                    Description = "Example",
                    DateTimeShow = DateTime.Now,
                };
                context.Shows.Add(show1);
                context.SaveChanges();
            }
        }
    }
}
