using _03_SQLInjectionDataAccessLayer;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _03_SalesUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SalesDb db;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["SalesDbConnectionString"].ConnectionString;
            db = new SalesDb(connectionString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.ListShowAllSales();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.ListShowAllBuyers();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.ListShowAllSellers();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.ListShowFullSales();
        }
    }
}