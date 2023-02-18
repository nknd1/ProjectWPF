using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class SortItem
    {
        public string Name { get; set; }
        public SortDescription sort { get; set; }
    }
   
    public partial class ProductList : Page
    {
        connection connection;
        public List<SortItem> SortLists { get; set; }
        public SortItem SelectedSortItem { get; set; }

 
        public ProductList(connection connection)
            
        {
            InitializeComponent();
            this.connection = connection;

            Binding binding = new Binding();
            binding.Source = connection.Товар.ToList();
            ProductView.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            SortLists = new List<SortItem>() {
                new SortItem()
                {
                    Name = "Цена",
                    sort = new SortDescription( "по возрастанию (цена)", ListSortDirection.Ascending)
                }
            };
            SortLists = new List<SortItem>() {
                new SortItem()
                {
                    Name = "Цена",
                    sort = new SortDescription( "по убыванию (цена)", ListSortDirection.Descending)
                }
            };
            SortLists = new List<SortItem>() {
                new SortItem()
                {
                    Name = "Количество",
                    sort = new SortDescription( "по возрастанию (кличество)", ListSortDirection.Ascending)
                }
            };
            SortLists = new List<SortItem>() {
                new SortItem()
                {
                    Name = "Количество",
                    sort = new SortDescription( "по убыванию (количество)", ListSortDirection.Descending)
                }
            };

            DataContext = this;
        }
        private void ApplySort()
        {
            var view = CollectionViewSource.GetDefaultView(ProductView.ItemsSource);
            if (view == null || SelectedSortItem == null) return;

            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(SelectedSortItem.sort);
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySort();
      
        }
    }
}
