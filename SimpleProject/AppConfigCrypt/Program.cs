 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AppConfigCrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("COnnectionStr1", "SomeConnectionString"));
            config.Save();

            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

            if (section.SectionInformation.IsProtected)
            {
                //connection string section decrypted
                section.SectionInformation.UnprotectSection();
            }
            else
            {
                //connection string section crypted
                section.SectionInformation.ProtectSection(
                    "DataProtectionConfigurationProvider");
            }

            
            config.Save();

            // checkes crypting
            Console.WriteLine("Protected={0}", section.SectionInformation.IsProtected);

            Console.WriteLine(ConfigurationManager.ConnectionStrings["COnnectionStr1"].ConnectionString);
        }
    }
}
