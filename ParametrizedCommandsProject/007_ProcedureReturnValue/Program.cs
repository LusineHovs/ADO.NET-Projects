using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_ProcedureReturnValue
{
    class Program
    {
        static void Main(string[] args)
        {
            // How to create Stored Procedures in SQL => CREATE proc dbo.proc_p1  @EmployeeID nvarchar(50)
                                                   //    AS 
                                                   //    BEGIN  
                                                   //    return 1;
                                                   //    END

            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = true";

            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("ProcedureReturnValue", connection) { CommandType = System.Data.CommandType.StoredProcedure };
            SqlParameter parameter = cmd.Parameters.Add(new SqlParameter());
            parameter.Direction = System.Data.ParameterDirection.ReturnValue; // после выполнения комманды parameter будет содержать возвращаемое значение хранимой процедуры 

            connection.Open();

            cmd.ExecuteNonQuery();

            Console.WriteLine(parameter.Value);

        }
    }
}
