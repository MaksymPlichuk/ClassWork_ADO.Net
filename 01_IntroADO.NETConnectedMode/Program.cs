using System.Text;
using Microsoft.Data.SqlClient;

namespace _01_IntroADO.NETConnectedMode
{
    internal class Program
    {
        public static void ShowBuyersInfo(SqlConnection sqlConnection) {
            string cmdText = $@"select * from Buyers";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            //column name
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            //elem name
            while (reader.Read()){
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            reader.Close();
        }
        public static void ShowSellerrsInfo(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Sellers";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            //column name
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            //elem name
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            reader.Close();
        }
        public static void ShowSaleInfo(SqlConnection sqlConnection)
        {
            string cmdText = $@"select b.Name +' '+b.Surname as [Buyer],s.Price,s.SaleDate,sl.Name+' '+ sl.Surname as [Seller]
                from Sales as s join Buyers as b on s.BuyerId=b.Id
				join Sellers as sl on s.SellerId=sl.Id";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            //column name
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            //elem name
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            reader.Close();
        }

        static void Main(string[] args)
        {
            string connectionString = @"Data Source = (localDB)\MSSQLLocalDb; 
                                        Initial Catalog = Sales;
                                        Integrated Security = true; TrustServerCertificate=True;
                                                                                        ";
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
