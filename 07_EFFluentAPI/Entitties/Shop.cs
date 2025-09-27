using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EFFluentAPI.Entitties
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public float? ParkingArea { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
