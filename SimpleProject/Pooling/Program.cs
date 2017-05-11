using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pooling
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;
                              Initial Catalog = ShopDB;
                              Integrated Security = True;
                              Pooling = true";

            DateTime start = DateTime.Now;

            for (int i = 0; i < 1000; i++)
            {
                SqlConnection connection = new SqlConnection(conStr);
                connection.Open();    
                connection.Close();  
            }

            TimeSpan stop = DateTime.Now - start;

            Console.WriteLine(stop.TotalSeconds);
        }
    }
}
