using Microsoft.Data.SqlClient;

namespace _03_SQLInjectionDataAccessLayer
{
    class SalesDb : IDisposable
    {
        private SqlConnection sqlConnection;

        public SalesDb(string connection)
        {
            this.sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
        }

        public Sale CreateSale()
        {
            Console.WriteLine("====Creating Sale====");
            Console.Write("Enter Seller ID: "); int selId = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Buyer ID: "); int buyId = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Price: "); int price = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Sale date [yyyy-MM-dd HH:mm:ss]: "); DateTime saleDate = DateTime.Parse(Console.ReadLine()!);

            Sale sale = new Sale();
            sale.SellerID = selId;
            sale.BuyerID = buyId;
            sale.Price = price;
            sale.SaleDate = saleDate;

            return sale;
        }
        public void AddNewSaleBuy()
        {
            Sale sale = CreateSale();
            string formatedDate = sale.SaleDate.ToString("yyyy-MM-dd HH:mm:ss");
            string cmdText = $@"INSERT INTO Sales Values (@BuyerID,@SellerID,@Price,@formatedDate)";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            command.Parameters.AddWithValue("BuyerID", sale.BuyerID);
            command.Parameters.AddWithValue("SellerID", sale.SellerID);
            command.Parameters.AddWithValue("Price", sale.Price);
            command.Parameters.AddWithValue("formatedDate", formatedDate);


            command.CommandTimeout = 5;

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }
        private void ShowFunction(string cmdText,params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            if (parameters!=null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.Add(parameters[i]);
                }
            }
            
          
            SqlDataReader reader = command.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),20}");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],20}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            reader.Close();
        }
        public void ShowAllSalesInfo()
        {
            string cmdText = $@"select sl.Id,sl.Name+' '+ sl.Surname as [Seller],s.Price,s.SaleDate,b.Id,b.Name +' '+b.Surname as [Buyer]
                                from Sales as s join Buyers as b on s.BuyerId=b.Id
                                				join Sellers as sl on s.SellerId=sl.Id
                                 order by s.SaleDate";
            ShowFunction(cmdText,null);
        }
        public void ShowSalesInPeriod()
        {
            DateTime date1; DateTime date2;

            Console.WriteLine("\n====Enter Time Range====");
            Console.Write("Enter Fisrst Date [yyyy-MM-dd HH:mm:ss]: ");
            date1 = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Enter Second Date [yyyy-MM-dd HH:mm:ss]: ");
            date2 = DateTime.Parse(Console.ReadLine()!);

            string formatedDate = date1.ToString("yyyy-MM-dd HH:mm:ss");
            string formatedDate2 = date2.ToString("yyyy-MM-dd HH:mm:ss");

            string cmdText = $@"select sl.Id,sl.Name+' '+ sl.Surname as [Seller],s.Price,s.SaleDate,b.Id,b.Name +' '+b.Surname as [Buyer]
                                from Sales as s join Buyers as b on s.BuyerId=b.Id
                                				join Sellers as sl on s.SellerId=sl.Id
                               where s.SaleDate between @formatedDate and @formatedDate2
                                order by s.SaleDate";


            SqlParameter param1 = new SqlParameter
            {
                ParameterName = "formatedDate",
                SqlDbType = System.Data.SqlDbType.Date,
                Value = formatedDate
            };
            SqlParameter param2 = new SqlParameter
            {
                ParameterName = "formatedDate2",
                SqlDbType = System.Data.SqlDbType.Date,
                Value = formatedDate2
            };

            ShowFunction(cmdText,param1,param2);
        }
        public void ShowLastBuyerBuy()
        {
            string Name, Surname;
            Console.WriteLine("====Enter Buyer Credentials for Latest Buy===");

            Console.Write("Enter Buyer Name: "); Name = Console.ReadLine()!;
            Console.Write("Enter Buyer Surname: "); Surname = Console.ReadLine()!;

            string cmdText = $@"select sl.Id,sl.Name+' '+ sl.Surname as [Seller],s.Price,s.SaleDate,b.Id,b.Name +' '+b.Surname as [Buyer]
                                from Sales as s join Buyers as b on s.BuyerId=b.Id
                                				join Sellers as sl on s.SellerId=sl.Id
            where b.Name=@Name and b.Surname=@Surname and s.SaleDate = (select MAX(SaleDate)
                                                                    from Sales as s join Buyers as b on s.BuyerId=b.Id
                                                                    where b.Name=@Name and b.Surname=@Surname);";
            SqlParameter param1 = new SqlParameter
            {
                ParameterName = "Name",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = Name
            };
            SqlParameter param2 = new SqlParameter
            {
                ParameterName = "Surname",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = Surname
            };
            ShowFunction(cmdText,param1,param2);
        }

        public void DeleteBuyerSellerById()
        {
            string Sellers = $@"select Id, Name+' '+ Surname as [Seller] from Sellers order by Id";
            ShowFunction(Sellers);
            string Buyers = $@"select Id,Name +' '+Surname as [Buyer] from Buyers order by Id";
            ShowFunction(Buyers);

            int id; Console.Write("Enter Id to delete: "); id = int.Parse(Console.ReadLine()!);
            string cmdText;
            while (true)
            {
                Console.Write("Enter [ B ] - Delete Buyer\nEnter [ S ] Delete Seller "); var choice = Console.ReadKey(true);
                if (choice.Key == ConsoleKey.B)
                {
                    cmdText = $@"Delete Buyers where id = @id";
                    break;
                }
                else if (choice.Key == ConsoleKey.S)
                {
                    cmdText = $@"Delete Sellers where id = @id";
                    break;
                }
                else { Console.WriteLine("\nWrong Key!"); }
            }
            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            command.Parameters.AddWithValue("@id", id);

            command.CommandTimeout = 5;
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows Affected!");


        }
        public void ShowRichestSeller()
        {
            string cmdText = $@"select sl.Name+' '+ sl.Surname as [Seller],SUM(s.Price) as [TotalSales]
                                from Sales as s join Sellers as sl on s.SellerId=sl.Id
                                group by sl.Name,sl.Surname
                                having SUM(s.Price) = (select MAX(ts.TotalSales)
                                                from (select SUM(s.Price) as TotalSales 
                                                        from Sales as s join Sellers as sl on sl.Id=s.SellerId
                                                        group by sl.Id) as ts)";
            ShowFunction(cmdText,null);
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
            string connectionString = @"Data Source = DESKTOP-NSGHIVN\SQLEXPRESS; 
                                        Initial Catalog = Sales;
                                        Integrated Security = true; TrustServerCertificate=True;";

            // Sale s1 = new Sale() { SellerID = 1, BuyerID = 1, SaleDate = (new DateTime (2002,04,28)),Price = 8900 };

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
