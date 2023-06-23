using EzePOS.Business.Helper;
using EzePOS.Cashier.WindowUI.Windows;
using EzePOS.Infrastructure.Entities;
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

namespace EzePOS.Cashier.WindowUI.UserControls.HistoryPages
{
    /// <summary>
    /// Interaction logic for ShopItemsPage.xaml
    /// </summary>
    public partial class ShopItemsPage : UserControl
    {
        public ShopItemsPage()
        {
            InitializeComponent();
        }

        public void SetItems(ShopWithItem shop)
        {
            shopId_txt.Text = $"Savdo №{shop.Shop.Id}";
            time_txt.Text = shop.Shop.CreatedAt.ToString("HH:mm");
            dis_txt.Text = $"Cheg.:{shop.Shop.Discount}%";
            total_txt.Text = $"Umumiy: {shop.Shop.TotalAmount.Amount()}";

            dataGrid_products.ItemsSource = shop.ShopItems;
            dataGrid_products.Items.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.shopItems.Visibility = Visibility.Hidden;
        }
    }
}
