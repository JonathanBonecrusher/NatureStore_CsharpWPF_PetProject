using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
using System.Windows.Shapes;
using static NatureStore.Product;
using System.Windows.Threading;

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для SupplyInfo.xaml
    /// </summary>
    public partial class SupplyInfo : Window
    {
        public List<Product> products = new List<Product>();
        public List<Supply_Product> supply_products = new List<Supply_Product>();
        public List<Supply> supplies = new List<Supply>();

        TextBox amountTextBox;
        public SupplyInfo()
        {
            InitializeComponent();
            Provider_Name_View.Items.Clear();
            Provider_Name_View.ItemsSource = DatabaseControl.GetProviderForView();
            SupplyProductListBox.ItemsSource = products;
        }

        private void Provider_Name_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Provider_Name_View.SelectedItem != null)
            {
                Provider prvd = Provider_Name_View.SelectedItem as Provider;
                int prvdId = prvd.Provider_Id;

                Product_Name_View.ItemsSource = DatabaseControl.GetSupply_ProductForView(prvdId);
                Product_Name_View.Items.Refresh();
            }
        }

        private void Product_Name_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Product_Name_View.SelectedItem != null)
            {
                bool pr1 = false;
                Product prodvd = Product_Name_View.SelectedItem as Product;
                foreach (Product product in products)
                {
                    if (product == prodvd)
                    {
                        MessageBox.Show("Этот товар уже добавлен");
                        pr1 = true;
                        break;
                    }
                }

                if (pr1 == false)
                {
                    products.Add(prodvd);

                    Supply_Product supply_Product = new Supply_Product();
                    supply_Product.Product_Key = prodvd.Product_Id;
                    supply_Product.Supply_Key = 0;
                    //Here
                    supply_Product.Product_Amount = 0;
                    supply_products.Add(supply_Product);
                    SupplyProductListBox.Items.Refresh();
                }
            }
        }

        private void AmountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            amountTextBox = (TextBox)sender;
            DependencyObject dependencyObject = amountTextBox.TemplatedParent;
            Product prodObj = dependencyObject.GetValue(ContentControl.ContentProperty) as Product;
            if (amountTextBox.Text != String.Empty)
            {
                try
                {
                    int tbAmount = Convert.ToInt32(amountTextBox.Text);
                    foreach (Supply_Product supply in supply_products)
                    {
                        if (supply.Product_Key == prodObj.Product_Id && supply.Product_Amount >=0 && tbAmount >= 0)
                        {
                            supply.Product_Amount = tbAmount;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Введите число больше 0");
                    amountTextBox.Text = String.Empty;
                }
            }
        }
        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (SupplyProductListBox.SelectedItem != null)
            {
                Product product = SupplyProductListBox.SelectedItem as Product;
                foreach (Product product1 in products)
                {
                    if (product1.Product_Id == product.Product_Id)
                    {
                        products.Remove(product);
                        break;
                    }
                }
                foreach (Supply_Product supply in supply_products)
                {
                    if (supply.Product_Key == product.Product_Id)
                    {
                        supply_products.Remove(supply);
                        break;
                    }
                }
                SupplyProductListBox.Items.Refresh();
            }
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (supplies.Count == 0)
                {
                    Supply supply1 = new Supply();
                    supply1.Supply_Date = Convert.ToDateTime(Supply_Date_View.Text);
                    supply1.Provider_Key = products[0].Provider_Key;
                    supplies.Add(supply1);

                }

                foreach (Product product in products)
                {
                    bool supprod = true;
                    foreach (Supply supply in supplies)
                    {
                        if (supply.Provider_Key == product.Provider_Key)
                        {
                            supprod = false;
                        }
                    }
                    if (supprod == true)
                    {
                        Supply supplyprod = new Supply();
                        supplyprod.Supply_Date = Convert.ToDateTime(Supply_Date_View.Text);
                        supplyprod.Provider_Key = product.Provider_Key;
                        supplies.Add(supplyprod);
                    }
                }

                foreach (Supply supply2 in supplies)
                {
                    DatabaseControl.AddSupply(supply2);
                    List<Supply> allSupplys = DatabaseControl.GetSupplyForView();
                    Supply newSupply = allSupplys.Last();
                    bool supprod = false;
                    
                    foreach (Product product in products)
                    {
                        supprod = false;
                        if (newSupply.Provider_Key == product.Provider_Key)
                        {
                            supprod = true;
                        }

                        foreach (Supply_Product supply_Product in supply_products)
                        {
                            if (supprod == true && supply_Product.Product_Key == product.Product_Id)
                            {
                                if (supply_Product.Product_Amount <= 0)
                                {
                                    throw new Exception();
                                }
                            }
                        }

                        foreach (Supply_Product supply_Product in supply_products)
                        {
                            if (supprod == true && supply_Product.Product_Key == product.Product_Id)
                            {
                                supply_Product.Supply_Key = newSupply.Supply_Id;
                                product.Product_Amount = product.Product_Amount + supply_Product.Product_Amount;
                                DatabaseControl.UpdateProduct(product);
                                DatabaseControl.AddSupply_Product(supply_Product);
                            }
                        }
                        
                    }
                }
                gridRefE.grid.ItemsSource = null;
                gridRefE.grid.ItemsSource = DatabaseControl.GetProductForView();
                Close();
            }
            catch
            {
                MessageBox.Show("Проверьие введённые данные");
            }            
        }
    } 
}

