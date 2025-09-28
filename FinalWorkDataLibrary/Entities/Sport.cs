using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorkDataLibrary.Entities
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SportType SportType { get; set; }
        public int SportTypeId { get; set; }
        public ICollection<Athlete> Athletes { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
