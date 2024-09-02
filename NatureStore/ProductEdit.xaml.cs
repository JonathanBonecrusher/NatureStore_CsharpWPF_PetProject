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

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Window
    {
        Product tempProduct;
        public ProductEdit(Product product)
        {
            InitializeComponent();
            Product_Name_View.Text = product.Product_Name;
            Product_Type_View.Text = product.Product_Type;
            Product_Cost_View.Text = Convert.ToString(product.Product_Cost);
            Expiration_Date_View.Text = product.Expiration_Date;
            tempProduct = product;
            int provId = product.Provider_Key;

        }

        public void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Product_Type_View.SelectedItem != null && Product_Name_View.Text != String.Empty && Product_Cost_View.Text != String.Empty && Expiration_Date_View.Text != String.Empty)
            {
                if ( decimal.TryParse(Product_Cost_View.Text, out decimal num) == true)
                {
                    tempProduct.Product_Name = Product_Name_View.Text;
                    tempProduct.Product_Type = Product_Type_View.Text;
                    tempProduct.Provider_Key = tempProduct.Provider_Key;
                    tempProduct.Product_Cost = Convert.ToDecimal(Product_Cost_View.Text);
                    tempProduct.Expiration_Date = Expiration_Date_View.Text;
                    tempProduct.Product_Amount = tempProduct.Product_Amount;

                    DatabaseControl.UpdateProduct(tempProduct);

                    gridRefE.grid.ItemsSource = null;
                    gridRefE.grid.ItemsSource = DatabaseControl.GetProductForView();
                    Close();
                }else
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
