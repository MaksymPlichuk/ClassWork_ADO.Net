using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CRUD_Interface
{
    internal class Product
    {
        public int Id { get; set; }
        public string BuyerID { get; set; }
        public int SellerID { get; set; }
        public int Price { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
