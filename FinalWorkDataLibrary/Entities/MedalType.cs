using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorkDataLibrary.Entities
{
    public class MedalType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Medal> Medals { get; set; }
    }
}
