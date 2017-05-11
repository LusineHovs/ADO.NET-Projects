using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_ExecuteReader_table_Commands
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

            SqlCommand command = new SqlCommand("Select * from Customers", connection);
            // dataReadery reads table row by row 
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i) + ":" + reader[i]);
                }

                Console.WriteLine(new string('-', 20));
            }
            reader.Close();
            connection.Close();

        }
    }
}
