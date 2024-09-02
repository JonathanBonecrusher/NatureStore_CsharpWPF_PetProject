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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            
            InitializeComponent();
        }
        private void enter_Click(object sender, RoutedEventArgs e)
        {

            // frame.Navigate(new home());
            
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            string eLogin = log.Text;
            string ePassword = password.Password;
            bool r = false;
            List<Employee> employees = DatabaseControl.GetEmployeeForView();
            foreach (Employee employee in employees) 
            {
                if (employee.Login == eLogin && employee.Password == ePassword) 
                {
                    CurEmplayee.emp = employee;
                    MainWindow.GetEmployee(employee);
                    NavigationService.Navigate(new Uri("/SessionPage.xaml", UriKind.Relative));
                    r= true;
                    break;
                }
            }
            if (!r)
            {
                MessageBox.Show("Даные введены неверно");
            }
        }
    }
}
