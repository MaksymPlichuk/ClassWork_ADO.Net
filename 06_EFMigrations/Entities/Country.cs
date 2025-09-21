using System.ComponentModel.DataAnnotations;

namespace _06_EFMigrations
{
    partial class MusicCollectionDBContext
    {
        public class Country
        {
            [Required, Key]
            public int Id { get; set; }

            [Required, MaxLength(50)]
            public string Name { get; set; }
            public ICollection<Artist> Artists { get; set; }
        }
    }
}