using System.ComponentModel.DataAnnotations;

namespace _06_EFMigrations
{
    partial class MusicCollectionDBContext
    {
        public class Genre
        {
            [Required, Key]
            public int Id { get; set; }
            [Required, MaxLength(50)]
            public string Name { get; set; }
            public ICollection<Album> Albums { get; set; }
        }
    }
}