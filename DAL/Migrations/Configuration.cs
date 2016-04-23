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
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Portal.Models.ApplicationDbContext context)
        {
            InitializeRooms(context);

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

        private void InitializeRooms(ApplicationDbContext context)
        {
            if (context.Rooms == null || !context.Rooms.Any())
            {
                Room room1 = new Room()
                {
                    Id = 1,
                    Name = "Sala 1"
                };
                Room room2 = new Room()
                {
                    Id = 2,
                    Name = "Sala 2"
                };
                Room room3 = new Room()
                {
                    Id = 3,
                    Name = "Sala 3"
                };
                Room room4 = new Room()
                {
                    Id = 4,
                    Name = "Sala 4"
                };
                Room room5 = new Room()
                {
                    Id = 5,
                    Name = "Sala 5"
                };
                context.Rooms.Add(room1);
                context.Rooms.Add(room2);
                context.Rooms.Add(room3);
                context.Rooms.Add(room4);
                context.Rooms.Add(room5);
                context.SaveChanges();
            }
        }
    }
}
