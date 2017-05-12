using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_MaxLength
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            DataColumn column = table.Columns.Add("MaxLengthConstraintColumn", typeof(string));
            column.MaxLength = 5;

            DataRow row = table.NewRow();
            row[0] = "Some";
            table.Rows.Add(row);
            Console.WriteLine(table.Rows[0][0]);
        }
    }
}
