using FinalWorkDataLibrary.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorkDataLibrary.Entities
{
    public class OlympiadDbContext:DbContext
    {
        public OlympiadDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=OlympiadEF;
            Integrated Security=True;Connect Timeout=5;Encrypt=False;
            Trust Server Certificate=False;Application Intent=ReadWrite;
            Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Athlete>().Property(a=>a.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Athlete>().Property(a=>a.Surname).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Athlete>().Property(a=>a.DateOfBirth).IsRequired();
            modelBuilder.Entity<Athlete>().HasOne(a => a.Country).WithMany(co => co.Athletes).HasForeignKey(a => a.CountryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Athlete>().HasOne(a => a.Sport).WithMany(s => s.Athletes).HasForeignKey(a => a.SportId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<City>().HasOne(c => c.Country).WithMany(co=>co.Cities).HasForeignKey(c => c.CountryId).OnDelete(DeleteBehavior.Restrict); //не дозволяє видаляти батька, якщо є дочірні записи.
            modelBuilder.Entity<City>().HasMany(c => c.Olympiads).WithOne(o=>o.City).HasForeignKey(o=>o.CityId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Country>().Property(co => co.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Country>().HasMany(co=>co.Olympiads).WithOne(o=>o.Country).HasForeignKey(o=>o.CountryId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Medal>().HasOne(m=>m.MedalType).WithMany(mt=>mt.Medals).HasForeignKey(m=>m.MedalTypeId);
            modelBuilder.Entity<Medal>().HasMany(m => m.Results).WithOne(r=>r.Medal).HasForeignKey(r=>r.MedalId);

            modelBuilder.Entity<MedalType>().Property(mt=>mt.Name).IsRequired().HasMaxLength(50);


            modelBuilder.Entity<Olympiad>().Property(o => o.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Olympiad>().Property(o => o.Year).IsRequired();

            modelBuilder.Entity<Olympiad>().HasOne(o => o.OlympiadType).WithMany(ot => ot.Olympiads).HasForeignKey(o => o.OlympiadTypeId);
            modelBuilder.Entity<Olympiad>().HasMany(o => o.SportTypes).WithMany(st => st.Olympiads);
            modelBuilder.Entity<Olympiad>().HasMany(o => o.Results).WithOne(r => r.Olympiad).HasForeignKey(r => r.OlympiadId);

            modelBuilder.Entity<OlympiadType>().Property(ot => ot.Name).IsRequired().HasMaxLength(50);


            modelBuilder.Entity<Sport>().Property(s => s.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Sport>().HasOne(s => s.SportType).WithMany(st => st.Sports).HasForeignKey(s => s.SportTypeId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SportType>().Property(st => st.Name).IsRequired().HasMaxLength(100);


            modelBuilder.Entity<Result>().HasOne(r => r.Athlete).WithMany(a => a.Results).HasForeignKey(r => r.AthleteId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Result>().HasOne(r => r.Sport).WithMany(s => s.Results).HasForeignKey(r => r.SportId).OnDelete(DeleteBehavior.Restrict);




            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedOlympiadTypes();
            modelBuilder.SeedOlympiads();
            modelBuilder.SeedSportTypes();
            modelBuilder.SeedSports();
            modelBuilder.SeedAthelets();
            modelBuilder.SeedMedalTypes();
            modelBuilder.SeedMedals();
            modelBuilder.SeedResults();



        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Medal> Medals { get; set; }
        public DbSet<MedalType> MedalTypes { get; set; }
        public DbSet<Olympiad> Olympiads { get; set; }
        public DbSet<OlympiadType> OlympiadTypes { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<SportType> SportTypes { get; set; }

    }
    public class Crud()
    {
        OlympiadDbContext context = new OlympiadDbContext();
        public void Add() {
        
        }
        public void Update() { }
        public void Delet() { }

        public void ShowContryResultInOlympiad()
        {
            var olympiads = context.Olympiads;
            foreach (var o in olympiads)
            {
                Console.WriteLine($"{o.Id}\t{o.Name}");
            }
            Console.WriteLine();
            bool flag = true;

            while (flag)
            {
                Console.Write("Choose Olympiad by Id to see countries results: "); int choise = int.Parse(Console.ReadLine()!);
                foreach (var o in olympiads)
                {
                    if (o.Id==choise)
                    {
                        Console.WriteLine($"{o.Name} is Picked!\n");
                        flag=false;
                    }
                }
                Console.WriteLine("Wrong ID!");
            }

           // var res = context.Countries.Include(c=>c.Athletes).Where(c=>c.);
            //var countRes = context.Countries.Include(o=>o.Olympiads).Count(c => c.Name);

            foreach (var c in context.Countries)
            {
                Console.WriteLine($"{c.Name}\t");
            }


        }


    }
}
