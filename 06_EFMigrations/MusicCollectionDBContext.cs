using Microsoft.EntityFrameworkCore;
using static _06_EFMigrations.MusicCollectionDBContext;

namespace _06_EFMigrations
{
    partial class MusicCollectionDBContext : DbContext
    {
        public MusicCollectionDBContext() { }

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
                new Album { Id = 1, Name = "Abbey Road", Year = new DateTime(1969, 9, 26), GenreId = 1, ArtistId = 1, Rating = 6.2, },
                new Album { Id = 2, Name = "The Marshall Mathers LP", Year = new DateTime(2000, 5, 23), GenreId = 4, ArtistId = 2, Rating = 8.9 },
                new Album { Id = 3, Name = "1989", Year = new DateTime(2014, 10, 27), GenreId = 2, ArtistId = 3, Rating = 7.8 },
                new Album { Id = 4, Name = "Kind of Blue", Year = new DateTime(1959, 8, 17), GenreId = 3, ArtistId = 4, Rating = 10 },
                new Album { Id = 5, Name = "Requiem", Year = new DateTime(1791, 12, 5), GenreId = 5, ArtistId = 5, Rating = 9.8 },
                new Album { Id = 6, Name = "Discovery", Year = new DateTime(2001, 3, 12), GenreId = 6, ArtistId = 6, Rating = 10 },
                new Album { Id = 7, Name = "Legend", Year = new DateTime(1984, 5, 8), GenreId = 7, ArtistId = 7, Rating = 9.4 },
                new Album { Id = 8, Name = "Master of Puppets", Year = new DateTime(1986, 3, 3), GenreId = 8, ArtistId = 8, Rating = 9.7 },
                new Album { Id = 9, Name = "Live at the Regal", Year = new DateTime(1965, 11, 21), GenreId = 9, ArtistId = 9, Rating = 9.1 },
                new Album { Id = 10, Name = "Divide", Year = new DateTime(2017, 3, 3), GenreId = 2, ArtistId = 10, Rating = 8.3 },
                new Album { Id = 11, Name = "The Eminem Show", Year = new DateTime(2002, 5, 26), GenreId = 4, ArtistId = 2, Rating = 9.0 },
                new Album { Id = 12, Name = "Encore", Year = new DateTime(2004, 11, 12), GenreId = 4, ArtistId = 2, Rating = 7.5 },
                new Album { Id = 13, Name = "Relapse", Year = new DateTime(2009, 5, 15), GenreId = 4, ArtistId = 2, Rating = 7.2 },
                new Album { Id = 14, Name = "Sgt. Pepper's Lonely Hearts Club Band", Year = new DateTime(1967, 6, 1), GenreId = 1, ArtistId = 1, Rating = 9.9 },
                new Album { Id = 15, Name = "Revolver", Year = new DateTime(1966, 8, 5), GenreId = 1, ArtistId = 1, Rating = 9.5 },
                new Album { Id = 16, Name = "Fearless", Year = new DateTime(2008, 11, 11), GenreId = 2, ArtistId = 3, Rating = 8.7 }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Name = "Come Together", AlbumId = 1, Length = 259, Rating = 8.9, NumberOfListenings = "879 702 634", SongText=SongTexts.ComeTogetherText },
                new Song { Id = 2, Name = "Lose Yourself", AlbumId = 2, Length = 326, Rating = 10, NumberOfListenings = "1 523 409 871", SongText=SongTexts.LoseYourSelfText },
                new Song { Id = 3, Name = "Blank Space", AlbumId = 3, Length = 231, Rating = 4.8, NumberOfListenings = "985 430 212" },
                new Song { Id = 4, Name = "So What", AlbumId = 4, Length = 545, Rating = 3.6, NumberOfListenings = "213 459 876" },
                new Song { Id = 5, Name = "Lacrimosa", AlbumId = 5, Length = 720, Rating = 7.1, NumberOfListenings = "54 321 876" },
                new Song { Id = 6, Name = "Harder Better Faster Stronger", AlbumId = 6, Length = 224, Rating = 4.4, NumberOfListenings = "632 540 921" },
                new Song { Id = 7, Name = "No Woman No Cry", AlbumId = 7, Length = 270, Rating = 6.8, NumberOfListenings = "784 320 654" },
                new Song { Id = 8, Name = "Master of Puppets", AlbumId = 8, Length = 515, Rating = 9.2, NumberOfListenings = "456 213 987" },
                new Song { Id = 9, Name = "Sweet Little Angel", AlbumId = 9, Length = 220, Rating = 2.5, NumberOfListenings = "19 876 543" },
                new Song { Id = 10, Name = "Shape of You", AlbumId = 10, Length = 240, Rating = 7.3, NumberOfListenings = "3 645 098 123", SongText=SongTexts.ShapeOfYouText }
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
    }
    class DBCRUD : MusicCollectionDBContext
    {
        MusicCollectionDBContext context = new MusicCollectionDBContext();
        private void ShowAllSongInfo()
        {
            Console.WriteLine($"{"Id",15} {"Name",35} {"Albums",15} {"AlbumId",15} {"Length",15}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Songs.ToList())   //загруж у пам'ять щоб закрити ридер
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35} {i.Album?.Name,35} {i.AlbumId,15} {i.Length,15} s");
            }
            Console.WriteLine();
        }

        private void ShowAllPlayListInfo()
        {
            Console.WriteLine($"{"Id",15} {"Name",35} {"Category",20} ");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.PlayLists.ToList())   //так само
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35} {i.Category?.Name,20}");
            }
            Console.WriteLine();
        }
        private void ShowAllGenres()
        {
            Console.WriteLine($"{"Id",15} {"Genre",35}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Genres.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35}");
            }
            Console.WriteLine();
        }

        private void ShowAllAlbumInfo()
        {
            Console.WriteLine($"{"Id",15} {"Name",35} {"Genre",20} {"Year",20} {"GenreID",10}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Albums.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35} {i.Genre?.Name,20} {i.Year,20} {i.GenreId,10}");
            }
            Console.WriteLine();
        }

        private void ShowCategoriesInfo()
        {
            Console.WriteLine($"{"Id",15} {"Category",35}");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var i in context.Categories.ToList())
            {
                Console.WriteLine($"{i.Id,15} {i.Name,35}");
            }
            Console.WriteLine();
        }

        public void addPlaylist()
        {
            ShowAllGenres();

            ShowAllAlbumInfo();

            ShowAllSongInfo();

            ShowCategoriesInfo();

            bool firstwhile = true;
            while (firstwhile)
            {
                Console.WriteLine("\nEnter [ A ] - add new Playlist\nEnter [ S ] - add songs to existing Playlist\nEnter [ E ] - to exit\n");
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
                    ShowAllPlayListInfo();
                }
                else if (choice.Key == ConsoleKey.S)
                {
                    ShowAllPlayListInfo();
                    bool flag = true;
                    while (flag)
                    {
                        Console.Write("Enter Playlist ID to add songs to: ");
                        int c = int.Parse(Console.ReadLine()!);
                        foreach (var i in context.PlayLists.ToList())
                        {
                            if (i.Id == c)
                            {
                                flag = false;
                                while (true)
                                {
                                    ShowAllSongInfo();
                                    var allSongs = context.Songs.ToList();//завантаж дані щоб не працювало 2 reader
                                    foreach (var s in allSongs)
                                    {
                                        Console.WriteLine($"Add song with id {s.Id} to playlist?\n[ Y ] - yes\n[ N ] - no");
                                        var c3 = Console.ReadKey(true);
                                        if (c3.Key == ConsoleKey.Y)
                                        {
                                            if (i.Songs == null) { i.Songs = new List<Song>(); }
                                            i.Songs.Add(s);
                                        }
                                        else { continue; }
                                    }
                                    context.SaveChanges();
                                    firstwhile = false;

                                }

                            }
                        }
                        Console.WriteLine("Wrong Choice!\n");
                    }

                }

                else if (choice.Key == ConsoleKey.E) { break; }

                else Console.WriteLine("\nWrong Choice!");
            }
            Console.WriteLine("Final Result:");
            ShowAllSongInfo();
            return;
        }

        public void ShowSongsInAlbumAboveAverage()
        {
            foreach (var i in context.Albums.Include(a=>a.Songs))
            {
                if (i.Songs == null || !i.Songs.Any())
                {
                    Console.WriteLine($"{i.Name} album has No Songs!");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine($"\tTop songs in \u001b[1m{i.Name}\u001b[0m\n\n");
                
                var avgSongs = i.Songs.Average(p=> long.Parse(p.NumberOfListenings.Replace(" ","")));
                var topSongs = i.Songs.Where(p => long.Parse(p.NumberOfListenings.Replace(" ", "")) >= avgSongs).ToList();

                Console.WriteLine($"{"Id",15} {"Name",20} {"Length",15} {"Number of Listenings",35}");
                Console.WriteLine("----------------------------------------------------------------------------\n");
                foreach (var s in topSongs)
                {
                    Console.WriteLine($"{s.Id,15} {s.Name,20} {s.Length,15} {s.NumberOfListenings,35}");
                }
                Console.WriteLine("\n\n");
            }
        }

        //HELP!!!!!
        public void ShowTop3SongsAlbumsByArtist()
        {
            foreach (var a in context.Artists)
            {
                if (a.Albums == null || !a.Albums.Any())
                {
                    Console.WriteLine($"{a.Name + " " + a.Surname} has No Albums!");
                    Console.WriteLine();
                    continue;
                }

                var ArtistAlbums = context.Albums.Where(p => p.ArtistId == a.Id).OrderByDescending(p=>p.Songs);              
                var top3Albums = ArtistAlbums.Take(3).ToList();

                Console.WriteLine($"\tTop 3 Albums from {a.Name+" "+a.Surname}");
                Console.WriteLine($"{"Id",15} {"Name",15} {"Genre",15} {"Number of Listenings",25}");
                Console.WriteLine("----------------------------------------------------------------------------\n");
                foreach (var alb in top3Albums)
                {
                 Console.WriteLine($"{alb.Id,15}{alb.Name,15}{alb.Genre,15}{alb.Year,25}");
                }

                var top3Songs = context.Songs.Include(s => s.Album).Where(s => s.Album.ArtistId == a.Id).OrderByDescending(s => long.Parse(s.NumberOfListenings.Replace(" ", ""))).Take(3).ToList();
                Console.WriteLine($"\tTop 3 Songs from {a.Name + " " + a.Surname}");
                Console.WriteLine($"{"Id",15} {"Name",15} {"Length",15} {"Number of Listenings",25}");
                Console.WriteLine("----------------------------------------------------------------------------\n");
                foreach (var sg in top3Songs)
                {
                    Console.WriteLine($"{sg.Id,15}{sg.Name,15}{sg.Length,15}{sg.NumberOfListenings,25}");
                }
            }

        }
        public void FindSongByText()
        {
            Console.Write("Enter line: "); string line = Console.ReadLine()!;
            foreach (var s in context.Songs)
            {
                if (s.SongText != null)
                {
                    if (s.SongText.Contains(line)){
                        Console.WriteLine($"\tFound line '{line}' in {s.Name}");
                    }
                    else{
                        Console.WriteLine($"Didn't found {line} in {s.Name}");
                        continue;
                    }
                }
                else continue;
                
            }
        }
    }
}