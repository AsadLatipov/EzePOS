using EzePOS.Business.Helper;
using EzePOS.Business.Models;
using EzePOS.Cashier.WindowUI.UserControls.HistoryPages;
using EzePOS.Cashier.WindowUI.Windows;
using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.Entities.Base;
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

namespace EzePOS.Cashier.WindowUI.UserControls.ReturnProduct
{
    /// <summary>
    /// Interaction logic for ReturnPage.xaml
    /// </summary>
    public partial class ReturnPage : UserControl
    {

        string card = "/Cashier/Assets/Icons/card.png";
        string mixed = "/Cashier/Assets/Icons/mixed.png";
        string cash = "/Cashier/Assets/Icons/coin.png";

        public DateTime _from;
        public DateTime _to;

        public ReturnPage()
        {
            InitializeComponent();
        }

        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                var selected = datagrid.SelectedItem as ShopWithItem;
                if (selected != null)
                {
                    List<ReturnItem> items = new List<ReturnItem>();
                    foreach (var item in selected.ShopItems)
                    {
                        items.Add(new ReturnItem { Item = item });
                    }
                    targetWindow.dashboard.returnEdit.Visibility = Visibility.Visible;
                    targetWindow.dashboard.returnEdit.items = items;
                    targetWindow.dashboard.returnEdit.shopdatagrid.ItemsSource = items;
                    targetWindow.dashboard.returnEdit.shopdatagrid.Items.Refresh();
                    targetWindow.dashboard.returnEdit.SetItems(selected);

                }
            }
            catch
            {

            }

        }
        public async void SetShopsWithSearch(int id)
        {
            try
            {

                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
                List<ShopWithItem> shopWithItem = new List<ShopWithItem>();


                var result = await targetWindow._shopService.GetAllAsync(obj => obj.Id == id);

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        shopWithItem.Add(new ShopWithItem { Shop = item });
                    }

                    foreach (var item in shopWithItem)
                    {
                        var items = await targetWindow._shopItemService.GetAllAsync(obj => obj.ShopId == item.Shop.Id);

                        item.ShopItems = items.Data.ToList();
                    }

                    datagrid.ItemsSource = shopWithItem;
                    datagrid.Items.Refresh();
                }
            }
            catch
            {

            }
        }
        public async void SetShops(DateTime from, DateTime to)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
                List<ShopWithItem> shopWithItem = new List<ShopWithItem>();

                BaseResponse<IEnumerable<Shop>> result = null;

                if (from == to)
                {
                    result = await targetWindow._shopService.GetAllAsync(obj => obj.CreatedAt.Date == from.Date);
                }

                else if (from.Date < to.Date)
                {
                    result = await targetWindow._shopService.GetAllAsync(obj => obj.CreatedAt.Date >= from.Date && obj.CreatedAt.Date <= to.Date);

                }
                else
                {
                    result = null;
                }
                if (result.Data != null)
                {
                    _from = from;
                    _to = to;

                    foreach (var item in result.Data)
                    {
                        shopWithItem.Add(new ShopWithItem { Shop = item });
                    }

                    foreach (var item in shopWithItem)
                    {
                        var items = await targetWindow._shopItemService.GetAllAsync(obj => obj.ShopId == item.Shop.Id);

                        item.ShopItems = items.Data.ToList();
                    }
                    datagrid.ItemsSource = shopWithItem;
                    datagrid.Items.Refresh();
                }
            }
            catch
            {

            }
        }
    }
    public class ReturnItem
    {
        public ShopItem Item { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Hidden;
        public Thickness Margin { get; set; } = new Thickness(0, 0, 10, 0);
        public bool DeleteStatus { get; set; } = false;
    }
}
