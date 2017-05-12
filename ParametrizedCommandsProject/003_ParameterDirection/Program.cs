using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_ParameterDirection
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = true";
            SqlConnection connection = new SqlConnection(conStr);

            // Our Command creates new Variable with name Parameter and set the value 2 
            SqlCommand cmd = new SqlCommand("set @Parameter = 2;", connection);
            SqlParameter parameter = cmd.Parameters.Add(new SqlParameter("Parameter", System.Data.SqlDbType.Int));
            parameter.Direction = System.Data.ParameterDirection.Output; // указание направления параметра

            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Parameter value: " + parameter.Value);
            connection.Close();
        }
    }
}
