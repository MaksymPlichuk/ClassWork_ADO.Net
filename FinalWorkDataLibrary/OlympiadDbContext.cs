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

            context.Athletes.Add(new Athlete()
            {
                Name = Console.ReadLine()!,
                Surname = Console.ReadLine()!,
                //DateOfBirth = DateTime()

            });
            //TODO
            context.SaveChanges();
        }
        public void Update() { }
        public void Delete() { }

        private void ShowOlympInfo() {
            Console.WriteLine("All Olympiads:\n");
            var allinfo = context.Olympiads.Include(o => o.Country).Include(o => o.City);
            foreach (var i in allinfo)
            {
                Console.WriteLine($"{i.Id,5}{i.Name,35}{i.Year,15}{i.City.Name,25}{i.Country.Name,25}");
            }
            Console.WriteLine();
        }
        private int PickOlympiad()
        {
            int choise;
            while (true)
            {
                Console.Write("Choose Olympiad by Id to see countries results: "); choise = int.Parse(Console.ReadLine()!);
                foreach (var o in context.Olympiads)
                {
                    if (o.Id == choise)
                    {
                        Console.WriteLine($"{o.Name} is Picked!\n");
                        return choise;
                    }
                }
                Console.WriteLine("Wrong ID!");
            }
        }
        public void ShowContryResultInOlympiad()
        {
            ShowOlympInfo();

            while (true)
            {
                Console.WriteLine("\nPress [ A ] - to show all time results\nPress [ B ] - to show results for certain olympiad\n");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.A)
                {
                    var medalAllTimeCount = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Country)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.MedalId != null).GroupBy(r => r.Athlete.Country.Name)
                         .Select(g => new
                         {
                             CountryName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count()
                         })
                         .OrderByDescending(x => x.GoldMedals)
                         .ThenByDescending(x => x.SilverMedals)
                         .ThenByDescending(x => x.BronzeMedals)
                         .ToList();

                    Console.WriteLine($"{"Country",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in medalAllTimeCount)
                    {
                        Console.WriteLine($"{i.CountryName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                    }
                    return;
                }
                else if (key.Key==ConsoleKey.B)
                {
                    
                    int choise = PickOlympiad();

                    var medalCount = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Country)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.OlympiadId == choise && r.MedalId != null).GroupBy(r => r.Athlete.Country.Name)
                         .Select(g => new
                         {
                             CountryName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count()
                         })
                         .OrderByDescending(x => x.GoldMedals)
                         .ThenByDescending(x => x.SilverMedals)
                         .ThenByDescending(x => x.BronzeMedals)
                         .ToList();

                    Console.WriteLine($"{"Country",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in medalCount)
                    {
                        Console.WriteLine($"{i.CountryName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                    }
                    return;
                }
                else { Console.WriteLine("Wrong Key!"); }
            }

        }
        public void ShowMedalistsFromOlympiad()
        {
            ShowOlympInfo();
            while (true)
            {
                Console.WriteLine("\nPress [ A ] - to show all time results\nPress [ B ] - to show results for certain olympiad\n"); var key= Console.ReadKey(true);
                if (key.Key==ConsoleKey.A)
                {

                    var allTimeMedalist = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Sport).ThenInclude(s => s.SportType)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.MedalId != null).GroupBy(r => r.Athlete.Sport.SportType.Name)
                         .Select(g => new
                         {
                             SportName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count(),

                             Athletes = g.Select(a => new
                             {
                                 Name = a.Athlete.Name,
                                 Surname = a.Athlete.Surname
                             }).ToList()
                         })
                         .OrderByDescending(x => x.GoldMedals)
                         .ThenByDescending(x => x.SilverMedals)
                         .ThenByDescending(x => x.BronzeMedals)
                         .ToList();

                    Console.WriteLine($"{"Full Name",15}{"Sport",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in allTimeMedalist)
                    {
                        foreach (var a in i.Athletes)
                        {
                            Console.WriteLine($"{a.Name+" "+a.Surname,15}{i.SportName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                        }                        
                    }
                    return;

                }
                else if (key.Key == ConsoleKey.B) {
                    var choise = PickOlympiad();
                    var olympMedalists = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Sport).ThenInclude(s => s.SportType)
                        .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.OlympiadId==choise && r.MedalId != null).GroupBy(r => r.Athlete.Sport.SportType.Name)
                        .Select(g => new
                        {
                            SportName = g.Key,
                            GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                            SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                            BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                            TotalMedals = g.Count(),

                            Athletes = g.Select(a => new
                            {
                                Name = a.Athlete.Name,
                                Surname = a.Athlete.Surname
                            }).ToList()
                        })
                         .OrderByDescending(x => x.GoldMedals)
                         .ThenByDescending(x => x.SilverMedals)
                         .ThenByDescending(x => x.BronzeMedals)
                         .ToList();
                    Console.WriteLine($"{"Full Name",15}{"Sport",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in olympMedalists)
                    {
                        foreach (var a in i.Athletes)
                        {
                            Console.WriteLine($"{a.Name + " " + a.Surname,15}{i.SportName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                        }
                    }
                    return;
                }
                else { Console.WriteLine("Wrong Key!"); }
            }
        }

        public void ShowTopContryGoldMedals()
        {
            ShowOlympInfo();

            while (true)
            {
                Console.WriteLine("\nPress [ A ] - to show all time results\nPress [ B ] - to show results for certain olympiad\n");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.A)
                {
                    var medalAllTimeCount = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Country)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.MedalId != null).GroupBy(r => r.Athlete.Country.Name)
                         .Select(g => new
                         {
                             CountryName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count()
                         })
                         .OrderByDescending(x => x.GoldMedals)
                         .ThenByDescending(x => x.SilverMedals)
                         .ThenByDescending(x => x.BronzeMedals).Take(1)
                         .ToList();

                    Console.WriteLine($"{"Country",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in medalAllTimeCount)
                    {
                        Console.WriteLine($"{i.CountryName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                    }
                    return;
                }
                else if (key.Key == ConsoleKey.B)
                {

                    int choise = PickOlympiad();

                    var medalCount = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Country)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.OlympiadId == choise && r.MedalId != null).GroupBy(r => r.Athlete.Country.Name)
                         .Select(g => new
                         {
                             CountryName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count()
                         })
                         .OrderByDescending(x => x.GoldMedals)
                         .ThenByDescending(x => x.SilverMedals)
                         .ThenByDescending(x => x.BronzeMedals).Take(1)
                         .ToList();

                    Console.WriteLine($"{"Country",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in medalCount)
                    {
                        Console.WriteLine($"{i.CountryName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                    }
                    return;
                }
                else { Console.WriteLine("Wrong Key!"); }
            }

        }

        public void ShowTopContryMedals()
        {
            ShowOlympInfo();

            while (true)
            {
                Console.WriteLine("\nPress [ A ] - to show all time results\nPress [ B ] - to show results for certain olympiad\n");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.A)
                {
                    var medalAllTimeCount = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Country)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.MedalId != null).GroupBy(r => r.Athlete.Country.Name)
                         .Select(g => new
                         {
                             CountryName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count()
                         })
                         .OrderByDescending(x => x.TotalMedals).Take(1)
                         .ToList();

                    Console.WriteLine($"{"Country",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in medalAllTimeCount)
                    {
                        Console.WriteLine($"{i.CountryName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                    }
                    return;
                }
                else if (key.Key == ConsoleKey.B)
                {

                    int choise = PickOlympiad();

                    var medalCount = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Country)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.OlympiadId == choise && r.MedalId != null).GroupBy(r => r.Athlete.Country.Name)
                         .Select(g => new
                         {
                             CountryName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count()
                         })
                         .OrderByDescending(x => x.TotalMedals).Take(1)
                         .ToList();

                    Console.WriteLine($"{"Country",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in medalCount)
                    {
                        Console.WriteLine($"{i.CountryName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                    }
                    return;
                }
                else { Console.WriteLine("Wrong Key!"); }
            }

        }

        public void ShowTopMedalists()
        {

          var allTimeMedalist = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Sport).ThenInclude(s => s.SportType)
               .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.MedalId != null).GroupBy(r => r.Athlete.Sport.SportType.Name)
               .Select(g => new
               {
                   SportName = g.Key,
                   GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                   SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                   BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                   TotalMedals = g.Count(),

                   Athletes = g.Select(a => new
                   {
                       Name = a.Athlete.Name,
                       Surname = a.Athlete.Surname
                   }).ToList()
               })
               .OrderByDescending(x => x.GoldMedals)
               .ThenByDescending(x => x.SilverMedals)
               .ThenByDescending(x => x.BronzeMedals).Take(1)
               .ToList();

          Console.WriteLine($"{"Full Name",15}{"Sport",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
          Console.WriteLine("----------------------------------------------------------------------------");
          foreach (var i in allTimeMedalist)
          {
              foreach (var a in i.Athletes)
              {
                  Console.WriteLine($"{a.Name + " " + a.Surname,15}{i.SportName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
              }
          }
          return;
        }

        public void ShowTopCountryHost()
        {
            var topHost = context.Olympiads.Include(o => o.Country).GroupBy(o => o.Country.Name)
                .Select(g => new
                {
                    TopCountry = g.Key,
                    NumberOfHosts = g.Count()
                })
                .OrderByDescending(x => x.NumberOfHosts).Take(1).ToList();

            Console.WriteLine($"{"Country",15} {"Number Of Hosts",15}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in topHost)
            {
              Console.WriteLine($"{i.TopCountry,15}{i.NumberOfHosts,15}");
            }
            return;
        }
        public void CountryPerfStatictics()
        {
            ShowOlympInfo();

            while (true)
            {
                Console.WriteLine("\nPress [ A ] - to show all time results\nPress [ B ] - to show results for certain olympiad\n");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.A)
                {
                    var medalAllTimeCount = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Country).Include(r => r.Athlete).ThenInclude(a => a.Sport).ThenInclude(s => s.SportType)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.MedalId != null).GroupBy(r => r.Athlete.Country.Name)
                         .Select(g => new
                         {
                             CountryName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count(),
                             Athletes = g.Select(a => new
                             {
                                 Name = a.Athlete.Name,
                                 Surname = a.Athlete.Surname,
                                 Sport = a.Athlete.Sport
                             }).ToList()
                         })
                         .OrderByDescending(x => x.GoldMedals)
                         .ThenByDescending(x => x.SilverMedals)
                         .ThenByDescending(x => x.BronzeMedals)
                         .ToList();

                    Console.WriteLine($"{"Country",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in medalAllTimeCount)
                    {
                        Console.WriteLine($"{i.CountryName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                        Console.WriteLine("----------------------------------------------------------------------------");
                        Console.WriteLine($"{"Full Name",40} {"Sport Name",35} {"Sport Type",35} ");
                        Console.WriteLine("   -----     -----     -----     -----     -----     -----     -----     -----     -----     -----     -----  ");
                        foreach (var a in i.Athletes)
                        {
                            Console.WriteLine($"{a.Name + " " + a.Surname,40}{a.Sport.Name,35}{a.Sport.SportType.Name,35} ");
                        }
                        Console.WriteLine("----------------------------------------------------------------------------");
                    }
                    return;
                }
                else if (key.Key == ConsoleKey.B)
                {

                    int choise = PickOlympiad();

                    var medalCount = context.Results.Include(r => r.Athlete).ThenInclude(a => a.Country).Include(r=>r.Athlete).ThenInclude(a=>a.Sport).ThenInclude(s=>s.SportType)
                         .Include(r => r.Medal).ThenInclude(m => m.MedalType).Where(r => r.OlympiadId == choise && r.MedalId != null).GroupBy(r => r.Athlete.Country.Name)
                         .Select(g => new
                         {
                             CountryName = g.Key,
                             GoldMedals = g.Count(r => r.Medal.MedalType.Name == "Gold"),
                             SilverMedals = g.Count(r => r.Medal.MedalType.Name == "Silver"),
                             BronzeMedals = g.Count(r => r.Medal.MedalType.Name == "Bronze"),
                             TotalMedals = g.Count(),
                              Athletes = g.Select(a => new
                             {
                                 Name = a.Athlete.Name,
                                 Surname = a.Athlete.Surname,
                                 Sport = a.Athlete.Sport
                             }).ToList()
                         })
                         .OrderByDescending(x => x.GoldMedals)
                         .ThenByDescending(x => x.SilverMedals)
                         .ThenByDescending(x => x.BronzeMedals)
                         .ToList();

                    Console.WriteLine($"{"Country",15} {"Gold",15} {"Silver",15}{"Bronze",15}{"Total Medals",15} ");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    foreach (var i in medalCount)
                    {
                        Console.WriteLine($"{i.CountryName,15} {i.GoldMedals,15}{i.SilverMedals,15}{i.BronzeMedals,15}{i.TotalMedals,15}");
                        Console.WriteLine("----------------------------------------------------------------------------");
                        Console.WriteLine($"{"Full Name",40} {"Sport Name",35} {"Sport Type",35} ");
                        Console.WriteLine("   -----     -----     -----     -----     -----     -----     -----     -----     -----     -----     -----  ");
                        foreach (var a in i.Athletes)
                        {
                            Console.WriteLine($"{a.Name + " " + a.Surname,40}{a.Sport.Name,35}{a.Sport.SportType.Name,35} ");
                        }
                        Console.WriteLine("----------------------------------------------------------------------------");
                    }
                    return;
                }
                else { Console.WriteLine("Wrong Key!"); }
            }
        }
    }
}
