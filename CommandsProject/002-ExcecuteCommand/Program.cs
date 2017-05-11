using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_ExcecuteCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = True";

            SqlConnection connection = new SqlConnection(conStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Phone from Customers where CustomerNo = 1", connection);
            string phoneNumber = (string)cmd.ExecuteScalar();
            Console.WriteLine(phoneNumber);
        }
    }
}
