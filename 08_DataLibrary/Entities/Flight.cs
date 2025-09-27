using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DataLibrary.Entities
{
    public class Flight
    {
        public int Number { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Rating { get; set; }


        public Airplane Airplane { get; set; }
        public int AirplaneId { get; set; }
        public ICollection<Client> Clients { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
