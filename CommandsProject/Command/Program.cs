using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Sourse = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = true";

            SqlConnection connection = new SqlConnection(conStr);
            //   first method //
            SqlCommand cmd = new SqlCommand("Some command text", connection);

            // second method //
            cmd = connection.CreateCommand();
            cmd.CommandText = "Some SQL command text";

            // third method //
            cmd.Connection = connection;
            cmd.CommandText = "Some SQL command text";
            
        }
    }
}
