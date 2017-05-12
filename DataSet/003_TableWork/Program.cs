using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_TableWork
{
    class Program
    {
        // This method creates new DataTable with schema same to SqlDataReader 
        private static DataTable CreateSchemaFromReader(SqlDataReader reader, string tableName)
        {
            DataTable table = new DataTable(tableName);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                table.Columns.Add(new DataColumn(reader.GetName(i), reader.GetFieldType(i)));
            }
            return table;
        }

        // This method write data to DataTable whith same schema as DataReader
        private static void WriteDataFromReader(DataTable table, SqlDataReader reader)
        {
            while (reader.Read())
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i];
                    table.Rows.Add(row);
                }
            }
        }




        static void Main(string[] args)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = true";

            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select * from Customers", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // Sxeman enq sarqum
            DataTable table = CreateSchemaFromReader(reader, "Customers");

            // stugum enq te ardyoq SqlDataReader-i nman e sarqel sxeman
            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine("{0}: {1}", column.ColumnName, column.DataType);
            }

            // sarqac sxemayov table-@ data enq lcnum
            WriteDataFromReader(table, reader);

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine($"{column.ColumnName} : {row[column]}");
                }
            }

        }
    }
}
