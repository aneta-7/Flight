namespace Flights.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Planes.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Flights.Models.ApplicationDbContext>
    {
        private List<Flight> flight2;
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            flight2 = new List<Flight>();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
            SeedFlights(context);
            SeedPlanes(context);

        }
        private void SeedRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Pracownik"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Pracownik";
                roleManager.Create(role);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new User { UserName = "admin@admin.pl" };
                var adminresult = manager.Create(user, "12345678");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "Marek"))
            {
                var user = new User { UserName = "marek@marek.pl" };
                var adminresult = manager.Create(user, "12345678");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Pracownik");
            }

            if (!context.Users.Any(u => u.UserName == "Prezes"))
            {
                var user = new User { UserName = "prezes@prezes.pl" };
                var adminresult = manager.Create(user, "12345678");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }
        }

        private void SeedPlanes(ApplicationDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var plane = new Plane()
                {
                    ID = i,
                    Name = "Nazwa samolotu" + i.ToString(),
                    Type = "Typ samolotu" + i.ToString(),
                    Flight = flight2[i - 1]
                };
                context.Set<Plane>().AddOrUpdate(plane);
            }
            context.SaveChanges();
        }


        private void SeedFlights(ApplicationDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var flight = new Flight()
                {
                    ID = i,
                    Code = "Kod" + i.ToString(),
                    Start = "Warszawa",
                    Date1 = DateTime.Now.AddDays(-i),
                    Time1 = "18:20",
                    Meta = "Katowice",
                    Date2 = DateTime.Now.AddDays(-i),
                    Time2 = "20:00",
                };
                context.Set<Flight>().AddOrUpdate(flight);
                flight2.Add(flight);
            }
            context.SaveChanges();
        }
    }
}
