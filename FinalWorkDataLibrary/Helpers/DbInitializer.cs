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
                new SportType { Id = 2, Name = "Swimming" }
            );
        }
        public static void SeedSports(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().HasData(
                new Sport { Id = 1, Name = "100m Sprint", SportTypeId = 1 },
                new Sport { Id = 2, Name = "Freestyle Swimming", SportTypeId = 2 }
            );
        }
        public static void SeedAthelets(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>().HasData(
                new Athlete { Id = 1, Name = "Usain", Surname = "Bolt", CountryId = 2, SportId = 1, DateOfBirth = new DateTime(1986, 8, 21), PhotoPath = "test" },
                new Athlete { Id = 2, Name = "Michael", Surname = "Phelps", CountryId = 2, SportId = 2, DateOfBirth = new DateTime(1985, 6, 30), PhotoPath = "test" },
                new Athlete { Id = 3, Name = "Serhii", Surname = "Bubka", CountryId = 1, SportId = 1, DateOfBirth = new DateTime(1963, 12, 4), PhotoPath = "test" }
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
                new Result { Id = 3, OlympiadId = 1, AthleteId = 3, SportId = 1, MedalId = 2 }
            );
        }
    }
}
