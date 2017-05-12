using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_StoredProcedures
{
    class Program
    {
        static void Main(string[] args)
        {
            // How to create Stored Procedures in SQL => CREATE proc dbo.proc_p1  @EmployeeID nvarchar(50)
                                                   //    AS 
                                                   //    SELECT * from dbo.Employees   
                                                   //    WHERE EmployeeID = @EmployeeID 

            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = true";

            SqlConnection connection = new SqlConnection(conStr);
            Console.WriteLine("Enter employeeID");
            int employeeID = int.Parse(Console.ReadLine());
            
            // the other style of Command in Stored Procedures
            SqlCommand cmd = new SqlCommand("proc_p1", connection) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
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
