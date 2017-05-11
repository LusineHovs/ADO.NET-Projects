using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_PackageCommands
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerNo = 1; SELECT * FROM Employees WHERE EmployeeID = 1;", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i)+ ": "+ reader[i]);
                    
                }
                Console.WriteLine(new string('-', 20));
            }

            Console.ReadKey();


            // calls the next Command
            reader.NextResult();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i) + ": " + reader[i]);

                }
                Console.WriteLine(new string('-', 20));
            }

            reader.Close();
            connection.Close();
        }
    }
}
