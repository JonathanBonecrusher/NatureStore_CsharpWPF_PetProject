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
using static NatureStore.Employee;
using static NatureStore.Provider;

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            EmployeeListBox.Items.Clear();
            EmployeeListBox.ItemsSource = DatabaseControl.GetEmployeeForView();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            gridRefEEE.listBox = EmployeeListBox;

            EmployeeInfo employeeInfo = new EmployeeInfo();
            employeeInfo.Show();
        }

        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListBox.SelectedItem != null)
            {
                Employee employee = EmployeeListBox.SelectedItem as Employee;

                DatabaseControl.RemoveEmployee(employee);

                EmployeeListBox.ItemsSource = null;
                EmployeeListBox.ItemsSource = DatabaseControl.GetEmployeeForView();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeeListBox.SelectedItem != null)
            {
                gridRefEEE.listBox = EmployeeListBox;
                Employee employee = EmployeeListBox.SelectedItem as Employee;

                EmployeeEdit employeeEdit = new EmployeeEdit(employee);
                employeeEdit.Show();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                EmployeeListBox.ItemsSource = ctx.Employee.Where(c => c.Employee_Name.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
            }
        }
    }
}
