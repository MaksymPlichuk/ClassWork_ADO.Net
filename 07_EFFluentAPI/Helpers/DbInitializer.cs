using _07_EFFluentAPI.Entitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EFFluentAPI.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "USA" },
                new Country { Id = 2, Name = "Germany" },
                new Country { Id = 3, Name = "Ukraine" }
            );
        }
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "New York", CountryId = 1 },
                new City { Id = 2, Name = "Berlin", CountryId = 2 },
                new City { Id = 3, Name = "Kyiv", CountryId = 3 }
            );
        }
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Food" },
                new Category { Id = 3, Name = "Clothes" }
            );
        }
        public static void SeedShops(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(
                new Shop { Id = 1, Name = "BestBuy", Adress = "5th Avenue 123", CityId = 1, ParkingArea = 200 },
                new Shop { Id = 2, Name = "Edeka", Adress = "Alexanderplatz 45", CityId = 2, ParkingArea = 150 },
                new Shop { Id = 3, Name = "Silpo", Adress = "Khreshchatyk 12", CityId = 3, ParkingArea = 80 }
            );
        }
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Cashier" },
                new Position { Id = 2, Name = "Manager" },
                new Position { Id = 3, Name = "Security" }
            );
        }
        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker { Id = 1, Name = "Albert", Surname = "Wesker", Salary = 1200, Email = "umbrella@shop.com", PhoneNumber = "+123456987456", PositionId = 1, ShopId = 1 },
                new Worker { Id = 2, Name = "Werner", Surname = "Heisenberg", Salary = 2000, Email = "Heisenberg@shop.com", PhoneNumber = "+18888698745", PositionId = 2, ShopId = 2 },
                new Worker { Id = 3, Name = "Oleh", Surname = "Vinnuk", Salary = 900, Email = "oleh.v@shop.com", PhoneNumber = "+3809874556698", PositionId = 3, ShopId = 3 }
            );

        }
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1200m, Discount = 0.1f, Quantity = 20, IsInStock = true, CategoryId = 1 },
                new Product { Id = 2, Name = "Apple", Price = 1.2m, Discount = 0f, Quantity = 500, IsInStock = true, CategoryId = 2 },
                new Product { Id = 3, Name = "T-Shirt", Price = 25m, Discount = 0.2f, Quantity = 100, IsInStock = true, CategoryId = 3 }
            );
        }

    }
}
