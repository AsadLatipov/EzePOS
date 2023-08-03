using EzePOS.Business.Helper;
using EzePOS.Cashier.WindowUI.UserControls.HistoryPages;
using EzePOS.Cashier.WindowUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace EzePOS.Cashier.WindowUI.UserControls.ReturnProduct
{
    /// <summary>
    /// Interaction logic for ReturnEdit.xaml
    /// </summary>
    public partial class ReturnEdit : UserControl
    {
        ReturnItem selectedItem = new ReturnItem();
        public List<ReturnItem> items = new List<ReturnItem>();
        public double total = 0;
        public ReturnEdit()
        {
            InitializeComponent();
        }

        public void SetItems(ShopWithItem shop)
        {
            shopId_txt.Text = $"Savdo №{shop.Shop.Id}";
            time_txt.Text = shop.Shop.CreatedAt.ToString("HH:mm");
            dis_txt.Text = $"{shop.Shop.Discount}%";
            total_txt.Text = $"Umumiy: {shop.Shop.TotalAmount.Amount()}";
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.returnEdit.Visibility = Visibility.Hidden;
        }




        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    if (DateTime.Now > OnClickButton.AddSeconds(0.4))
            //    {
            //        ShopModel shop = shopdatagrid.SelectedItem as ShopModel;
            //        var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            //        //targetWindow.dashboard.rightEdit.SetProduct(shop);
            //        //targetWindow.dashboard.rightEdit.Visibility = Visibility.Visible;
            //    }
            //}
            //catch
            //{

            //}
        }

        private void cancel_delete_window_btn_Click(object sender, RoutedEventArgs e)
        {
            retun_window.Visibility = Visibility.Hidden;
            
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            return_sum.Visibility = Visibility.Visible;
        }

        private void total_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (total > 0)
                {
                    retun_window.Visibility = Visibility.Visible;
                }
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            return_sum.Visibility = Visibility.Hidden;
            retun_window.Visibility = Visibility.Hidden;

            targetWindow.dashboard.returnEdit.Visibility = Visibility.Hidden;
          
        }
      

        private void exit_second_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            edit_window.Visibility = Visibility.Hidden;
            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

        }

        private void shopdatagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = shopdatagrid.SelectedItem as ReturnItem;

            if(temp.Item != null)
            {
                product_name.Text = temp.Item.ProductName;
                product_cost.Text = temp.Item.ProductSellingPrice.Amount();
                product_count.Text = temp.Item.Count.ToString();
                return_count.Text = temp.Item.Count.ToString();
                selectedItem = temp;

            }
            edit_window.Visibility = Visibility.Visible;
        }

        private void return_count_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
            }

            catch
            {
            }
        }
        public void WriteCount(string text)
        {
            try
            {
                Regex regex = new Regex("[^0-9^]");
                bool temp = regex.IsMatch(text);
                if (temp == false)
                {
                    double number = double.Parse(text);
                    if (number <= selectedItem.Item.Count)
                    {
                        return_count.Text += text;
                    }
                }
                return_count.Focus();
                return_count.CaretIndex = return_count.Text.Length;
            }
            catch
            {

            }
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;
        }
    }

   

    
}
