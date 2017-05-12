using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_DataRow
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            // you can add columns OR in this way OR like in the previous example using DataColumn 
            table.Columns.Add(new DataColumn("Column1", typeof(int)));
            table.Columns.Add(new DataColumn("Column2"));

            DataRow firstRow = table.NewRow();
            firstRow["Column1"] = 1;  // row-i fieldin value talu hamar talis enq naev column-i name-y kam indexy
            //row[0] = 1;

            firstRow["Column2"] = 2;
            
            // 0 ktpi, qani vor table-in Add chenq arel
            Console.WriteLine($"table.Rows.Count: {table.Rows.Count}" );

            table.Rows.Add(firstRow);

            Console.WriteLine("table.Rows.Count: " + table.Rows.Count); // выведется 1

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
            }
        }
    }
}
