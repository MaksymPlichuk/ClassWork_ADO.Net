using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DataLibrary.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public AirplaneType AirplaneType { get; set; }
        public int AirplaneTypeId { get; set; }

    }
}
