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
using static NatureStore.SalePage;

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для SalePage.xaml
    /// </summary>
    public partial class SalePage : Page
    {
        public List<Product> products = new List<Product>();
        TextBox amountTextBox;
        public class ProductCost
        {
            public decimal cost;
            public int prodId;
            public int amountProd;
        }
        List<ProductCost> costList = new List<ProductCost>();
        public SalePage()
        {
            InitializeComponent();
            StockListBox.Items.Clear();
            StockListBox.ItemsSource = DatabaseControl.GetProductForView();
            SaleProductListBox.Items.Clear();
            SaleProductListBox.ItemsSource = products;
            TotalCost.Text = Convert.ToString(0);
        }

        private void StockListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StockListBox.SelectedItem != null)
            {
                bool pr1 = false;
                Product product = StockListBox.SelectedItem as Product;

                foreach (Product product1 in products)
                {
                    if (product1 == product)
                    {
                        MessageBox.Show("Этот товар уже добавлен");
                        pr1 = true;
                        break;
                    }
                }
                if (pr1 == false)
                {
                    products.Add(product);
                    ProductCost cost = new ProductCost();
                    cost.prodId = product.Product_Id;
                    cost.cost = 0;
                    cost.amountProd = 0;
                    costList.Add(cost);
                    SaleProductListBox.Items.Refresh();
                }
            }
            
        }

        private void AmountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            amountTextBox = (TextBox)sender;
            DependencyObject dependencyObject = amountTextBox.TemplatedParent;
            Product prodObj = dependencyObject.GetValue(ContentControl.ContentProperty) as Product;
            decimal totalCost = 0;
            if (amountTextBox.Text != String.Empty)
            {
                try
                {
                    int cost2 = Convert.ToInt32(amountTextBox.Text);
                    if(cost2 > 0)
                    {
                        foreach (ProductCost productCost in costList)
                        {
                            if (productCost.prodId == prodObj.Product_Id)
                            {
                                productCost.cost = cost2 * prodObj.Product_Cost;
                                productCost.amountProd = cost2;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Продукт удалён");
                        SaleProductListBox.Items.Refresh();
                        foreach (Product product1 in products)
                        {
                            if (product1.Product_Id == prodObj.Product_Id)
                            {
                                products.Remove(prodObj);
                                
                                break;
                            }
                        }
                        foreach (ProductCost productCost in costList)
                        {
                            if (productCost.prodId == prodObj.Product_Id)
                            {
                                costList.Remove(productCost);
                                break;
                            }
                        }
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Введите число");
                    amountTextBox.Text = String.Empty;
                    foreach (Product product1 in products)
                    {
                        if (product1.Product_Id == prodObj.Product_Id)
                        {
                            products.Remove(prodObj);

                            break;
                        }
                    }
                    foreach (ProductCost productCost in costList)
                    {
                        if (productCost.prodId == prodObj.Product_Id)
                        {
                            costList.Remove(productCost);
                            break;
                        }
                    }
                }
            }else
            {
                foreach (ProductCost productCost in costList)
                {
                    if (productCost.prodId == prodObj.Product_Id)
                    {
                        productCost.amountProd = 0;
                        productCost.cost = 0;
                        break;
                    }
                }
            }
            foreach(ProductCost productCost1 in costList)
            {
                totalCost += productCost1.cost;
            }
            TotalCost.Text = Convert.ToString(totalCost);
            //SaleProductListBox.Items.Refresh();
        }

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            int prdAmount = 0;
            Turnover turnover = new Turnover();
            Turnover newTurnover = new Turnover();
            try
            {
                turnover.Turnover_Date = DateTime.Now;
                turnover.Employee_Key = CurEmplayee.emp.Employee_Id; 
                turnover.Turnover_Amount = Convert.ToDecimal(TotalCost.Text);
                DatabaseControl.AddTurnover(turnover);
                List<Turnover> allTurnover = DatabaseControl.GetTurnoverForView();
                newTurnover = allTurnover.Last();
                if(products.Count == 0)
                {
                    throw new Exception("Продажа не может быть проведена");
                    
                }
                foreach (ProductCost productCost1 in costList)
                {
                    if (productCost1.amountProd <= 0)
                    {
                        throw new Exception("Продажа не может быть проведена");
                    }
                }
                foreach (Product product in products)
                {
                    foreach (ProductCost productCost in costList)
                    {
                        if (productCost.prodId == product.Product_Id)
                        {
                            if (productCost.amountProd > product.Product_Amount && productCost.amountProd > 0)
                            {
                                throw new Exception("Продажа не может быть проведена");
                            }
                            else
                            {
                                prdAmount = productCost.amountProd;
                            }
                        }
                    }
                    product.Product_Amount = product.Product_Amount - prdAmount;
                    Turnover_Product turnover_Product = new Turnover_Product();
                    turnover_Product.Product_Key = product.Product_Id;
                    turnover_Product.Turnover_Key = newTurnover.Turnover_Id;
                    turnover_Product.Product_Amount = prdAmount;
                    DatabaseControl.AddTurnover_Product(turnover_Product);
                    DatabaseControl.UpdateProduct(product);
                }
                costList.Clear();
                products.Clear();
                TotalCost.Text = "0";
                StockListBox.Items.Refresh();
                SaleProductListBox.Items.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //DatabaseControl.RemoveTurnover(newTurnover);
            }           
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                StockListBox.ItemsSource = ctx.Product.Where(c => c.Product_Name.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
            }
        }
    }
}
