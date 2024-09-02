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
using System.Xml.Linq;
using static NatureStore.Provider;
namespace NatureStore
{
    /// <summary>
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        public ProviderPage()
        {
            InitializeComponent();
            ProviderListBox.Items.Clear();
            ProviderListBox.ItemsSource = DatabaseControl.GetProviderForView();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            gridRefEE.listBox = ProviderListBox;

            ProviderInfo providerIndo = new ProviderInfo();
            providerIndo.Show();
        }

        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProviderListBox.SelectedItem != null)
            {
                Provider provider = ProviderListBox.SelectedItem as Provider;

                DatabaseControl.RemoveProvider(provider);

                ProviderListBox.ItemsSource = null;
                ProviderListBox.ItemsSource = DatabaseControl.GetProviderForView();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProviderListBox.SelectedItem != null) 
            {
                gridRefEE.listBox = ProviderListBox;
                Provider provider = ProviderListBox.SelectedItem as Provider;

                ProviderEdit providerInfo = new ProviderEdit(provider);
                providerInfo.Show();
            }
        }

        private void ProviderListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ProviderListBox.ItemsSource = ctx.Provider.Where(c => c.Provider_Name.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
            }
        }
    }
}
