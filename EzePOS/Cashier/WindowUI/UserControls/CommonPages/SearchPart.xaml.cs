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

namespace EzePOS.Cashier.WindowUI.UserControls.CommonPages
{
    /// <summary>
    /// Interaction logic for SearchPart.xaml
    /// </summary>
    public partial class SearchPart : UserControl
    {
        public SearchPart()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            search_block.Visibility = Visibility.Hidden;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (search_txt.Text == "")
                {
                    search_block.Visibility = Visibility.Visible;
                }
                else
                {
                    search_block.Visibility = Visibility.Hidden;
                }
            }
            catch
            {

            }
        }

        public void cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                targetWindow.dashboard.searchpartgrid.Visibility = Visibility.Hidden;
                targetWindow.dashboard.search_datagrid.Visibility = Visibility.Hidden;

                targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

                search_block.Visibility = Visibility.Visible;
                search_txt.Text = "";
            }
            catch
            {

            }
        }

        public void SearchCategoryOnProducts(string text)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            if (text != "")
            {

                var temp = targetWindow.dashboard.products.categories.Where(obj => obj.Name.ToLower().Contains(text.ToLower()));

                targetWindow.dashboard.products.dataGrid_categories.ItemsSource = temp;
                targetWindow.dashboard.products.dataGrid_categories.Items.Refresh();
            }
            else
            {
                targetWindow.dashboard.products.dataGrid_categories.ItemsSource = targetWindow.dashboard.products.categories;
                targetWindow.dashboard.products.dataGrid_categories.Items.Refresh();
            }
        }

        public void SearchDebtors(string text)
        {
            //var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            //if (text != "")
            //{

            //    var temp = targetWindow.dashboard.debts.debts.Where(obj => obj.Client.ToLower().Contains(text.ToLower()));

            //    targetWindow.dashboard.debts.datagrid.ItemsSource = temp;
            //    targetWindow.dashboard.debts.datagrid.Items.Refresh();
            //}
            //else
            //{
            //    targetWindow.dashboard.debts.datagrid.ItemsSource = targetWindow.dashboard.debts.debts;
            //    targetWindow.dashboard.debts.datagrid.Items.Refresh();
            //}
        }

        public void SearchClients(string text)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            if (text != "")
            {

                var temp = targetWindow.dashboard.clients.clients.Where(obj => obj.FullName.ToLower().Contains(text.ToLower()));

                targetWindow.dashboard.clients.datagrid.ItemsSource = temp;
                targetWindow.dashboard.clients.datagrid.Items.Refresh();
            }
            else
            {
                targetWindow.dashboard.clients.datagrid.ItemsSource = targetWindow.dashboard.clients.clients;
                targetWindow.dashboard.clients.datagrid.Items.Refresh();
            }
        }
        public void SearchShops(string text)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            try
            { 
                if (text != "")
                {
                    int id = int.Parse(text);

                    targetWindow.dashboard.history.SetShopsWithSearch(id);
                }
            }
            catch
            {

            }

        }

        public void SearchOnReturnProduct(string text)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            try
            {
                if (text != "")
                {
                    int id = int.Parse(text);

                    targetWindow.dashboard.returnProduct.SetShopsWithSearch(id);
                }
            }
            catch
            {

            }

        }
        public void SearchDiscounts(string text)
        {
            //var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            //if (text != "")
            //{

            //    var temp = targetWindow.dashboard.discount.discounts.Where(obj => obj.Name.ToLower().Contains(text.ToLower()));

            //    targetWindow.dashboard.discount.datagrid.ItemsSource = temp;
            //    targetWindow.dashboard.discount.datagrid.Items.Refresh();
            //}
            //else
            //{
            //    targetWindow.dashboard.discount.datagrid.ItemsSource = targetWindow.dashboard.discount.discounts;
            //    targetWindow.dashboard.discount.datagrid.Items.Refresh();
            //}
        }


        public void SearchProductOnProducts(string text)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            if (text != "")
            {

                var temp = targetWindow.dashboard.products.products.Where(obj => obj.Name.ToLower().Contains(text.ToLower()));

                targetWindow.dashboard.products.dataGrid_products.ItemsSource = temp;
                targetWindow.dashboard.products.dataGrid_products.Items.Refresh();
            }
            else
            {
                targetWindow.dashboard.products.dataGrid_products.ItemsSource = targetWindow.dashboard.products.products;
                targetWindow.dashboard.products.dataGrid_products.Items.Refresh();
            }
        }
        public async void SearchPotoductOnSale(string text)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
                if (text != "")
                {
                    var temp = await targetWindow._productService.GetAllAsync(obj => obj.Name.ToLower().Contains(text.ToLower()) && obj.Quantity > 0);

                    if (temp.Data.Count() > 0)
                    {
                        targetWindow.dashboard.search_datagrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        targetWindow.dashboard.search_datagrid.Visibility = Visibility.Hidden;
                    }
                    targetWindow.dashboard.search_datagrid.dataGrid.ItemsSource = temp.Data;
                    targetWindow.dashboard.search_datagrid.dataGrid.Items.Refresh();
                    search_block.Visibility = Visibility.Hidden;

                }
                else
                {
                    targetWindow.dashboard.search_datagrid.Visibility = Visibility.Hidden;
                    targetWindow.dashboard.search_datagrid.dataGrid.ItemsSource = new List<Product>();
                    targetWindow.dashboard.search_datagrid.dataGrid.Items.Refresh();
                    search_block.Visibility = Visibility.Visible;
                }
            }
            catch
            {

            }
        }

        private void search_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                if (targetWindow.dashboard.products.Visibility == Visibility.Visible)
                {
                    if (targetWindow.dashboard.products.categories_grid.Visibility == Visibility.Visible)
                    {
                        SearchCategoryOnProducts(search_txt.Text);
                    }
                    else
                    {
                        if (targetWindow.dashboard.product_edit_exchange.Visibility != Visibility.Visible)
                        {
                            SearchProductOnProducts(search_txt.Text);
                        }
                    }
                }
                //else if (targetWindow.dashboard.debts.Visibility == Visibility.Visible)
                //{
                //    SearchDebtors(search_txt.Text);
                //}
                else if (targetWindow.dashboard.clients.Visibility == Visibility.Visible)
                {
                    if(targetWindow.dashboard.addclient.Visibility != Visibility.Visible)
                    {
                        SearchClients(search_txt.Text);
                    }
                }
                else if (targetWindow.dashboard.history.Visibility == Visibility.Visible)
                {
                    SearchShops(search_txt.Text);
                }
                else if (targetWindow.dashboard.returnProduct.Visibility == Visibility.Visible)
                {
                    SearchOnReturnProduct(search_txt.Text);
                }
                //else if (targetWindow.dashboard.discount.Visibility == Visibility.Visible)
                //{
                //    SearchDiscounts(search_txt.Text);
                //}
                else
                {
                    SearchPotoductOnSale(search_txt.Text);
                }

            }
            catch
            {

            }

            
        }
    }
}
