namespace DevReadyAcademy.Migrations
{
    using DevReadyAcademy.Models;
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

            context.Courses.AddOrUpdate(
              p => p.Title,
              new Course { Title = "Analyzing Data with Power BI", PublishDate = DateTime.Now },
              new Course { Title = "Querying Microsoft SQL Server", PublishDate = DateTime.Now },
              new Course { Title = "Administering Microsoft SQL Server Databases", PublishDate = DateTime.Now },
              new Course { Title = "Implementing a Data Warehouse with Microsoft SQL Server", PublishDate = DateTime.Now },
              new Course { Title = "Programming in C#", PublishDate = DateTime.Now },
              new Course { Title= "Developing ASP.NET MVC 5 Web Applications", PublishDate = DateTime.Now }

            );

        }
    }
}
