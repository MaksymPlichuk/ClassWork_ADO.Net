using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_DataLibrary.Models
{
    public class FullSale
    {
        public int Id { get; set; }

        public int SellerID { get; set; }
        public string SlName { get; set; }
        public string SlSurname { get; set; }
       
        public int Price { get; set; }
        public DateTime SaleDate { get; set; }

        public int BuyerID { get; set; }

        public string ByName { get; set; }
        public string BySurname { get; set; }

        public override string ToString()
        {
            return $" {SellerID,5} {SlName,15} {SlSurname,15} {Price,10} {SaleDate,15} {BuyerID,5} {ByName,15} {BySurname,15}";
        }
    }
}
