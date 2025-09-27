using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DataLibrary.Entities
{
    public class AirplaneType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Airplane> Airplanes { get; set; }
    }
}
