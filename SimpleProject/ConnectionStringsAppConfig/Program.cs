using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ConnectionStringsAppConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            // if you want to save your connection string into Config file, do the following
            var settings = new ConnectionStringSettings
            {
                // connectionString-i anunn e Config file-um
                Name = "MyConnectionString1",    
                ConnectionString = @"Data Source=.\SQLEXPRESS;
                                     Initial Catalog=ShopDB;
                                     Integrated Security=True;"
            };

            Configuration config; // Config file-n e
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  // Config manager-i mijocov dostup es unenum Config file-erin
            config.ConnectionStrings.ConnectionStrings.Add(setting);
            config.Save();

            Console.WriteLine("Строка подключения записана в конфигурационный файл.");

            
            Console.WriteLine(ConfigurationManager.ConnectionStrings["MyConnectionString1"].ConnectionString);
        

        }
    }
}
