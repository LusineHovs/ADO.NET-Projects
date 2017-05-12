using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ReadOnlyProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            DataColumn column = table.Columns.Add("ReadOnlyColumn", typeof(string));
            column.ReadOnly = true;   // this column only for reading

            DataRow row = table.NewRow();
            row[0] = "readonlyValue";
            table.Rows.Add(row);

            Console.WriteLine(table.Rows[0][0]);

           // table.Rows[][] = "newvalue";  => error
        }
    }
}
