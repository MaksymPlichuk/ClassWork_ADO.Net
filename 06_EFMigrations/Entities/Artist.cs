using System.ComponentModel.DataAnnotations;

namespace _06_EFMigrations
{
    partial class MusicCollectionDBContext
    {
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

            public ICollection<Album> Albums { get; set; }
        }
    }
}