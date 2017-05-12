using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_StoredProcedures
{
    class Program
    {
        static void Main(string[] args)
        {
            // How to create Stored Procedures in SQL => CREATE proc dbo.selectEmp 
                                                       // as select * from dbo.Employees 

            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = true";

            SqlConnection connection = new SqlConnection(conStr);
            
            // We simple execude existing Stored Procedures
            SqlCommand cmd = new SqlCommand("EXECUTE selectEmp", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);

                Console.WriteLine();
            }
            connection.Close();

        }
    }
}
