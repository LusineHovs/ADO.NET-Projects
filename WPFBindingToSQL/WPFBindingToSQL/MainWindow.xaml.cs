using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFBindingToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> list;
        public MainWindow()
        {
            InitializeComponent();
            list = new ObservableCollection<string>();
        }

        private void GetAllFiles_Click(object sender, RoutedEventArgs e)
        {
            string conStr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DocumentDB; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();

                command.Transaction = transaction;

                try
                {
                    command.CommandText = "SELECT * FROM Documents";

                    SqlDataReader reader = command.ExecuteReaderAsync().Result;

                    while(reader.ReadAsync().Result)
                    {

                        list.Add(reader[0].ToString());
                       
                    }

                    reader.Close();

                   transaction.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();

                        throw ex;
                    }
                    catch (Exception exRollback)
                    {
                        throw exRollback;
                    }
                }
                MessageBox.Show(list[0]);
                listOfFiles.ItemsSource = list;
            }
        }
    

        private void buttonGetByName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Createnew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
