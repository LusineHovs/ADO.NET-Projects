using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_ParametrizedCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = true";

            var commandStr = "select * from Customers where CustomerNo = @CustomerNo;";
            Console.WriteLine("Please Enter ID");
            var customerNo = Console.ReadLine();

            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(commandStr, connection);
            
            // this style IS PREFERABLE
            cmd.Parameters.AddWithValue("CustomerNo", customerNo);
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine($"{reader.GetName(i)} : {reader[i]}");
                }
                Console.WriteLine(new string('-',20));
            }
            reader.Close();
            connection.Close();
        }
    }
}
