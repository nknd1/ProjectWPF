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

    public partial class CategoryPage : Page
    {
        connection connection;
        public CategoryPage(connection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Категория категория = new Категория();
            категория.Название = tbAddCategory.Text.Trim();
            string categoryname = tbAddCategory.Text.Trim();
            List<Категория> categories = connection.Категория.ToList();
            foreach (Категория category in categories)
            {
                if (category.Название.ToLower() == categoryname.ToLower())
                {
                    MessageBox.Show("Данная категория уже существует");
                    return;
                }
            }
            Категория categorys = new Категория();
            connection.Категория.Add(категория);
            connection.SaveChanges();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Start);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Product);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
