using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_DBColumnNullValue
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = True";

            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select * from Customers", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(5))
                    Console.WriteLine("Address Line 2: " + "No Data");
                else
                    Console.WriteLine("Address Line 2: " +reader[5]);
            }
        }
    }
}
