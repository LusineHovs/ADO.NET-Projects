using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExecuteCommandAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string conStr = @"Data Source = (localdb)\MSSQLLocalDB;
                                            Initial Catalog = ShopDB;
                                            Integrated Security = True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("waitfor delay '00:00:5'", connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Simple command executed");

            }

        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                await connection.OpenAsync();
                SqlCommand cmd = new SqlCommand("waitfor delay '00:00:5'", connection);

                await cmd.ExecuteReaderAsync();
                MessageBox.Show("Command executed async");
            }
        }
    }
}
