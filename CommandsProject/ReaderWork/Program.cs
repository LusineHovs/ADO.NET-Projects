using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderWork
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
                Console.WriteLine(reader.GetFieldValue<int>(0));
                Console.WriteLine(reader.GetString(2) + " " + reader.GetString(1));
                Console.WriteLine(reader.GetFieldValue<string>(7));
                Console.WriteLine("{0:D}", reader.GetDateTime(8));
                Console.WriteLine(new string('-',20));
            }
            reader.Close();
            connection.Close();
        }
    }
}
