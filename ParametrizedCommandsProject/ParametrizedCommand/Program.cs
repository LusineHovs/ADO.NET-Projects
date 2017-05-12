using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ParametrizedCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = true";

            var customerNo = Console.ReadLine();

            // this style is not preferable
            string commandStr = string.Format($"SELECT * FROM Customers WHERE CustomerNo = {customerNo};"); // для создания параматризированного запроса используется метод string.Format

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(commandStr, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.GetName(i)} : {reader[i]}");
                        }
                        Console.WriteLine(new string('-',10));
                    }
                }
            }

        }
    }
}
