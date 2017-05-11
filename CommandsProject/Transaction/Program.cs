using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = True";

            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SELECT LName, FName, Phone FROM Customers", connection);

            Console.ReadKey();
            connection.Open();

            cmd.Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} {1}: {2}", reader[0], reader[1], reader[2]);
            }

            connection.Close();
        }
    }
}
