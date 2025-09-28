using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorkDataLibrary.Entities
{
    public class Athlete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PhotoPath { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
