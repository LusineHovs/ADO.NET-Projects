using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLEDB_Provider
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectToAccessDB();
            ConnectToExcelDB();
        }

        // data provider is Microsoft Access 
        private static void ConnectToAccessDB()
        {
            var conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source= D:\ADO.NET\DATA\Access.mdb");

            try
            {
                conn.Open();
                Console.WriteLine("Connection to .mdb(AccessDB) file opened successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

        // data provider is Microsoft Excel
        private static void ConnectToExcelDB()
        {
            var conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\ADO.NET\DATA\Excel.xls; Extended Properties=""Excel 8.0""");

            try
            {
                conn.Open();
                Console.WriteLine("Connection to .xls(ExcelDB) file opened successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

    }
}
