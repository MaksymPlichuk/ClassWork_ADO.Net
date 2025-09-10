using Microsoft.Data.SqlClient;

namespace _02_CRUD_Interface
{
    class SalesDb: IDisposable
    {
        private SqlConnection sqlConnection;
        public SalesDb(string connection)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
        }
        public void Create_As_Insert(Product product)
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES ({product.BuyerID}, 
                                      {product.SellerID},
                                       {product.Price}, 
                                       '{product.SaleDate}')";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            command.CommandTimeout = 5;

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = (localDB)\MSSQLLocalDb; 
                                        Initial Catalog = Sales;
                                        Integrated Security = true; TrustServerCertificate=True;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connected success!");

            ShowBuyersInfo(sqlConnection);
            ShowSellerrsInfo(sqlConnection);
            ShowSaleInfo(sqlConnection);

            sqlConnection.Close();
        }
    }
}
