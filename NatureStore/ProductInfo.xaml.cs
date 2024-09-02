using Microsoft.EntityFrameworkCore.Infrastructure;
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
using System.Windows.Shapes;
using static NatureStore.Product;
using static NatureStore.Provider;

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        ComboBox tmpProvider;
        public ProductInfo()
        {
            InitializeComponent();
            Provider_Name_View.Items.Clear();
            Provider_Name_View.ItemsSource = DatabaseControl.GetProviderForView();
            tmpProvider = Provider_Name_View;
        }

        public void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Provider_Name_View.SelectedItem != null && Product_Name_View.Text != String.Empty && Product_Type_View.Text != String.Empty && Expiration_Date_View.Text != String.Empty && Product_Cost_View.Text != String.Empty)
            {
                if (decimal.TryParse(Product_Cost_View.Text, out decimal num) == true)
                {
                    Provider provider = Provider_Name_View.SelectedItem as Provider;
                    DatabaseControl.AddProduct(new Product
                    {
                        Product_Name = Product_Name_View.Text,
                        Product_Type = Product_Type_View.Text,
                        Product_Amount = 0,
                        Provider_Key = provider.Provider_Id,
                        Expiration_Date = Expiration_Date_View.Text,
                        Product_Cost = Convert.ToDecimal(Product_Cost_View.Text),

                    }); ;

                    gridRefE.grid.ItemsSource = null;
                    gridRefE.grid.ItemsSource = DatabaseControl.GetProductForView();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверное указание стоимости");
                }
                
            }else
            {
                MessageBox.Show("Неверное заполнение формы. Проверьте заполненные данные");
            }
        }
    }
}
