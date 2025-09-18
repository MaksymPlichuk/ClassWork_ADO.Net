using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_IntroToEntityFramework
{
    class MusicCollectionDBContext : DbContext
    {
        public MusicCollectionDBContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=MusicCollectionEF;
                Integrated Security=True;Connect Timeout=5;
                Encrypt=False;Trust Server Certificate=False;
                Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "USA" },
                new Country { Id = 2, Name = "UK" },
                new Country { Id = 3, Name = "Canada" },
                new Country { Id = 4, Name = "Germany" },
                new Country { Id = 5, Name = "France" },
                new Country { Id = 6, Name = "Italy" },
                new Country { Id = 7, Name = "Spain" },
                new Country { Id = 8, Name = "Jamaica" },
                new Country { Id = 9, Name = "Japan" },
                new Country { Id = 10, Name = "Australia" }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "The Beatles", Surname = "", CountryId = 2 },
                new Artist { Id = 2, Name = "Eminem", Surname = "Mathers", CountryId = 1 },
                new Artist { Id = 3, Name = "Taylor", Surname = "Swift", CountryId = 1 },
                new Artist { Id = 4, Name = "Miles", Surname = "Davis", CountryId = 1 },
                new Artist { Id = 5, Name = "Wolfgnag", Surname = "Mozart", CountryId = 9 },
                new Artist { Id = 6, Name = "Daft", Surname = "Punk", CountryId = 5 },
                new Artist { Id = 7, Name = "Bob", Surname = "Marley", CountryId = 8 },
                new Artist { Id = 8, Name = "Metallica", Surname = "", CountryId = 1 },
                new Artist { Id = 9, Name = "B.B. King", Surname = "", CountryId = 1 },
                new Artist { Id = 10, Name = "Ed", Surname = "Sheeran", CountryId = 2 }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Rock" },
                new Genre { Id = 2, Name = "Pop" },
                new Genre { Id = 3, Name = "Jazz" },
                new Genre { Id = 4, Name = "Hip-Hop" },
                new Genre { Id = 5, Name = "Classical" },
                new Genre { Id = 6, Name = "Electronic" },
                new Genre { Id = 7, Name = "Reggae" },
                new Genre { Id = 8, Name = "Metal" },
                new Genre { Id = 9, Name = "Blues" },
                new Genre { Id = 10, Name = "Folk" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { Id = 1, Name = "Abbey Road", Year = new DateTime(1969, 9, 26), GenreId = 1 },
                new Album { Id = 2, Name = "The Marshall Mathers LP", Year = new DateTime(2000, 5, 23), GenreId = 4 },
                new Album { Id = 3, Name = "1989", Year = new DateTime(2014, 10, 27), GenreId = 2 },
                new Album { Id = 4, Name = "Kind of Blue", Year = new DateTime(1959, 8, 17), GenreId = 3 },
                new Album { Id = 5, Name = "Requiem", Year = new DateTime(1791, 12, 5), GenreId = 5 },
                new Album { Id = 6, Name = "Discovery", Year = new DateTime(2001, 3, 12), GenreId = 6 },
                new Album { Id = 7, Name = "Legend", Year = new DateTime(1984, 5, 8), GenreId = 7 },
                new Album { Id = 8, Name = "Master of Puppets", Year = new DateTime(1986, 3, 3), GenreId = 8 },
                new Album { Id = 9, Name = "Live at the Regal", Year = new DateTime(1965, 11, 21), GenreId = 9 },
                new Album { Id = 10, Name = "Divide", Year = new DateTime(2017, 3, 3), GenreId = 2 },
                new Album { Id = 11, Name = "The Eminem Show", Year = new DateTime(2002, 5, 26), GenreId = 4 },
                new Album { Id = 12, Name = "Encore", Year = new DateTime(2004, 11, 12), GenreId = 4 },
                new Album { Id = 13, Name = "Relapse", Year = new DateTime(2009, 5, 15), GenreId = 2 },
                new Album { Id = 14, Name = "Sgt. Pepper's Lonely Hearts Club Band", Year = new DateTime(1967, 6, 1), GenreId = 1 },
                new Album { Id = 15, Name = "Revolver", Year = new DateTime(1966, 8, 5), GenreId = 1 },
                new Album { Id = 16, Name = "Fearless", Year = new DateTime(2008, 11, 11), GenreId = 2 }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Name = "Come Together", AlbumId = 1, Length = 259 },
                new Song { Id = 2, Name = "Lose Yourself", AlbumId = 2, Length = 326 },
                new Song { Id = 3, Name = "Blank Space", AlbumId = 3, Length = 231 },
                new Song { Id = 4, Name = "So What", AlbumId = 4, Length = 545 },
                new Song { Id = 5, Name = "Lacrimosa", AlbumId = 5, Length = 720 },
                new Song { Id = 6, Name = "Harder Better Faster Stronger", AlbumId = 6, Length = 224 },
                new Song { Id = 7, Name = "No Woman No Cry", AlbumId = 7, Length = 270 },
                new Song { Id = 8, Name = "Master of Puppets", AlbumId = 8, Length = 515 },
                new Song { Id = 9, Name = "Sweet Little Angel", AlbumId = 9, Length = 220 },
                new Song { Id = 10, Name = "Shape of You", AlbumId = 10, Length = 240 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Workout" },
                new Category { Id = 2, Name = "Chill" },
                new Category { Id = 3, Name = "Party" },
                new Category { Id = 4, Name = "Focus" }
            );

            modelBuilder.Entity<PlayList>().HasData(
                new PlayList { Id = 1, Name = "Morning Energy", CategoryId = 1 },
                new PlayList { Id = 2, Name = "Evening Relax", CategoryId = 2 },
                new PlayList { Id = 3, Name = "Friday Night", CategoryId = 3 },
                new PlayList { Id = 4, Name = "Study Beats", CategoryId = 4 }
            );
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }


        public class Country
        {
            [Required, Key]
            public int Id { get; set; }

            [Required, MaxLength(50)]
            public string Name { get; set; }
            public ICollection<Artist> Artists { get; set; }
        }
        public class Artist
        {
            [Required, Key]
            public int Id { get; set; }

            [Required, MaxLength(50)]
            public string Name { get; set; }
            [MaxLength(50)]
            public string Surname { get; set; }

            public Country Country { get; set; }
            public int CountryId { get; set; }

            public ICollection<Album> Albums { get;set; }
        }
        public class Genre
        {
            [Required, Key]
            public int Id { get; set; }
            [Required, MaxLength(50)]
            public string Name { get; set; }
            public ICollection<Album> Albums { get; set; }
        }
        public class Album
        {
            [Required, Key]
            public int Id { get; set; }
            [Required, MaxLength(50)]
            public string Name { get; set; }
            [Required]
            public DateTime Year { get; set; }

            public Genre Genre { get; set; }
            public int GenreId { get; set; }

            public ICollection<Song> Songs { get; set; } 
        }
        public class Song
        {
            [Required, Key]
            public int Id { get; set; }

            [Required, MaxLength(50)]
            public string Name { get; set; }
            public Album Album { get; set; }
            public int AlbumId { get; set; }

            [Required]
            public int Length { get; set; }
        }
        public class Category
        {
            [Required, Key]
            public int Id { get; set; }
            [Required, MaxLength(50)]
            public string Name { get; set; }
            public ICollection<PlayList> PlayLists { get; set; }
        }
        public class PlayList
        {
            [Required,Key]
            public int Id { get; set; }
            [Required,MaxLength(50)]
            public string Name { get; set; }

            public Category Category { get; set; }
            public int CategoryId { get; set; }

            public ICollection<Song> Songs { get; set; }
        }
    }
    class DBCRUD: MusicCollectionDBContext
    {
        public void addPlaylist()
        {
            var context = new MusicCollectionDBContext();

           Console.WriteLine($"{"Id",15} {"Name",35}");
          Console.WriteLine("----------------------------------------------------------------------------");
          foreach (var i in context.Genres)
          {
              Console.WriteLine($"{i.Id,15} {i.Name,35}");
          }
          Console.WriteLine();


            Console.WriteLine($"{"Id",15} {"Name",35} {"Genre",20} {"Year",20} {"GenreID",10}");
          Console.WriteLine("----------------------------------------------------------------------------");
          foreach (var i in context.Albums)
          {                                               
              Console.WriteLine($"{i.Id,15} {i.Name,35} {i.Genre?.Name,20} {i.Year,20} {i.GenreId,10}");
          }
          Console.WriteLine();

          Console.WriteLine($"{"Id",15} {"Name",35} {"Albums",15} {"AlbumId",15} {"Length",15}");
          Console.WriteLine("----------------------------------------------------------------------------");
          foreach (var i in context.Songs)
          {
              Console.WriteLine($"{i.Id,15} {i.Name,35} {i.Album?.Name,35} {i.AlbumId,15} {i.Length,15} s");
          }
          Console.WriteLine();

          
         
         

            while (true)//to do
            {
                Console.WriteLine("\nEnter [ A ] - add new Playlist\nEnter [ S ] - add songs to existing Playlist\n");
                var choice = Console.ReadKey(true);
                if (choice.Key == ConsoleKey.A)
                {
                    Console.Write("Enter name: "); string n = Console.ReadLine()!;
                    Console.Write("Enter CategoryID: "); int ctgid = int.Parse(Console.ReadLine()!);
                    context.PlayLists.Add(new PlayList()
                    {                       
                        Name = n,
                        CategoryId = ctgid
                    });
                    context.SaveChanges();
                }
                else if (choice.Key == ConsoleKey.S)
                {
                    bool flag = true;
                    while (flag)
                    {
                        Console.Write("Enter Playlist ID to add songs to: ");
                        int c = int.Parse(Console.ReadLine()!);
                        foreach (var i in context.PlayLists)
                        {
                            if (i.Id == c)
                            {
                                flag = false;
                                while (true)
                                {
                                    foreach (var s in context.Songs)
                                    {
                                        Console.WriteLine($"Add song {s.Id} to playlist?\n[ Y ] - yes\n[ N ] - no");
                                        var c3 = Console.ReadKey(true);
                                        if (c3.Key==ConsoleKey.Y)
                                        {
                                           // i.Add(c) //TODO!!!!!
                                        }
                                        else { continue; }
                                    }
                                }

                            }
                        }
                        Console.WriteLine("Wrong Choice!\n");
                    }
                    
                }
                else Console.WriteLine("\nWrong Choice!");
            }


        }
    }
}
