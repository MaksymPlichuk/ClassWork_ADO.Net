using System.ComponentModel.DataAnnotations;

namespace _06_EFMigrations
{
    partial class MusicCollectionDBContext
    {
        public class PlayList
        {
            [Required, Key]
            public int Id { get; set; }
            [Required, MaxLength(50)]
            public string Name { get; set; }

            public Category Category { get; set; }
            public int CategoryId { get; set; }

            public ICollection<Song> Songs { get; set; }
        }
    }
}