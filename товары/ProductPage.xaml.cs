using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
   
    public partial class ProductPage : Page
    {
        connection connection;
        public ProductPage(connection connection)
        {
            InitializeComponent();
            this.connection = connection;

            Binding binding = new Binding();
            binding.Source = connection.Категория.ToList();
            cbCategoryName.SetBinding(ComboBox.ItemsSourceProperty, binding);
            cbCategoryName.DisplayMemberPath = "Название";

            spAddProduct.DataContext = new Товар();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Товар product = spAddProduct.DataContext as Товар;
            product.Название = product.Название.Trim();

            if (tbName.SelectedText == null)
            {
                MessageBox.Show("Введите название товара");
                return;
            }

            if (cbCategoryName.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию");
                return;
            }
            Категория selectedCategory = cbCategoryName.SelectedItem as Категория;
            if (selectedCategory == null)
            {
                MessageBox.Show("Ошибка ввода категории");
                return;
            }

            if (tbPriceName.SelectedText == null)
            {
                MessageBox.Show("Введите цену товара");
                return;
            }

            if (tbCountName.SelectedText == null)
            {
                MessageBox.Show("Введите количество товара");
                return;
            }

            if (tbSizeName.SelectedText == null)
            {
                MessageBox.Show("Введите размер товара");
                return;
            }
            product.Категория = selectedCategory.Название;
            connection.Товар.Add(product);
            connection.SaveChanges();
            spAddProduct.DataContext = new Товар();

            product = new Товар();
            spAddProduct.DataContext = product;
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Товар товар = spAddProduct.DataContext as Товар;
            if (товар == null) return;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == true)
            {
                Stream fileStream = fileDialog.OpenFile();
                товар.image = new byte[fileStream.Length];
                fileStream.Read(товар.image, 0, (int)fileStream.Length);

                fileStream.Seek(0, SeekOrigin.Begin);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = fileStream;
                bitmap.EndInit();
                ImagePreview.Source = bitmap;

            }
        }

        private void MoveToStart(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Start);
        }

        private void MoveToAddCategory(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Category);
        }
    }
}
