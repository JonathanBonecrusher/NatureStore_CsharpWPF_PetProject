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
    /// Логика взаимодействия для ProviderInfo.xaml
    /// </summary>
    public partial class ProviderInfo : Window
    {
        public ProviderInfo()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Provider_Name_View.Text != String.Empty && Provider_Phone_View.Text != String.Empty && Prvider_Email_View.Text != String.Empty)
            {
                DatabaseControl.AddProvider(new Provider
                {
                    Provider_Name = Provider_Name_View.Text,
                    Provider_Phone = Provider_Phone_View.Text,
                    Provider_Email = Prvider_Email_View.Text,
                });

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
