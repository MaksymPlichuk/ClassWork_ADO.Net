using _08_DataLibrary.Entities;
using _08_DataLibrary.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _08_DataLibrary
{
    public class AirportDbContext : DbContext
    {
        //C       R    U       D 
        //Create Read Update Delede
        public AirportDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=AirportEF;
            Integrated Security=True;Connect Timeout=5;Encrypt=False;
            Trust Server Certificate=False;Application Intent=ReadWrite;
            Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airplane>()
                .Property(a => a.Model)
                .HasMaxLength(100)
                .IsRequired();


            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>().Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("FirstName");
            modelBuilder.Entity<Client>().Property(c => c.Lastname)
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.Entity<Client>().Property(c => c.Email)
              .IsRequired()
              .HasMaxLength(150);


            modelBuilder.Entity<Flight>().HasKey(f => f.Number);
            modelBuilder.Entity<Flight>().Property(c => c.ArrivalCity)
              .IsRequired()
              .HasMaxLength(100);
            modelBuilder.Entity<Flight>().Property(c => c.DepartureCity)
             .IsRequired()
             .HasMaxLength(100);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(c => c.Flights);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);


            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<City>().HasMany(c => c.Flights).WithOne(f => f.City).HasForeignKey(f=>f.CityId);
            modelBuilder.Entity<City>().HasOne(c=>c.Country).WithMany(co=>co.Cities).HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Country>().Property(co => co.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<AirplaneType>().Property(at => at.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AirplaneType>().HasMany(at => at.Airplanes).WithOne(a => a.AirplaneType).HasForeignKey(a => a.AirplaneTypeId);


            modelBuilder.SeedAirplaneTypes();
            modelBuilder.SeedAiplanes();     
            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedFlights();



        }

        public DbSet<AirplaneType> AirplaneTypes { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        
        
        
        
    }
}
