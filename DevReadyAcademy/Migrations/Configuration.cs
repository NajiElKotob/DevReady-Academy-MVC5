namespace DevReadyAcademy.Migrations
{
    using DevReadyAcademy.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DevReadyAcademy.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DevReadyAcademy.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            // Use Code First Migrations to Seed the Database
            // https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-3

            //Categories
            context.Categories.AddOrUpdate(
                  c => c.Name,
                  new Category { Name = "Unspecified" },
                  new Category { Name = "Programming" },
                  new Category { Name = "Data Science" },
                  new Category { Name = "Database" }
                );

            //Courses
            context.Courses.AddOrUpdate(
              p => p.Title,
              new Course { Title = "Analyzing Data with Power BI", CategoryId = 1, PublishDate = DateTime.Now },
              new Course { Title = "Querying Microsoft SQL Server", CategoryId = 1, PublishDate = DateTime.Now },
              new Course { Title = "Administering Microsoft SQL Server Databases", CategoryId = 1, PublishDate = DateTime.Now },
              new Course { Title = "Implementing a Data Warehouse with Microsoft SQL Server", CategoryId = 1, PublishDate = DateTime.Now },
              new Course { Title = "Programming in C#", CategoryId = 1, PublishDate = DateTime.Now },
              new Course { Title = "Developing ASP.NET MVC 5 Web Applications", CategoryId = 1, PublishDate = DateTime.Now }

            );


            //Users and Roles
            var adminRoleName = "Admin";
            var adminUserName = "naji@dotnetheroes.local";
            var adminEmailAddress = "naji@dotnetheroes.local";

            var instructorRoleName = "Instructor";
            var instructorUserName = "instructor@dotnetheroes.local";
            var instructorEmailAddress = "instructor@dotnetheroes.local";

            var usersRoleName = "Users";

            var defaultPassword = "Pa55w.rd";
            //var hashedPassword = new PasswordHasher().HashPassword("Pa55w.rd");

            //Role and Users
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            //Admin
            if (!context.Roles.Any(r => r.Name == adminRoleName))
            {
                var role = new IdentityRole { Name = adminRoleName };
                roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == adminUserName))
            {
                var user = new ApplicationUser
                {
                    UserName = adminUserName,
                    Email = adminEmailAddress,
                    EmailConfirmed = true
                };

                userManager.Create(user, defaultPassword);
                userManager.AddToRole(user.Id, adminRoleName);
            }


            //Instructor
            if (!context.Roles.Any(r => r.Name == instructorRoleName))
            {
                var role = new IdentityRole { Name = instructorRoleName };
                roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == instructorUserName))
            {
                var user = new ApplicationUser
                {
                    UserName = instructorUserName,
                    Email = instructorEmailAddress,
                    EmailConfirmed = true
                };

                userManager.Create(user, defaultPassword);
                userManager.AddToRole(user.Id, instructorRoleName);
            }


            //Users
            if (!context.Roles.Any(r => r.Name == usersRoleName))
            {
                var role = new IdentityRole { Name = usersRoleName };
                roleManager.Create(role);
            }


        }
    }
}
