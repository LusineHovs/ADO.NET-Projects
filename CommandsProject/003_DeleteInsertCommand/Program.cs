using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_DeleteInsertCommand
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

            // Insert command 
            SqlCommand insertCmd = connection.CreateCommand();
            insertCmd.CommandText = "insert Customers values ('Alex', 'Petrov', 'Petrovich', 'Заворотная 7', NULL, 'Kiyv', '(063)8569584', '2010-01-01')";

            // added 1 row
            int rowAffected = insertCmd.ExecuteNonQuery(); 
            Console.WriteLine("INSERT command rows affected: " + rowAffected);


            // Delete command 
            SqlCommand deleteCmd = connection.CreateCommand();
            deleteCmd.CommandText = "delete Customers WHERE Phone = '(063)8569584'";
            deleteCmd.ExecuteNonQuery();
            Console.WriteLine("Row deleted");
            connection.Close();

        }
    }
}
