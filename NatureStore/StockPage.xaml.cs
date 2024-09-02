using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using static NatureStore.Product;

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для StockPage.xaml
    /// </summary>
    public partial class StockPage : Page
    {
        List<Product> selectedproducts = new List<Product>();
        
        public StockPage()
        {
            InitializeComponent();
            ProductDataGridView.ItemsSource = DatabaseControl.GetProductForView();
            List<Supply_Product> supply_Products =  DatabaseControl.GetProduct_SupplyForView();
            int productAmount = supply_Products.GroupBy(x => x.Product_Key).Count();


        }
        private void SelectButton_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (ProductDataGridView.SelectedItem != null && cb.IsChecked == true)
            {
                Product product = ProductDataGridView.SelectedItem as Product;
                selectedproducts.Add(product);
            } 
        }

        private void SelectButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (ProductDataGridView.SelectedItem != null && cb.IsChecked == false)
            {
                Product product = ProductDataGridView.SelectedItem as Product;
                selectedproducts.Remove(product);
            }
        }

        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGridView.SelectedItem != null || selectedproducts.Count < 1)
            {
                foreach (Product element in selectedproducts)
                {
                    DatabaseControl.RemoveProduct(element);
                }
                ProductDataGridView.ItemsSource = null;
                ProductDataGridView.ItemsSource = DatabaseControl.GetProductForView();
                selectedproducts.Clear();
            }
            else
            {
                MessageBox.Show("Выделите минимум 1 продукт для удаления");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductDataGridView.SelectedItem != null && selectedproducts.Count == 1) {

                gridRefE.grid = ProductDataGridView;

                ProductEdit productindo = new ProductEdit(selectedproducts[0]);
                productindo.Show();
                selectedproducts.Clear();
            }
            else
            {
                MessageBox.Show("Выделите только 1 продукт");
            }  
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            gridRefE.grid = ProductDataGridView;
            ProductInfo productindo = new ProductInfo();
            productindo.Show();
            selectedproducts.Clear();
        }

        public void UpdateStock()
        {
            ProductDataGridView.ItemsSource = null;
            ProductDataGridView.ItemsSource = DatabaseControl.GetProductForView();
        }

        private void SupplyButton_Click(object sender, RoutedEventArgs e)
        {
            gridRefE.grid = ProductDataGridView;
            SupplyInfo supplyInfo = new SupplyInfo();
            supplyInfo.Show();
            selectedproducts.Clear();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ProductDataGridView.ItemsSource = ctx.Product.Where(c => c.Product_Name.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
            }
        }
    }
}
