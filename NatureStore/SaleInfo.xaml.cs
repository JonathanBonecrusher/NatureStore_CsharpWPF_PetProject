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
    /// Логика взаимодействия для SaleInfo.xaml
    /// </summary>
    public partial class SaleInfo : Window
    {
        public SaleInfo(int TurnoverId)
        {
            InitializeComponent();
            int tId = TurnoverId;
            SaleProductListBox.Items.Clear();
            SaleProductListBox.ItemsSource = DatabaseControl.GetTurnover_ProductForView(tId);
        }
    }
}
