using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_ReaderWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = True";

            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select * from Customers", connection);
            connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);                           // вывод на экран ID клиента испльзуя перегрузку оператора с целочисленным индексом          
                    Console.WriteLine(reader["LName"]);                     // вывод на экран ФИО клиента испльзуя перегрузку оператора со строковым индексом  
                }
            }
            connection.Close();
        }
    }
}
