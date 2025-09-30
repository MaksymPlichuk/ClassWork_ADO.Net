using FinalWorkDataLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorkDataLibrary.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "USA" },
                new Country { Id = 2, Name = "Germany" },
                new Country { Id = 3, Name = "Japan" },
                new Country { Id = 4, Name = "Ukraine" }
                );
        }
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Los Angeles", CountryId = 1 },
                new City { Id = 2, Name = "Berlin", CountryId = 2 },
                new City { Id = 3, Name = "Tokyo", CountryId = 3 },
                new City { Id = 4, Name = "Kyiv", CountryId = 4 }
                );
        }
        public static void SeedOlympiadTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OlympiadType>().HasData(
                new OlympiadType { Id = 1, Name = "Summer" },
                new OlympiadType { Id = 2, Name = "Winter" }
            );
        }
        public static void SeedOlympiads(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Olympiad>().HasData(
                new Olympiad { Id = 1, Name = "Los Angeles 2028", Year = 2028, OlympiadTypeId = 1, CountryId = 1, CityId = 1 },
                new Olympiad { Id = 2, Name = "Berlin 1936", Year = 1936, OlympiadTypeId = 1, CountryId = 2, CityId = 2 },
                new Olympiad { Id = 3, Name = "Tokyo 2020", Year = 2020, OlympiadTypeId = 1, CountryId = 3, CityId = 3 },
                new Olympiad { Id = 4, Name = "Kyiv 2032", Year = 2032, OlympiadTypeId = 2, CountryId = 4, CityId = 4 }
            );
        }
        public static void SeedSportTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportType>().HasData(
                new SportType { Id = 1, Name = "Athletics" },
                new SportType { Id = 2, Name = "Swimming" },
                new SportType { Id = 3, Name = "Cycling" },
                new SportType { Id = 4, Name = "Gymnastics" },
                new SportType { Id = 5, Name = "Boxing" },
                new SportType { Id = 6, Name = "Wrestling" },
                new SportType { Id = 7, Name = "Rowing" }
            );
        }
        public static void SeedSports(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().HasData(
                new Sport { Id = 1, Name = "100m Sprint", SportTypeId = 1 },
                new Sport { Id = 2, Name = "Freestyle Swimming", SportTypeId = 2 },
                new Sport { Id = 3, Name = "Cycling BMX Racing", SportTypeId = 3 },
                new Sport { Id = 4, Name = "Artistic Gymnastics", SportTypeId = 4 },
                new Sport { Id = 5, Name = "Boxing Lightweight", SportTypeId = 5 },
                new Sport { Id = 6, Name = "Greco-Roman Wrestling", SportTypeId = 6 },
                new Sport { Id = 7, Name = "Rowing Single Sculls", SportTypeId = 7 }
            );
        }
        public static void SeedAthelets(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>().HasData(
                new Athlete { Id = 1, Name = "Usain", Surname = "Bolt", CountryId = 2, SportId = 1, DateOfBirth = new DateTime(1986, 8, 21), PhotoPath = "test" },
                new Athlete { Id = 2, Name = "Michael", Surname = "Phelps", CountryId = 2, SportId = 2, DateOfBirth = new DateTime(1985, 6, 30), PhotoPath = "test" },
                new Athlete { Id = 3, Name = "Serhii", Surname = "Bubka", CountryId = 1, SportId = 1, DateOfBirth = new DateTime(1963, 12, 4), PhotoPath = "test" },
                new Athlete { Id = 4, Name = "Simone", Surname = "Biles", CountryId = 1, SportId = 4, DateOfBirth = new DateTime(1997, 3, 14), PhotoPath = "test" },
                new Athlete { Id = 5, Name = "Oleksandr", Surname = "Usyk", CountryId = 4, SportId = 5, DateOfBirth = new DateTime(1987, 1, 17), PhotoPath = "test" },
                new Athlete { Id = 6, Name = "Katie", Surname = "Ledecky", CountryId = 1, SportId = 2, DateOfBirth = new DateTime(1997, 3, 17), PhotoPath = "test" },
                new Athlete { Id = 7, Name = "Chris", Surname = "Hoy", CountryId = 2, SportId = 3, DateOfBirth = new DateTime(1976, 3, 23), PhotoPath = "test" },
                new Athlete { Id = 8, Name = "Yana", Surname = "Klochkova", CountryId = 4, SportId = 2, DateOfBirth = new DateTime(1982, 8, 7), PhotoPath = "test" },
                new Athlete { Id = 9, Name = "Alexander", Surname = "Karelin", CountryId = 2, SportId = 6, DateOfBirth = new DateTime(1967, 9, 19), PhotoPath = "test" },
                new Athlete { Id = 10, Name = "Steve", Surname = "Redgrave", CountryId = 2, SportId = 7, DateOfBirth = new DateTime(1962, 3, 23), PhotoPath = "test" },
                new Athlete { Id = 11, Name = "Andriy", Surname = "Shevchenko", CountryId = 4, SportId = 1, DateOfBirth = new DateTime(1976, 9, 29), PhotoPath = "test" },
                new Athlete { Id = 12, Name = "Natalie", Surname = "Coughlin", CountryId = 1, SportId = 2, DateOfBirth = new DateTime(1982, 8, 23), PhotoPath = "test" },
                new Athlete { Id = 13, Name = "Jan", Surname = "Frodeno", CountryId = 2, SportId = 1, DateOfBirth = new DateTime(1981, 8, 18), PhotoPath = "test" },
                new Athlete { Id = 14, Name = "Kohei", Surname = "Uchimura", CountryId = 3, SportId = 4, DateOfBirth = new DateTime(1989, 1, 3), PhotoPath = "test" },
                new Athlete { Id = 15, Name = "Rulon", Surname = "Gardner", CountryId = 1, SportId = 6, DateOfBirth = new DateTime(1971, 8, 16), PhotoPath = "test" },
                new Athlete { Id = 16, Name = "Mykhailo", Surname = "Romanchuk", CountryId = 4, SportId = 2, DateOfBirth = new DateTime(1996, 8, 7), PhotoPath = "test" },
                new Athlete { Id = 17, Name = "Kristina", Surname = "Vilhauer", CountryId = 2, SportId = 3, DateOfBirth = new DateTime(1993, 12, 1), PhotoPath = "test" },
                new Athlete { Id = 18, Name = "Naoya", Surname = "Inoue", CountryId = 3, SportId = 5, DateOfBirth = new DateTime(1993, 4, 10), PhotoPath = "test" },
                new Athlete { Id = 19, Name = "Igor", Surname = "Tymoshenko", CountryId = 4, SportId = 7, DateOfBirth = new DateTime(1989, 11, 5), PhotoPath = "test" },
                new Athlete { Id = 20, Name = "Paul", Surname = "Tergat", CountryId = 2, SportId = 1, DateOfBirth = new DateTime(1969, 6, 17), PhotoPath = "test" }
            );
        }
        public static void SeedMedalTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedalType>().HasData(
                new MedalType { Id = 1, Name = "Gold" },
                new MedalType { Id = 2, Name = "Silver" },
                new MedalType { Id = 3, Name = "Bronze" }
            );
        }
        public static void SeedMedals(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medal>().HasData(
                new Medal { Id = 1, MedalTypeId = 1 },
                new Medal { Id = 2, MedalTypeId = 2 },
                new Medal { Id = 3, MedalTypeId = 3 }
            );
        }
        public static void SeedResults(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>().HasData(
                new Result { Id = 1, OlympiadId = 1, AthleteId = 1, SportId = 1, MedalId = 1 },
                new Result { Id = 2, OlympiadId = 2, AthleteId = 2, SportId = 2, MedalId = 1 },
                new Result { Id = 3, OlympiadId = 1, AthleteId = 3, SportId = 1, MedalId = 2 },
                new Result { Id = 4, OlympiadId = 3, AthleteId = 4, SportId = 4, MedalId = 1 },
                new Result { Id = 5, OlympiadId = 4, AthleteId = 5, SportId = 5, MedalId = 1 },
                new Result { Id = 6, OlympiadId = 3, AthleteId = 6, SportId = 2, MedalId = 1 },
                new Result { Id = 7, OlympiadId = 2, AthleteId = 7, SportId = 3, MedalId = 2 },
                new Result { Id = 8, OlympiadId = 4, AthleteId = 8, SportId = 2, MedalId = 3 },
                new Result { Id = 9, OlympiadId = 1, AthleteId = 9, SportId = 6, MedalId = 1 },
                new Result { Id = 10, OlympiadId = 2, AthleteId = 10, SportId = 7, MedalId = 1 },
                new Result { Id = 11, OlympiadId = 3, AthleteId = 11, SportId = 1, MedalId = 3 },
                new Result { Id = 12, OlympiadId = 4, AthleteId = 12, SportId = 2, MedalId = 2 },
                new Result { Id = 13, OlympiadId = 1, AthleteId = 13, SportId = 1, MedalId = 2 },
                new Result { Id = 14, OlympiadId = 2, AthleteId = 14, SportId = 4, MedalId = 1 },
                new Result { Id = 15, OlympiadId = 3, AthleteId = 15, SportId = 6, MedalId = 3 },
                new Result { Id = 16, OlympiadId = 4, AthleteId = 16, SportId = 2, MedalId = 1 },
                new Result { Id = 17, OlympiadId = 1, AthleteId = 17, SportId = 3, MedalId = 2 },
                new Result { Id = 18, OlympiadId = 2, AthleteId = 18, SportId = 5, MedalId = 1 },
                new Result { Id = 19, OlympiadId = 3, AthleteId = 19, SportId = 7, MedalId = 3 },
                new Result { Id = 20, OlympiadId = 4, AthleteId = 20, SportId = 1, MedalId = 2 }
            );
        }
    }
}
