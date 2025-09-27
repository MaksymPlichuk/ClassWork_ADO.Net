using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07_EFFluentAPI.Entitties;
using _07_EFFluentAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace _07_EFFluentAPI
{
    internal class ShopDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=ShopEF;
            Integrated Security=True;Connect Timeout=5;Encrypt=False;
            Trust Server Certificate=False;Application Intent=ReadWrite;
            Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Position>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<Position>().HasMany(p => p.Workers).WithOne(w => w.Position).HasForeignKey(p => p.PositionId);

            modelBuilder.Entity<Worker>().Property(w => w.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Worker>().Property(w => w.Surname).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Worker>().Property(w => w.Salary).IsRequired();
            modelBuilder.Entity<Worker>().Property(w => w.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Worker>().Property(w => w.PhoneNumber).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Worker>().HasOne(w => w.Position).WithMany(p => p.Workers).HasForeignKey(w => w.PositionId);
            modelBuilder.Entity<Worker>().HasOne(w => w.Shop).WithMany(s => s.Workers).HasForeignKey(w => w.ShopId);

            modelBuilder.Entity<Shop>().Property(s => s.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Shop>().Property(s => s.Adress).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Shop>().HasOne(s => s.City).WithMany(c => c.Shops).HasForeignKey(s => s.CityId);
            modelBuilder.Entity<Shop>().HasMany(s => s.Products).WithMany(p => p.Shops);

            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<City>().HasOne(c => c.Country).WithMany(co => co.Cities).HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Country>().Property(co => co.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Discount);
            modelBuilder.Entity<Product>().Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.IsInStock).IsRequired();

            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(ca => ca.Products).HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().Property(ca => ca.Name).IsRequired().HasMaxLength(50);

            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedCategories();
            modelBuilder.SeedShops();
            modelBuilder.SeedPositions();
            modelBuilder.SeedWorkers();
            modelBuilder.SeedProducts();

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }

    class DbCRUD : ShopDBContext
    {
        ShopDBContext context = new ShopDBContext();
        public void ShowCategoryInfo()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",15} {"Name",35}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Categories.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35}");
            }
            Console.WriteLine();
        }
        public void ShowCityInfo()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",15} {"Name",35} {"CountryId",15}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Cities.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35}{i.CountryId,15}");
            }
            Console.WriteLine();
        }
        public void ShowCountryInfo()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",15} {"Name",35}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Countries.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35}");
            }
            Console.WriteLine();
        }
        public void ShowPositionInfo()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",15} {"Name",35}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Positions.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35}");
            }
            Console.WriteLine();
        }
        public void ShowProductInfo()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",15} {"Name",35} {"Price",15} {"Discount",15} {"Quantity",15} {"Is in Stock",15} {"CategoryId",15}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Products.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35}{i.Price,15}{i.Discount,15}{i.Quantity,15}{i.IsInStock,15}{i.CategoryId,15}");
            }
            Console.WriteLine();
        }
        public void ShowShopInfo()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",15} {"Name",35} {"Adress",35} {"CityID",15} {"ParkingArea",15}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Shops.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35}{i.Adress,35}{i.CityId,15}{i.ParkingArea,15}");
            }
            Console.WriteLine();
        }
        public void ShowWorkerInfo()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",5} {"Name",25} {"Surname",25} {"Salary",15} {"Email",25} {"PhoneNumber",35} {"PositionId",15}{"ShopId",4}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Workers.ToList())
            {
                Console.WriteLine($"{i.Id,5} {i.Name,25}{i.Surname,25}{i.Salary,15}{i.Email,25}{i.PhoneNumber,35}{i.PositionId,15}{i.ShopId,4}");
            }
            Console.WriteLine();
        }
    }
}
