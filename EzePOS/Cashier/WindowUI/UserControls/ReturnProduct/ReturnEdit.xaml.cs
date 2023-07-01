using EzePOS.Business.Helper;
using EzePOS.Cashier.WindowUI.Windows;
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

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.returnEdit.Visibility = Visibility.Hidden;
            if (timer != null)
            {
                timer.Stop();
            }
        }



        DateTime mouseDown;
        bool deleteChecker = false;
        int a = 0;
        private void shopdatagrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                a++;
                mouseDown = DateTime.Now.AddSeconds(0.9);
                deleteChecker = true;
                DeleteAction();
            }
            catch
            {

            }
        }
        private void shopdatagrid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                deleteChecker = false;
                if (timer != null)
                {
                    timer.Stop();
                }
            }
            catch
            {

            }
        }
        DateTime OnClickButton;

        private void DataGridRow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            onSelection = DateTime.Now;
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

        DateTime onSelection;
        private void shopdatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                onSelection = DateTime.Now;
                selectedItem = shopdatagrid.SelectedItem as ReturnItem;
            }
            catch
            {

            }
        }

        DispatcherTimer timer;

        public void DeleteAction()
        {
            try
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(0.9);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            catch
            {

            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                List<ReturnItem> products = items;

                if (deleteChecker)
                {
                    if (onSelection.AddSeconds(1.2) > DateTime.Now)
                    {
                        if (DateTime.Now >= mouseDown)
                        {
                            //MessageBox.Show($"Mouse was held down for > 3 seconds!{a}");
                            foreach (ReturnItem obj in products)
                            {
                                obj.Margin = new Thickness(15, 0, 10, 0);
                                obj.Visibility = Visibility.Visible;
                            }
                            BrushConverter bc = new BrushConverter();
                            Brush brush = (Brush)bc?.ConvertFrom("#F50000");
                            brush?.Freeze();
                            products.Where(obj => obj.Item.Id == selectedItem.Item.Id).FirstOrDefault().DeleteStatus = true;
                            if (timer != null)
                            {
                                timer.Stop();
                            }
                            shopdatagrid.ItemsSource = items;
                            shopdatagrid.Items.Refresh();
                        }
                    }
                }
                else
                {
                    if (timer != null)
                    {
                        timer.Stop();
                    }
                }
            }
            catch
            {

            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (shopdatagrid.SelectedItem as ReturnItem != null)
                //{
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                List<ReturnItem> shops = items;

                shops.Where(obj => obj.Item.Id == (shopdatagrid.SelectedItem as ReturnItem).Item.Id).FirstOrDefault().DeleteStatus = false;
                total -= shops.Where(obj => obj.Item.Id == (shopdatagrid.SelectedItem as ReturnItem).Item.Id).FirstOrDefault().Item.ProductSellingPrice;
                total_btn.Content = $"Qaytarish {total.Amount()}";
                canEnter = true;

                if (shops.All(obj => obj.DeleteStatus == false))
                {
                    foreach (ReturnItem obj in shops)
                    {
                        obj.Margin = new Thickness(0, 0, 10, 0);
                        obj.Visibility = Visibility.Hidden;
                        select_all_btn.Visibility = Visibility.Visible;
                        unselect_all_btn.Visibility = Visibility.Hidden;
                    }
                    BrushConverter bc = new BrushConverter();
                    Brush brush = (Brush)bc?.ConvertFrom("#0C7C80");
                    brush?.Freeze();
                    //delete_btn.Background = brush;
                    shopdatagrid.ItemsSource = items;
                    shopdatagrid.Items.Refresh();
                    //Checker = true;
                }
                //}
            }
            catch
            {

            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            try
            {
                //if (shopdatagrid.SelectedItem as ReturnEdit != null)
                //{
                if (canEnter)
                {
                    var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                    List<ReturnItem> shops = items;

                    shops.Where(obj => obj.Item.Id == (shopdatagrid.SelectedItem as ReturnItem).Item.Id).FirstOrDefault().DeleteStatus = true;

                    total += shops.Where(obj => obj.Item.Id == (shopdatagrid.SelectedItem as ReturnItem).Item.Id).FirstOrDefault().Item.ProductSellingPrice;
                    total_btn.Content = $"Qaytarish {total.Amount()}";
                }

                //}
            }
            catch
            {

            }
        }
        bool canEnter = true;
        private void select_all_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                select_all_btn.Visibility = Visibility.Hidden;
                unselect_all_btn.Visibility = Visibility.Visible;

                total = 0;
                items.ForEach(item => { item.DeleteStatus = true; total += item.Item.ProductSellingPrice; item.Visibility = Visibility.Visible; item.Margin = new Thickness(15, 0, 10, 0); });
                shopdatagrid.ItemsSource = items;
                shopdatagrid.Items.Refresh();
                total_btn.Content = $"Qaytarish {total.Amount()}";
                canEnter = false;
            }
            catch
            {

            }
        }

        private void unselect_all_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                select_all_btn.Visibility = Visibility.Visible;
                unselect_all_btn.Visibility = Visibility.Hidden;

                items.ForEach(item => { item.DeleteStatus = false; item.Visibility = Visibility.Hidden; item.Margin = new Thickness(0, 0, 10, 0); });
                shopdatagrid.ItemsSource = items;
                shopdatagrid.Items.Refresh();

                total = 0;
                total_btn.Content = $"Qaytarish {total.Amount()}";
            }
            catch
            {

            }
        }

        private void cancel_delete_window_btn_Click(object sender, RoutedEventArgs e)
        {
            retun_window.Visibility = Visibility.Hidden;
            if (timer != null)
            {
                timer.Stop();
            }

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
                    if (timer != null)
                    {
                        timer.Stop();
                    }
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
            if (timer != null)
            {
                timer.Stop();
            }
        }
    }
}
