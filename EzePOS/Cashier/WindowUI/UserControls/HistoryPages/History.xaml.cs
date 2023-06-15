﻿using EzePOS.Cashier.WindowUI.Windows;
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
        public List<Order> orders = new List<Order>();

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

            orders.Add(new Order { Id = 1, Date = "09:08", Image = card, Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            orders.Add(new Order { Id = 2, Date = "10:28", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            orders.Add(new Order { Id = 3, Date = "09:08", Image = mixed, Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            orders.Add(new Order { Id = 4, Date = "09:08", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            orders.Add(new Order { Id = 5, Date = "09:08", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            datagrid.ItemsSource = orders;
            datagrid.Items.Refresh();
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

        private async void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            //    targetWindow.dashboard.shopItems.Visibility = Visibility.Visible;

            //    targetWindow.dashboard.shopItems.shopType.Text = items.Where(obj => obj.Visibility == Visibility.Visible).FirstOrDefault().Name;


            //    var temp = await targetWindow._productService.GetAllAsync();

            //    targetWindow.dashboard.shopItems.dataGrid_products.ItemsSource = temp.Data.ToList();
            //    targetWindow.dashboard.shopItems.dataGrid_products.Items.Refresh();
            //}
            //catch
            //{

            //}
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

    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Products { get; set; }
        public string Cost { get; set; }
        public string Discount { get; set; }
        public string Image { get; set; } = "/Cashier/Assets/Icons/cash.png";
    }
}