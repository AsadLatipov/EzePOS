using EzePOS.Cashier.WindowUI.UserControls.Products;
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

namespace EzePOS.Cashier.WindowUI.UserControls.CommonPages
{
    /// <summary>
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : UserControl
    {
        public Filter()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
                if (product_checkbox.SelectedIndex == 0)
                {

                    var temp = await targetWindow._productService.GetAllAsync();
                    targetWindow.dashboard.products.products = temp.Data.ToList();
                    targetWindow.dashboard.products.dataGrid_products.ItemsSource = targetWindow.dashboard.products.products;
                    targetWindow.dashboard.products.dataGrid_products.Items.Refresh();
                    targetWindow.dashboard.filter.Visibility = Visibility.Hidden;

                    targetWindow.dashboard.products.products_grid.Visibility = Visibility.Visible;
                    targetWindow.dashboard.products.categories_grid.Visibility = Visibility.Hidden;
                }
                else if(product_checkbox.SelectedIndex == 1)
                {
                    var temp = await targetWindow._productService.GetAllAsync(obj => obj.Quantity == 0);
                    //temp.Data.Count();
                    targetWindow.dashboard.products.products = temp.Data.ToList();
                    targetWindow.dashboard.products.dataGrid_products.ItemsSource = targetWindow.dashboard.products.products;
                    targetWindow.dashboard.products.dataGrid_products.Items.Refresh();
                    targetWindow.dashboard.filter.Visibility = Visibility.Hidden;

                    targetWindow.dashboard.products.products_grid.Visibility = Visibility.Visible;
                    targetWindow.dashboard.products.categories_grid.Visibility = Visibility.Hidden;
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.filter.Visibility = Visibility.Hidden;
        }

        private void from_btn_Click(object sender, RoutedEventArgs e)
        {
            from_date.IsDropDownOpen = true;
        }

        private void to_btn_Click(object sender, RoutedEventArgs e)
        {
            to_date.IsDropDownOpen = true;
        }

        private void from_date_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (from_btn.Template.FindName("from_txt", from_btn) is TextBlock textBlock)
                textBlock.Text = from_date.SelectedDate?.ToString("dd-MM-yyyy");
        }

        private void to_date_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (to_btn.Template.FindName("to_txt", to_btn) is TextBlock textBlock)
                textBlock.Text = to_date.SelectedDate?.ToString("dd-MM-yyyy");
        }

        private void from_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (from_btn.Template.FindName("from_txt", from_btn) is TextBlock textBlock)
                textBlock.Text = from_date.SelectedDate?.ToString("dd-MM-yyyy");
        }

        private void to_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (to_btn.Template.FindName("to_txt", to_btn) is TextBlock textBlock)
                textBlock.Text = to_date.SelectedDate?.ToString("dd-MM-yyyy");
        }
    }
}
