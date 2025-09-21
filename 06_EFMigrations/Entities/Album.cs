using System.ComponentModel.DataAnnotations;

namespace _06_EFMigrations
{
    partial class MusicCollectionDBContext
    {
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

            public Artist Artist { get; set; }
            public int ArtistId { get; set; }

            public ICollection<Song> Songs { get; set; }

            [Required,MaxLength(150)]
            public double Rating { get; set; }
        }
    }
}