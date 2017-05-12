using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_AllowDBNull
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            DataColumn column = table.Columns.Add("AllowDBNullColumn", typeof(int));
            column.AllowDBNull = true;

            DataRow row = table.NewRow();
            row[0] = DBNull.Value;

            table.Rows.Add(row);
            Console.WriteLine(table.Rows[0][0]);
        }
    }
}
