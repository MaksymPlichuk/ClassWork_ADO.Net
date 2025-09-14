using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SQLInjectionDataAccessLayer
{
    internal class Sale
    {
        public int Id { get; set; }
        public int BuyerID { get; set; }
        public int SellerID { get; set; }
        public int Price { get; set; }
        public DateTime SaleDate { get; set; }

        public override string ToString()
        {
            return $"{BuyerID,5} {SellerID,5} {Price,10} {SaleDate,15}";
        }
    }
}
