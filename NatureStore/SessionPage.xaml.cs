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

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        
        public SessionPage()
        {
            InitializeComponent();
            SalesListBox.Items.Clear();
            SalesListBox.ItemsSource = DatabaseControl.GetTurnoverForView();
            Date.Text = DateTime.Today.ToString();
            Employee.Text = CurEmplayee.emp.Employee_Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

        private void SalesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Turnover turnover_Product = SalesListBox.SelectedItem as Turnover;

                int TurnovId = turnover_Product.Turnover_Id;
                SaleInfo saleindo = new SaleInfo(TurnovId);
                saleindo.Show();
        }
    }
}
