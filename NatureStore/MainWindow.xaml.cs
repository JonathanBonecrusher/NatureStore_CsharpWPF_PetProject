using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace NatureStore
{
    public static class CurEmplayee
    {
        public static Employee emp;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        public static Employee emp = new Employee();
        public static Window Wind = Application.Current.MainWindow as MainWindow;
        public MainWindow()
        {
            //Wind = Application.Current.MainWindow as MainWindow;
            InitializeComponent();
            frame.Navigate(new Login());
        }

        public static void GetEmployee(Employee employee)
        {
            
            MainWindow mWind = Wind as MainWindow;
            if (employee.Job_Title != "Администратор")
            {
                mWind.EmployeeView1();
            }
            else
            {
                mWind.EmployeeView2();
            }
        }

        public void EmployeeView2()
        {
            Emplyee.Visibility = Visibility.Visible;
            Provider.Visibility = Visibility.Visible;
            Stock.Visibility = Visibility.Visible;
        }

        public void EmployeeView1()
        {
            Emplyee.Visibility = Visibility.Hidden;
            Provider.Visibility = Visibility.Hidden;
            Stock.Visibility = Visibility.Hidden;
        }

        private void Sale_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("/SalePage.xaml", UriKind.Relative));
            Emplyee.IsChecked = false;
            Stock.IsChecked = false;
            Session.IsChecked = false;
            Provider.IsChecked = false;
        }

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("/StockPage.xaml", UriKind.Relative));
            Emplyee.IsChecked = false;
            Sale.IsChecked = false;
            Session.IsChecked = false;
            Provider.IsChecked = false;
        }

        private void Emplyee_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("/EmployeePage.xaml", UriKind.Relative));
            Sale.IsChecked = false;
            Stock.IsChecked = false;
            Session.IsChecked = false;
            Provider.IsChecked = false;
        }

        private void Session_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("/SessionPage.xaml", UriKind.Relative));
            Emplyee.IsChecked = false;
            Stock.IsChecked = false;
            Sale.IsChecked = false;
            Provider.IsChecked = false;
        }

        private void Provider_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("/ProviderPage.xaml", UriKind.Relative));
            Emplyee.IsChecked = false;
            Stock.IsChecked = false;
            Sale.IsChecked = false;
            Session.IsChecked = false;

        }

        private void SideButton_Click(object sender, RoutedEventArgs e)
        {
            
            ColumnDefinition cd1 = new ColumnDefinition();
            cd1.Width = new GridLength(0.45, GridUnitType.Star);
            ColumnDefinition cd2 = new ColumnDefinition();
            cd2.Width = new GridLength(2, GridUnitType.Star);
            if (Side.Width == cd2.Width)
            {
                Side.Width = cd1.Width;
                Sale.Visibility = Visibility.Hidden;
                Stock.Visibility = Visibility.Hidden;
                Session.Visibility = Visibility.Hidden;
                Provider.Visibility = Visibility.Hidden;
                Emplyee.Visibility = Visibility.Hidden;
            }
            else
            {
                Side.Width = cd2.Width;
                Sale.Visibility = Visibility.Visible;
                Stock.Visibility = Visibility.Visible;
                Session.Visibility = Visibility.Visible;
                Provider.Visibility = Visibility.Visible;
                Emplyee.Visibility = Visibility.Visible;
            }
        }

        /*<StackPanel Grid.Row="0" Grid.Column= "0" Background= "#67d2f0" >
                < ToggleButton Visibility= "Hidden" Click= "SideButton_Click" x:Name= "SideButton" HorizontalAlignment= "Left" Margin= "10 30" Foreground= "#67d2f0" Background= "White" BorderBrush= "#2d9bba" BorderThickness= "4" FontSize= "42" Width= "65" >→</ToggleButton>
            </StackPanel>*/


    }
}
