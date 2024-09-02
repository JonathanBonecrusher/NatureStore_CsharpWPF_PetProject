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
using static NatureStore.Employee;
using static System.Net.Mime.MediaTypeNames;

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для EmployeeInfo.xaml
    /// </summary>
    public partial class EmployeeInfo : Window
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Employee_Name_View.Text != String.Empty && Job_Title_View.Text != String.Empty && Login_View.Text != String.Empty && Password_View.Text != String.Empty)
            {
                DatabaseControl.AddEmployee(new Employee
                {
                    Employee_Name = Employee_Name_View.Text,
                    Job_Title = Job_Title_View.Text,
                    Login = Login_View.Text,
                    Password = Password_View.Text
                });

                gridRefEEE.listBox.ItemsSource = null;
                gridRefEEE.listBox.ItemsSource = DatabaseControl.GetEmployeeForView();
                Close();
            }else
            {
                MessageBox.Show("Неверное заполнение формы. Проверьте заполненные данные");
            }
        }
    }
}
