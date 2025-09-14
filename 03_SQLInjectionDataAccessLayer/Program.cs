using _03_DataLibrary.Models;
using System.Net.Http.Headers;

namespace _03_SQLInjectionDataAccessLayer
{


    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = DESKTOP-NSGHIVN\SQLEXPRESS; 
                                        Initial Catalog = Sales;
                                        Integrated Security = true; TrustServerCertificate=True;";

            using (SalesDb saleDB = new SalesDb(connectionString))
            {
                saleDB.ShowAllSalesInfo();

                Thread.Sleep(500);
                saleDB.AddNewSaleBuy();
                saleDB.ShowSalesInPeriod();

                Thread.Sleep(500);
                saleDB.ShowAllSalesInfo();
                saleDB.ShowLastBuyerBuy();  //Yulia Ivchenko
                Thread.Sleep(500);

                saleDB.DeleteBuyerSellerById();
                Thread.Sleep(300);
                saleDB.ShowAllSalesInfo();
                saleDB.ShowRichestSeller();
            }
        }
    }
}
