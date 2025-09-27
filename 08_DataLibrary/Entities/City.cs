using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DataLibrary.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
