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

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEdit.xaml
    /// </summary>
    public partial class EmployeeEdit : Window
    {
        Employee tmpEmployee;
        public EmployeeEdit(Employee employee)
        {
            InitializeComponent();
            Employee_Name_View.Text = employee.Employee_Name;
            Job_Title_View.Text = employee.Job_Title;
            Login_View.Text = employee.Login;
            Password_View.Text = employee.Password;
            tmpEmployee = employee;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Employee_Name_View.Text != String.Empty && Job_Title_View.Text != String.Empty && Login_View.Text != String.Empty && Password_View.Text != String.Empty)
            {
                tmpEmployee.Employee_Name = Employee_Name_View.Text;
                tmpEmployee.Job_Title = Job_Title_View.Text;
                tmpEmployee.Login = Login_View.Text;
                tmpEmployee.Password = Password_View.Text;

                DatabaseControl.UpdateEmployee(tmpEmployee);

                gridRefEEE.listBox.ItemsSource = null;
                gridRefEEE.listBox.ItemsSource = DatabaseControl.GetEmployeeForView();
                Close();
            }
            else
            {
                MessageBox.Show("Неверное заполнение формы. Проверьте заполненные данные");
            }
        }
    }
}
