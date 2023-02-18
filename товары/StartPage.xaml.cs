using System;
using System.Collections.Generic;
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

namespace товары
{
 
    public partial class StartPage : Page
    {
        connection connection;
        public StartPage(connection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void MoveToProductPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Product);
        }

        private void MoveToCategoryPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Category);

        }

        private void MoveToProductList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ProductList);
        }
    }
}
