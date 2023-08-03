using EzePOS.Business.Helper;
using EzePOS.Business.Models;
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

namespace EzePOS.Cashier.WindowUI.UserControls.HistoryPages
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : UserControl
    {
        List<Item> items = new List<Item>();
        //public List<Order> orders = new List<Order>();

        string card = "/Cashier/Assets/Icons/card_card.png";
        string mixed = "/Cashier/Assets/Icons/mixed.png";

        public History()
        {
            InitializeComponent();
            items.Add(new Item { Id = 1, Name = "Umumiy savdo", Amount = "100 000", Image = "/Cashier/Assets/Icons/total_shop.png", Visibility = Visibility.Visible });
            items.Add(new Item { Id = 2, Name = "Kartaga", Amount = "100 000", Image = "/Cashier/Assets/Icons/card_card.png" });
            items.Add(new Item { Id = 3, Name = "Naqd", Amount = "100 000", Image = "/Cashier/Assets/Icons/cash.png" });
            items.Add(new Item { Id = 4, Name = "Aralash", Amount = "100 000", Image = "/Cashier/Assets/Icons/mixed.png" });
            items.Add(new Item { Id = 5, Name = "Kassaga pul qo'yish/olish", Amount = "+100 000, -100 000", Image = "/Cashier/Assets/Icons/put_money_image.png" });
            items.Add(new Item { Id = 6, Name = "Nasiya", Amount = "100 000", Image = "/Cashier/Assets/Icons/exchange_image.png" });
            items.Add(new Item { Id = 7, Name = "Qaytarildi", Amount = "100 000", Image = "/Cashier/Assets/Icons/history_of_sale_image.png" });
            items.Add(new Item { Id = 8, Name = "Nasiya qaytarildi", Amount = "100 000", Image = "/Cashier/Assets/Icons/exchange_image.png" });

            itemsControl.ItemsSource = items;
            itemsControl.Items.Refresh();

            //orders.Add(new Order { Id = 1, Date = "09:08", Image = card, Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            //orders.Add(new Order { Id = 2, Date = "10:28", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            //orders.Add(new Order { Id = 3, Date = "09:08", Image = mixed, Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            //orders.Add(new Order { Id = 4, Date = "09:08", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            //orders.Add(new Order { Id = 5, Date = "09:08", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            //datagrid.ItemsSource = orders;
            //datagrid.Items.Refresh();
        }

        public async void SetShops(DateTime from, DateTime to)
        {
            try
            {
                double total = 0;
                double card = 0;
                double cash = 0;
                double mixed = 0;
                double debt = 0;
                double incash = 0;

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
                    foreach (var item in result.Data)
                    {
                        shopWithItem.Add(new ShopWithItem { Shop = item });
                        total += item.TotalAmount;
                        card += item.Card;
                        cash += item.Cash;
                        debt += item.Debt;
                    }

                    mixed = cash + card;
                    incash = total - debt;

                    items.FirstOrDefault(obj => obj.Id == 1).Amount = total.Amount(); // Umumiy savdo
                    items.FirstOrDefault(obj => obj.Id == 2).Amount = card.Amount(); // Karta
                    items.FirstOrDefault(obj => obj.Id == 3).Amount = cash.Amount(); // Naqd
                    items.FirstOrDefault(obj => obj.Id == 4).Amount = mixed.Amount(); // Aralash
                    items.FirstOrDefault(obj => obj.Id == 6).Amount = debt.Amount(); // Nasiya
                    incash_txt.Text = incash.Amount(); // Kassada bo'lishi kerak

                    itemsControl.ItemsSource = items;
                    itemsControl.Items.Refresh();


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
        private void item_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in items)
                {
                    item.Visibility = Visibility.Hidden;
                }
                var btn = sender as Button;

                int buttonId = int.Parse(btn.Tag.ToString());

                items.Where(obj => obj.Id == buttonId).FirstOrDefault().Visibility = Visibility.Visible;

                itemsControl.ItemsSource = items;
                itemsControl.Items.Refresh();
            }
            catch
            {

            }
        }
        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                var result = datagrid.SelectedItem as ShopWithItem;

                if(result != null)
                {
                    targetWindow.dashboard.shopItems.Visibility = Visibility.Visible;
                    targetWindow.dashboard.shopItems.SetItems(result);

                }
            }
            catch
            {

            }
        }

        private void datagrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
;
            var result = datagrid.SelectedItem as ShopWithItem;

            if (result != null)
            {

                object aa = new object();
                RoutedEventArgs aaa = new RoutedEventArgs();
                targetWindow.dashboard.searchpart.cancel_Click(aa, aaa);
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            ;
            var result = datagrid.SelectedItem as ShopWithItem;

            if (result != null)
            {

                object aa = new object();
                RoutedEventArgs aaa = new RoutedEventArgs();
                targetWindow.dashboard.searchpart.cancel_Click(aa, aaa);
            }
        }
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Image { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Hidden;
    }

    public class ShopWithItem
    {
        public Shop Shop { get; set; }
        public List<ShopItem> ShopItems { get; set; }
        public string Date
        {
            get { return Shop.CreatedAt.ToString("dd-MM-yyyy"); }
        }
        public string Products
        {
            get
            {
                string names = " ";
                foreach(var item in ShopItems)
                {
                    names += " " + item.ProductName;
                }
                return names;
            }
        }
        public string Image
        {
            get
            {
                if(Shop.Cash == 0 && Shop.Card > 0)
                {
                    return "/Cashier/Assets/Icons/card_card.png";
                }
                else if(Shop.Card == 0 && Shop.Cash > 0)
                {
                    return "/Cashier/Assets/Icons/cash.png";
                }
                else if(Shop.Card > 0 && Shop.Cash > 0)
                {
                    return "/Cashier/Assets/Icons/mixed.png";
                }
                else
                {
                    return "/Cashier/Assets/Icons/cash.png";
                }
            }
        }
    }

    
    //public class Order
    //{
    //    public int Id { get; set; }
    //    public string Date { get; set; }
    //    public string Products { get; set; }
    //    public string Cost { get; set; }
    //    public string Discount { get; set; }
    //    public string Image { get; set; } = "/Cashier/Assets/Icons/cash.png";
    //}
}
