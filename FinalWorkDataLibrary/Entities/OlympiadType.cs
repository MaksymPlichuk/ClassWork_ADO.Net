using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorkDataLibrary.Entities
{
    public class OlympiadType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Olympiad> Olympiads { get; set; }
    }
}
