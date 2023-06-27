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

namespace EzePOS.Cashier.WindowUI.UserControls.ReturnProduct
{
    /// <summary>
    /// Interaction logic for ReturnPage.xaml
    /// </summary>
    public partial class ReturnPage : UserControl
    {
        public List<Order> orders = new List<Order>();

        string card = "/Cashier/Assets/Icons/card.png";
        string mixed = "/Cashier/Assets/Icons/mixed.png";
        string cash = "/Cashier/Assets/Icons/coin.png";
        public ReturnPage()
        {
            InitializeComponent();
            orders.Add(new Order { Id = 1, Date = "09:08", Image = card, Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            orders.Add(new Order { Id = 2, Date = "10:28", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            orders.Add(new Order { Id = 3, Date = "09:08", Image = mixed, Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            orders.Add(new Order { Id = 4, Date = "09:08", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            orders.Add(new Order { Id = 5, Date = "09:08", Products = "Coca-Cola, buhanka non", Discount = "10%", Cost = "100 000" });
            datagrid.ItemsSource = orders;
            datagrid.Items.Refresh();
        }

        private async void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;


            //List<Product> products = new List<Product>();
            //var temp = await targetWindow._productService.GetAllAsync();
            //products = temp.Data.ToList();

            //List<ReturnItem> items = new List<ReturnItem>();
            //foreach (var item in products)
            //{
            //    if (item.ProductId < 5)
            //    {
            //        items.Add(new ReturnItem { Product = item });
            //    }
            //}

            //targetWindow.dashboard.returnEdit.Visibility = Visibility.Visible;
            //targetWindow.dashboard.returnEdit.items = items;
            //targetWindow.dashboard.returnEdit.shopdatagrid.ItemsSource = items;
            //targetWindow.dashboard.returnEdit.shopdatagrid.Items.Refresh();
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Products { get; set; }
        public string Cost { get; set; }
        public string Discount { get; set; }
        public string Image { get; set; } = "/Cashier/Assets/Icons/coin.png";
    }

    public class ReturnItem
    {
        public Product Product { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Hidden;
        public Thickness Margin { get; set; } = new Thickness(0, 0, 10, 0);
        public bool DeleteStatus { get; set; } = false;
    }
}
