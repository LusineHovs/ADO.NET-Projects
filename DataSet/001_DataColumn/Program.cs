using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_DataColumn
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable("Table");

            DataColumn column1 = new DataColumn("Name", typeof(string));
            DataColumn column2 = new DataColumn("Surname", typeof(string));

            // 
            DataColumnCollection columnCollection = table.Columns;
            columnCollection.AddRange(new DataColumn[] { column1, column2 });

            foreach (DataColumn column in columnCollection)
            {
                Console.WriteLine($"{column.ColumnName} : {column.DataType }");
            }
        }
    }
}
