using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_UniqueProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            DataColumn column = table.Columns.Add("UniqueColumn", typeof(string));
            column.Unique = true;

            DataRow newRow = table.NewRow();
            newRow[0] = "NonUniqueValue";
            table.Rows.Add(newRow);

            newRow = table.NewRow();
            newRow[0] = "NonUniqueValue";
            table.Rows.Add(newRow); // ошибка времени выполнения при нарушении ограничения Unique

            Console.WriteLine(table.Rows[0][0]);
            Console.WriteLine(table.Rows[1][0]);
        }
    }
}
