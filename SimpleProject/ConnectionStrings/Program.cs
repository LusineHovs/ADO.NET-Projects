using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;
                              Initial Catalog = ShopDB;
                              Integrated Security = True";
            SqlConnection connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine(connection.State);
            }
        }
    }
}
