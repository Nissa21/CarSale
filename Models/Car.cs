using System;
using System.Data.Entity;

namespace CarSale.Models
{
   
    public class Car
    {

        public int ID { get; set; }
        public string Model  { get; set; }
        public string BodyType  { get; set; }
        public decimal ModelNo  { get; set; }

        public string FuelType  { get; set; }
        public DateTime ReleaseDate  { get; set; }
        public string Color  { get; set; }
        public decimal Price  { get; set; }
        public byte[] CarImg { get; set; }

    }


    public class CarDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }



}