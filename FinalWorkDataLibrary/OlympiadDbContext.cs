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
            while (true)
            {


                Console.Write("\n[ A ] - add Athlete\n[ B ] - add City\n[ C ] - add Country\n[ D ] - add Olympiad\n[ E ] - add Result\n[ F ] - add Sport"); var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.A)
                {
                    Console.Write("\nEnter Name: ");string name = Console.ReadLine()!;
                    Console.Write("Enter Surname: ");string surname = Console.ReadLine()!;
                    Console.Write("Enter DateOfBirth(DD-MM-YYYY): "); DateTime date =  DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Enter CountryId: ");int countryId = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter SportId: ");int sportId = int.Parse(Console.ReadLine()!);
                    context.Athletes.Add(new Athlete()
                    {
                        Name = name,
                        Surname = surname,
                        DateOfBirth = date,
                        PhotoPath = "test",
                        CountryId = countryId,
                        SportId = sportId
                    });
                    Console.WriteLine("\nAthlete Added!");
                    break;
                }
                else if (key.Key == ConsoleKey.B)
                {
                    Console.Write("\nEnter Name: "); string name = Console.ReadLine()!;
                    Console.Write("Enter CountryId: "); int countryId = int.Parse(Console.ReadLine()!);
                    context.Cities.Add(new City()
                    {
                        Name = name,
                        CountryId = countryId
                    });
                    Console.WriteLine("\nCity Added!");
                    break;
                }
                else if (key.Key == ConsoleKey.C)
                {
                    Console.Write("\nEnter Name: "); string name = Console.ReadLine()!;
                    context.Countries.Add(new Country()
                    {
                        Name = name
                    });
                    Console.WriteLine("\nCountry Added!");
                    break;
                }
                else if (key.Key == ConsoleKey.D)
                {
                    Console.Write("\nEnter Name: "); string name = Console.ReadLine()!;
                    Console.Write("Enter Year: "); int year = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter OlympiadId: "); int olympId = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter CountryId: "); int countryId = int.Parse(Console.ReadLine()!);
                    context.Olympiads.Add(new Olympiad()
                    {
                        Name = name,
                        Year = year,
                        OlympiadTypeId = olympId,
                        CountryId = countryId
                    });
                    Console.WriteLine("\nOlympiad Added!");
                    break;
                }
                else if (key.Key == ConsoleKey.E)
                {
                    Console.Write("\nEnter OlympiadId: "); int olympId = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter MedalId: "); int medalId = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter AthleteId: "); int athleteId = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter SportId: "); int sportId = int.Parse(Console.ReadLine()!);
                    context.Results.Add(new Result()
                    {
                        OlympiadId = olympId,
                        MedalId = medalId,
                        AthleteId = athleteId,
                        SportId = sportId
                    });
                    Console.WriteLine("\nResult Added!");
                    break;
                }
                else if (key.Key == ConsoleKey.F)
                {
                    Console.Write("\nEnter Name: "); string name = Console.ReadLine()!;
                    Console.Write("Enter SportTypeId: "); int sportId = int.Parse(Console.ReadLine()!);
                    context.Sports.Add(new Sport()
                    {
                        Name = name,
                        SportTypeId = sportId
                    });
                    Console.WriteLine("\nSport Added!");
                    break;
                }
                else { Console.WriteLine("Wrong Key!\n"); }
            }
            context.SaveChanges();
        }
        public void Update() {
            bool exit = false;
            while (true)
            {

                Console.Write("\n[ A ] - update Athlete\n[ B ] - update City\n[ C ] - update Country\n[ D ] - update Olympiad\n[ E ] - update Result\n[ F ] - update Sport"); var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.A)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Athletes)
                        {
                            if (a.Id == kId)
                            {
                                Console.WriteLine("Athlete Selected!\n");
                                Console.Write("Enter Name: "); string name = Console.ReadLine()!;
                                Console.Write("Enter Surname: "); string surname = Console.ReadLine()!;
                                Console.Write("Enter DateOfBirth(DD-MM-YYYY): "); DateTime date = DateTime.Parse(Console.ReadLine()!);
                                Console.Write("Enter CountryId: "); int countryId = int.Parse(Console.ReadLine()!);
                                Console.Write("Enter SportId: "); int sportId = int.Parse(Console.ReadLine()!);
                                context.Athletes.Update(new Athlete()
                                {
                                    Name = name,
                                    Surname = surname,
                                    DateOfBirth = date,
                                    PhotoPath = "test",
                                    CountryId = countryId,
                                    SportId = sportId
                                });
                                Console.WriteLine("\nAthlete Changed!");
                                exit = true;
                               
                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        
                        Console.WriteLine($"\nAthlete with {kId} Id wasn't found!\n");
                    }                                   
                }
                else if (key.Key == ConsoleKey.B)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Cities)
                        {
                            if (a.Id == kId)
                            {
                                Console.WriteLine("City Selected!\n");
                                Console.Write("Enter Name: "); string name = Console.ReadLine()!;
                                Console.Write("Enter CountryId: "); int countryId = int.Parse(Console.ReadLine()!);
                                context.Cities.Update(new City()
                                {
                                    Name = name,
                                    CountryId = countryId
                                });
                                Console.WriteLine("\nCity Changed!");
                                exit = true;
                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nCity with {kId} Id wasn't found!\n");
                    }
                   
                }

                else if (key.Key == ConsoleKey.C)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Countries)
                        {
                            if (a.Id == kId)
                            {
                                Console.WriteLine("Country Selected!\n");
                                Console.Write("Enter Name: "); string name = Console.ReadLine()!;
                                context.Countries.Update(new Country()
                                {
                                    Name = name
                                });
                                Console.WriteLine("\nCountry Changed!");
                                exit = true;

                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nCountry with {kId} Id wasn't found!\n");
                    }                 
                }
                else if (key.Key == ConsoleKey.D)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Olympiads)
                        {
                            if (a.Id == kId)
                            {
                                Console.WriteLine("Olympiad Selected!\n");
                                Console.Write("Enter Name: "); string name = Console.ReadLine()!;
                                Console.Write("Enter Year: "); int year = int.Parse(Console.ReadLine()!);
                                Console.Write("Enter OlympiadId: "); int olympId = int.Parse(Console.ReadLine()!);
                                Console.Write("Enter CountryId: "); int countryId = int.Parse(Console.ReadLine()!);
                                context.Olympiads.Update(new Olympiad()
                                {
                                    Name = name,
                                    Year = year,
                                    OlympiadTypeId = olympId,
                                    CountryId = countryId
                                });
                                Console.WriteLine("\nOlympiad Changed!");
                                exit = true;

                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nOlympiad with {kId} Id wasn't found!\n");
                    }                
                }
                else if (key.Key == ConsoleKey.E)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Results)
                        {
                            if (a.Id == kId)
                            {
                                Console.WriteLine("Result Selected!\n");
                                Console.Write("Enter OlympiadId: "); int olympId = int.Parse(Console.ReadLine()!);
                                Console.Write("Enter MedalId: "); int medalId = int.Parse(Console.ReadLine()!);
                                Console.Write("Enter AthleteId: "); int athleteId = int.Parse(Console.ReadLine()!);
                                Console.Write("Enter SportId: "); int sportId = int.Parse(Console.ReadLine()!);
                                context.Results.Update(new Result()
                                {
                                    OlympiadId = olympId,
                                    MedalId = medalId,
                                    AthleteId = athleteId,
                                    SportId = sportId
                                });
                                Console.WriteLine("\nResult Changed!");
                                exit = true;
                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nResult with {kId} Id wasn't found!\n");
                    }

                }
                else if (key.Key == ConsoleKey.F)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Sports)
                        {
                            if (a.Id == kId)
                            {
                                Console.WriteLine("Sport Selected!\n");
                                Console.Write("Enter Name: "); string name = Console.ReadLine()!;
                                Console.Write("Enter SportTypeId: "); int sportId = int.Parse(Console.ReadLine()!);
                                context.Sports.Update(new Sport()
                                {
                                    Name = name,
                                    SportTypeId = sportId
                                });
                                Console.WriteLine("\nSport Changed!");
                                exit = true;
                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nSport with {kId} Id wasn't found!\n");
                    }
                }
                else { Console.WriteLine("Wrong Key!\n"); }
            }
        }
        public void Delete() {
            bool exit = false;
            while (true)
            {


                Console.Write("\n[ A ] - delete Athlete\n[ B ] - delete City\n[ C ] - delete Country\n[ D ] - delete Olympiad\n[ E ] - delete Result\n[ F ] - delete Sport"); var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.A)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Athletes)
                        {
                            if (a.Id == kId)
                            {
                                context.Athletes.Remove(a);
                                Console.WriteLine("\nAthlete was Removed!");
                                exit = true;

                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nAthlete with {kId} Id wasn't found!\n");
                    }
                }
                else if (key.Key == ConsoleKey.B)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Cities)
                        {
                            if (a.Id == kId)
                            {
                                context.Cities.Remove(a);
                                Console.WriteLine("\nCity was Removed!");
                                exit = true;

                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nCity with {kId} Id wasn't found!\n");
                    }

                }

                else if (key.Key == ConsoleKey.C)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Countries)
                        {
                            if (a.Id == kId)
                            {
                                context.Countries.Remove(a);
                                Console.WriteLine("\nCountry was Removed!");
                                exit = true;

                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nCountry with {kId} Id wasn't found!\n");
                    }
                }
                else if (key.Key == ConsoleKey.D)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Olympiads)
                        {
                            if (a.Id == kId)
                            {
                                context.Olympiads.Remove(a);
                                Console.WriteLine("\nOlympiad was Removed!");
                                exit = true;

                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nOlympiad with {kId} Id wasn't found!\n");
                    }
                }
                else if (key.Key == ConsoleKey.E)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Results)
                        {
                            if (a.Id == kId)
                            {
                                context.Results.Remove(a);
                                Console.WriteLine("\nResult was Removed!");
                                exit = true;

                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nResult with {kId} Id wasn't found!\n");
                    }

                }
                else if (key.Key == ConsoleKey.F)
                {
                    while (true)
                    {
                        Console.Write("\nEnter ID: "); int kId = int.Parse(Console.ReadLine()!);
                        foreach (var a in context.Sports)
                        {
                            if (a.Id == kId)
                            {
                                context.Sports.Remove(a);
                                Console.WriteLine("\nSport was Removed!");
                                exit = true;

                            }
                        }
                        if (exit == true) { context.SaveChanges(); return; }
                        Console.WriteLine($"\nSport with {kId} Id wasn't found!\n");
                    }
                }
                else { Console.WriteLine("Wrong Key!\n"); }
            }
        }

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

        public void AsciiArt()
        {
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*-%@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@:.*@@@@#@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@*. -@@@%-#@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@-  :#@@+.+@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@#.  .=@%:.-#@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@-   .-#+. :*@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@#*-..             .=:  .=%@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@*:                    ..    :#@@@@@@@@@@");
            Console.WriteLine("@@@@@@@%-                              .+@@@@@@@@@");
            Console.WriteLine("@@@@@@+::--:..                           -%@@@@@@@");
            Console.WriteLine("@@@@@@@@%+.                               .*@@@@@@");
            Console.WriteLine("@@@@@@#:                            ...     =@@@@@");
            Console.WriteLine("@@@@%:                             .+%-.     -%@@@");
            Console.WriteLine("@@@* .+@@+.   .%@@@@");
            Console.WriteLine("@@=.                                .:*@#:  +@@@@@");
            Console.WriteLine("@+.              :-.  +@@=            ......:%@@@@");
            Console.WriteLine("%.             :#*:. *@=..                   .*@@@");
            Console.WriteLine("=             =%%-. -%@@%%%-                  ...-");
            Console.WriteLine(".            -%@#:  -@@@@#...:.                  +");
            Console.WriteLine(".           .*@@%-  .%@@@@@@@@@@@@%*:           .@");
            Console.WriteLine(".   .-      -#@@@=.  :%@@@@@@@@@@@@@@%+.        *@");
            Console.WriteLine("= .-@%.     -#@@@@-.  ...:#@@@@@@@@@@@@%=.    .+@@");
            Console.WriteLine("%.:@@@=     :*@%=:.. ...  .-%@%@@@@@@@@@@+. :#@@@@");
            Console.WriteLine("@**@@@%:    .=@@@@@@@@@%:  .....-*@@@@@@@@*:#@@@@@");
            Console.WriteLine("@@@@@@@#:    .*@@@@@@@@@+        .:+@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@%-    .+@@@@@*-.:=+*#%+.   .:*@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@+.   .=%@@@@%@@@@@@@@%=.   .-%@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@%+:   .=%@@@@@@@@@@@@@#:   :*@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@#=:. .:+#@@@@@@@@@@@%=-*@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@%*+-::.-@@@@@@@@@@@@@@@@@@@@@@@@@");
        }


    }
}
