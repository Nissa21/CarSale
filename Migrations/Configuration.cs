namespace CarSale.Migrations
{
    using CarSale.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarSale.Models.CarDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarSale.Models.CarDBContext context)
        {
            context.Cars.AddOrUpdate(i => i.Model,
                new Car
               {
                   Model = "Mini",
                   ReleaseDate = DateTime.Parse("1989-1-11"),
                   BodyType = "Full",
                   Price = 709900
               },
                new Car
               {
                   Model = "MiniVan",
                   ReleaseDate = DateTime.Parse("1989-1-11"),
                   BodyType = "Full",
                   Price = 909900
               }
               );

        }
    }
}
