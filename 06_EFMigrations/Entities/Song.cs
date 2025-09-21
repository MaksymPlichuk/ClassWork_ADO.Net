using System.ComponentModel.DataAnnotations;

namespace _06_EFMigrations
{
    partial class MusicCollectionDBContext
    {
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
            public ICollection<PlayList> PlayLists { get; set; }

            [Required]
            public double Rating { get; set; }

            [Required]
            public string NumberOfListenings { get; set; }

            public string? SongText { get; set; }

        }
    }
}