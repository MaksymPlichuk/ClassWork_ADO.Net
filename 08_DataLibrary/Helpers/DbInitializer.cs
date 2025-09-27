using _08_DataLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _08_DataLibrary.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedAiplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane()
                {
                     Id = 1,
                     Model = "Boeing747",
                     MaxPassangers = 200,
                     AirplaneTypeId = 2,
                },
                 new Airplane()
                {
                     Id = 2,
                     Model = "Boeing748",
                     MaxPassangers = 200,
                     AirplaneTypeId = 1,
                },
                    new Airplane()
                {
                     Id = 3,
                     Model = "Broller747",
                     MaxPassangers = 100,
                     AirplaneTypeId = 1,
                }

         });
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
           {
                new Flight()
                {
                     Number = 1,
                     ArrivalCity = "Lviv",
                     DepartureCity = "Kyiv",
                     ArrivalTime = new DateTime(2025,9,21),
                     DepartureTime = new DateTime(2025,9,21),
                     AirplaneId = 1,
                     CityId = 1
                },
                 new Flight()
                {
                     Number = 2,
                     ArrivalCity = "Lviv",
                     DepartureCity = "Odessa",
                     ArrivalTime = new DateTime(2025,9,22),
                     DepartureTime = new DateTime(2025,9,22),
                     AirplaneId = 2,
                     CityId = 2
                },//new
                 new Flight()
                {
                     Number = 3,
                     ArrivalCity = "Unknown",
                     DepartureCity = "Unknown",
                     ArrivalTime = new DateTime(2026,9,22),
                     DepartureTime = new DateTime(2026,9,23),
                     AirplaneId = 2,
                     CityId = 1

                }

           });
        }//new
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Poland"},
                new Country { Id = 2, Name = "Ukraine"}
                );
        }
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Holm", CountryId = 1 },
                new City { Id = 2, Name = "Volodymyr", CountryId = 2 }
                ); 
        }
        public static void SeedAirplaneTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirplaneType>().HasData(
                new AirplaneType { Id = 1,Name="Cargo" },
                new AirplaneType { Id = 2, Name = "Passenger" }
                );
        }
    }
}
