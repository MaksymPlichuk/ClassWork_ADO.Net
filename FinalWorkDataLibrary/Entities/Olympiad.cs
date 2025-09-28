using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorkDataLibrary.Entities
{
    public class Olympiad
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public OlympiadType OlympiadType { get; set; }
        public int OlympiadTypeId { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public ICollection<SportType> SportTypes { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
