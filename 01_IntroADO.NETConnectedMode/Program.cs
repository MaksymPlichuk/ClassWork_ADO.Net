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

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

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

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

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

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),20}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],20} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            reader.Close();
        }

        public static void ShowSalesPriceHigher(SqlConnection sqlConnection) {

            int price;
            Console.Write("Enter Price: "); price = int.Parse(Console.ReadLine()!);


            string cmdText = $@"select b.Name +' '+b.Surname as [Buyer],s.Price,s.SaleDate,sl.Name+' '+ sl.Surname as [Seller]
                             from Sales as s join Buyers as b on s.BuyerId=b.Id
				            join Sellers as sl on s.SellerId=sl.Id
                            where s.Price> {price}";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),20}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],20} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");

            reader.Close();
        }

        public static void ShowMinMaxBuyFromUser(SqlConnection sqlConnection,string Name,string Surname)
        {


            string cmdText = $@"select b.Name +' '+b.Surname as [Buyer],s.Price,s.SaleDate,sl.Name+' '+ sl.Surname as [Seller]
                                    from Sales as s join Buyers as b on s.BuyerId=b.Id
                                    				join Sellers as sl on s.SellerId=sl.Id
                                    where b.Name='{Name}' and b.Surname='{Surname}' and s.Price = (select Max(sl.Price) from Sales as sl 
                                    									join Buyers as b on sl.BuyerId=b.Id
                                    									where b.Name='{Name}' and b.Surname='{Surname}')
                                    Union all
                                    select b.Name +' '+b.Surname as [Buyer],s.Price,s.SaleDate,sl.Name+' '+ sl.Surname as [Seller]
                                    from Sales as s join Buyers as b on s.BuyerId=b.Id
                                    				join Sellers as sl on s.SellerId=sl.Id
                                    where b.Name='{Name}' and b.Surname='{Surname}' and s.Price = (select Min(sl.Price) from Sales as sl 
									join Buyers as b on sl.BuyerId=b.Id
									where b.Name='{Name}' and b.Surname='{Surname}')";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),20}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],20} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");

            reader.Close();
        }

        public static void FistSellOfSellerByName(SqlConnection sqlConnection, string Name, string Surname)
        {


            string cmdText = $@"select sl.Name+' '+ sl.Surname as [Seller],s.Price,s.SaleDate as [OldestSale],b.Name +' '+b.Surname as [Buyer]
                                from Sales as s join Buyers as b on s.BuyerId=b.Id
                                				join Sellers as sl on s.SellerId=sl.Id
                                where sl.Name = '{Name}' and sl.Surname='{Surname}' and s.SaleDate = (select MIN(s.SaleDate) from Sales as s 
												join Sellers as sl on sl.Id=s.SellerId 
												where sl.Name = '{Name}' and sl.Surname='{Surname}')";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),20}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],20} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");

            reader.Close();
        }
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = DESKTOP-NSGHIVN\SQLEXPRESS; 
                                        Initial Catalog = Sales;
                                        Integrated Security = true; TrustServerCertificate=True;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connected success!");

            ShowBuyersInfo(sqlConnection);
            ShowSellerrsInfo(sqlConnection);
            ShowSaleInfo(sqlConnection);
            ShowSalesPriceHigher(sqlConnection);
            ShowMinMaxBuyFromUser(sqlConnection, "Roman", "Shevchenko");
            FistSellOfSellerByName(sqlConnection, "Dmytro", "Krutov");

            sqlConnection.Close();

        }
    }
}
