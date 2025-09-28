using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorkDataLibrary.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public Olympiad Olympiad { get; set; }
        public int OlympiadId { get; set; }
        public Medal Medal { get; set; }
        public int? MedalId { get; set; }
        public Athlete Athlete { get; set; }
        public int AthleteId { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }
    }
}
