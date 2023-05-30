using EzePOS.Business.Models;
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
using System.Windows.Threading;

namespace EzePOS.Cashier.WindowUI.UserControls.SalesPages
{
    /// <summary>
    /// Interaction logic for SalesPanel.xaml
    /// </summary>
    public partial class SalesPanel : UserControl
    {
        List<Product> products = new List<Product>();
        List<Category> categories = new List<Category>();
        ShopModel SelectedShop = new ShopModel();
        public int CategoryId = 0;

        public SalesPanel()
        {
            InitializeComponent();
            //Refresh();
            SetCategory();
            ChangingCategories();
        }



        public async void SetCategory()
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
                var temp = await targetWindow._categoryService.GetAllAsync();
                categories = temp.Data.ToList();
                ChangeCategory(0);

            }
            catch
            {

            }
        }



        public async void ChangeCategory(int ButtonId)
        {
            try
            {
                Category result = new Category();
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                foreach (var category in categories)
                {
                    category.Color = "#FFFFFF";
                    category.Foreground = "Black";
                }
                if (ButtonId == 0)
                {
                    result = categories.FirstOrDefault();
                }
                else
                {
                    result = categories.Where(obj => obj.Id == ButtonId).FirstOrDefault();
                }
                result.Color = "#09C5A3";
                result.Foreground = "#FFFFFF";
                var temp = await targetWindow._productService.GetAllAsync(obj => obj.CategoryId == result.Id);

                products = temp.Data.ToList();
                categoryControl.ItemsSource = categories;
                categoryControl.Items.Refresh();

                productsControl.ItemsSource = products;
                productsControl.Items.Refresh();
                CategoryId = result.Id;
            }
            catch
            {

            }

        }
        public void ChangingCategories()
        {
            //try
            //{
            //    DispatcherTimer timer = new DispatcherTimer();
            //    timer.Interval = TimeSpan.FromSeconds(5);
            //    timer.Tick += PermanentUpdateCategory;
            //    timer.Start();
            //}
            //catch
            //{

            //}
        }

        private async void PermanentUpdateCategory(object sender, EventArgs e)
        {
            //try
            //{
            //    var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            //    var temp = await targetWindow._categoryService.GetAllAsync();
            //    categories = temp.Data.ToList();
            //    ChangeCategory(CategoryId);
            //}
            //catch
            //{

            //}
        }

        private void category_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = sender as Button;
                ChangeCategory(int.Parse(btn.Tag.ToString()));
                //barcodeReader_txt.Focus();
            }
            catch
            {
                //barcodeReader_txt.Focus();
            }
        }
        private void productsList_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = sender as Button;
                AddProduct(int.Parse(btn.Tag.ToString()));
                //barcodeReader_txt.Focus();
            }
            catch
            {
                //barcodeReader_txt.Focus();
            }
        }
        public async void AddProduct(int productId)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                List<ShopModel> Items = targetWindow.dashboard.cash_navbar.GetPageItems();

                var product = await targetWindow._productService.GetAsync(obj => obj.Id == productId);

                var result = Items.Where(obj => obj.Product.Id == productId).FirstOrDefault();

                if (result != null)
                {
                    result.Count += 1;
                    //targetWindow.dashboard.productname_txt.Text = result.Name;
                    //targetWindow.dashboard.calculate_txt.Text = result.Count.ToString() + " x " + result.Cost.Amount() + " = " + result.ItemTotal.Amount();

                    Refresh();
                    return;
                }
                else
                {
                    ShopModel shop = new ShopModel()
                    {
                        Count = 1,
                        Product = product.Data
                    };
                    //targetWindow.dashboard.productname_txt.Text = product.Name;
                    //targetWindow.dashboard.calculate_txt.Text = "1" + " x " + product.RetailPrice.Amount() + " = " + (1 * product.RetailPrice).Amount();
                    Items.Add(shop);
                    Refresh();
                }
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

                List<ShopModel> shops = targetWindow.dashboard.cash_navbar.GetPageItems();

                if (deleteChecker)
                {
                    if (onSelection.AddSeconds(1.2) > DateTime.Now)
                    {
                        if (DateTime.Now >= mouseDown)
                        {
                            //MessageBox.Show($"Mouse was held down for > 3 seconds!{a}");
                            foreach (ShopModel obj in shops)
                            {
                                obj.Margin = new Thickness(15, 0, 10, 0);
                                obj.Visibility = Visibility.Visible;
                            }
                            BrushConverter bc = new BrushConverter();
                            Brush brush = (Brush)bc?.ConvertFrom("#F50000");
                            brush?.Freeze();
                            delete_btn.Background = brush;
                            shops.Where(obj => obj.Product.Id == SelectedShop.Product.Id).FirstOrDefault().DeleteStatus = true;
                            timer.Stop();
                            Refresh();
                            Checker = false;

                        }
                    }
                }
                else
                {
                    timer.Stop();
                }
            }
            catch
            {

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
                timer.Stop();
            }
            catch
            {

            }
        }
        DateTime onSelection;
        private void shopdatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                onSelection = DateTime.Now;
                SelectedShop = shopdatagrid.SelectedItem as ShopModel;
            }
            catch
            {

            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                List<ShopModel> shops = targetWindow.dashboard.cash_navbar.GetPageItems();

                shops.Where(obj => obj.Product.Id == (shopdatagrid.SelectedItem as ShopModel).Product.Id).FirstOrDefault().DeleteStatus = false;

                if (shops.All(obj => obj.DeleteStatus == false))
                {
                    foreach (ShopModel obj in shops)
                    {
                        obj.Margin = new Thickness(0, 0, 10, 0);
                        obj.Visibility = Visibility.Hidden;
                    }
                    BrushConverter bc = new BrushConverter();
                    Brush brush = (Brush)bc?.ConvertFrom("#0C7C80");
                    brush?.Freeze();
                    delete_btn.Background = brush;
                    Refresh();
                    Checker = true;
                }
            }
            catch
            {

            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                List<ShopModel> shops = targetWindow.dashboard.cash_navbar.GetPageItems();

                shops.Where(obj => obj.Product.Id == (shopdatagrid.SelectedItem as ShopModel).Product.Id).FirstOrDefault().DeleteStatus = true;
            }
            catch
            {

            }
        }

        bool Checker = true;
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                if (Checker)
                {
                    //targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
                    targetWindow.dashboard.warningStack.Visibility = Visibility.Visible;
                    targetWindow.dashboard.warningStack.informText.Text = "O'chirish tugmasini bosdingiz";
                }
                else
                {
                    
                    try
                    {
                        List<ShopModel> shops = targetWindow.dashboard.cash_navbar.GetPageItems();
                        
                        shops.RemoveAll(obj => obj.DeleteStatus == true);

                        foreach (ShopModel obj in shops)
                        {
                            obj.Margin = new Thickness(0, 0, 10, 0);
                            obj.Visibility = Visibility.Hidden;
                        }

                        Refresh();
                        delete_window.Visibility = Visibility.Hidden;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void cancel_delete_window_btn_Click(object sender, RoutedEventArgs e)
        {
            delete_window.Visibility = Visibility.Hidden;
        }



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
            //        targetWindow.dashboard.rightEdit.SetProduct(shop);
            //        targetWindow.dashboard.rightEdit.Visibility = Visibility.Visible;
            //    }
            //}
            //catch
            //{

            //}
        }

        DateTime OnClickButton;
        private void Plus_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnClickButton = DateTime.Now;

                ShopModel shop = shopdatagrid.SelectedItem as ShopModel;

                shop.Count += 1;

                Refresh();
            }
            catch
            {

            }
        }

        private void Minus_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                List<ShopModel> shops = targetWindow.dashboard.cash_navbar.GetPageItems();

                OnClickButton = DateTime.Now;

                ShopModel shop = shopdatagrid.SelectedItem as ShopModel;

                if (shop.Count == 1 || shop.Count < 1)
                {
                    shops.Remove(shop);
                }
                else
                {
                    shop.Count -= 1;
                }
                Refresh();

            }
            catch
            {

            }
        }
        public void Refresh()
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                targetWindow.dashboard.cash_navbar.RefreshItems();
            }
            catch
            {

            }
        }


        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                if (submit_btn.Content.ToString().Replace(" ", "") != "")
                {
                    if (double.Parse(submit_btn.Content.ToString().Replace(" ", "")) > 0)
                    {
                        targetWindow.dashboard.paymentpart.Visibility = Visibility.Visible;
                        targetWindow.dashboard.paymentpart.ChangeButtonText(submit_btn.Content.ToString());
                        targetWindow.dashboard.paymentpart.TotalAmount = double.Parse(submit_btn.Content.ToString().Replace(" ", ""));
                    }
                }
            }
            catch
            {

            }
        }
    }
}
