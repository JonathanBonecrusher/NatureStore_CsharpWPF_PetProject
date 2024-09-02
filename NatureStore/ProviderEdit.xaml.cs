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
using static NatureStore.Provider;

namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для ProviderEdit.xaml
    /// </summary>
    public partial class ProviderEdit : Window
    {
        Provider tempProvider;
        public ProviderEdit(Provider provider)
        {
            InitializeComponent();
            Provider tmpProvider = provider;
            Provider_Name_View.Text = provider.Provider_Name;
            Provider_Phone_View.Text = provider.Provider_Phone;
            Provider_Email_View.Text = provider.Provider_Email;
            tempProvider = provider;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Provider_Name_View.Text != String.Empty && Provider_Phone_View.Text != String.Empty && Provider_Email_View.Text != String.Empty)
            {
                tempProvider.Provider_Name = Provider_Name_View.Text;
                tempProvider.Provider_Phone = Provider_Phone_View.Text;
                tempProvider.Provider_Email = Provider_Email_View.Text;

                DatabaseControl.UpdateProvider(tempProvider);

                gridRefEE.listBox.ItemsSource = null;
                gridRefEE.listBox.ItemsSource = DatabaseControl.GetProviderForView();
                Close();
            }else
            {
                MessageBox.Show("Неверное заполнение формы. Проверьте заполненные данные");
            }
            
        }
    }
}
