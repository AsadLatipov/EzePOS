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

namespace EzePOS.Cashier.WindowUI.UserControls.Products
{
    /// <summary>
    /// Interaction logic for EditAndChange.xaml
    /// </summary>
    public partial class EditAndChange : UserControl
    {
        public EditAndChange()
        {
            InitializeComponent();
        }
        public Product product = new Product();
        public bool productNameGorFocus = false;
        public bool productSellingPriceGorFocus = false;
        public bool productIncomePriceGorFocus = false;
        public bool productQuantityGorFocus = false;


        public void SetProductToEdit(Product product)
        {
            this.product = product;
            product_selling_cost.Text = product.SellingPrice.Amount();
            product_income_cost.Text = product.IncomePrice.Amount();
            product_name.Text = product.Name;
            if (product.Measure == Infrastructure.Enums.Measure.pcs)
            {
                measure_combobox.SelectedIndex = 0;
            }
            else if (product.Measure == Infrastructure.Enums.Measure.kg)
            {
                measure_combobox.SelectedIndex = 1;
            }
            product_qauntity.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.product_edit_exchange.Visibility = Visibility.Hidden;
            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

            chosen_combo.ItemsSource = new List<Category>();
            chosen_combo.Items.Refresh();

        }

        private void product_name_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;

            productNameGorFocus = true;
            productSellingPriceGorFocus = false;
            productIncomePriceGorFocus = false;
            productQuantityGorFocus = false;
        }


        private void product_qauntity_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;

            productQuantityGorFocus = true;
            productNameGorFocus = false;
            productSellingPriceGorFocus = false;
            productIncomePriceGorFocus = false;
        }

        private async void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                product.Name = product_name.Text;
                product.SellingPrice = double.Parse(product_selling_cost.Text.Replace(" ", ""));
                product.IncomePrice = double.Parse(product_income_cost.Text.Replace(" ", ""));

                if (measure_combobox.SelectedIndex == 0)
                {
                    product.Measure = Infrastructure.Enums.Measure.pcs;
                }
                else if (measure_combobox.SelectedIndex == 1)
                {
                    product.Measure = Infrastructure.Enums.Measure.kg;
                }
                else
                {

                }
                await targetWindow._productService.UpdateAsync(product, targetWindow.dashboard.user);

                targetWindow.dashboard.product_edit_exchange.Visibility = Visibility.Hidden;
                targetWindow.dashboard.products.dataGrid_products.Items.Refresh();
                targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;
            }
            catch
            {

            }
        }

        private void submit_category_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            Category chosen = chosen_combo.SelectedItem as Category;
            product.CategoryId = chosen.Id;
            targetWindow._productService.UpdateAsync(product, targetWindow.dashboard.user);
            targetWindow.dashboard.products.AfterchangeCategory();
            Button_Click(sender, e);
            chosen_combo.ItemsSource = new List<Category>();
            chosen_combo.Items.Refresh();
        }

        private void product_selling_cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (product_selling_cost.Text != "" && product_selling_cost.Text != null)
                {
                    product_selling_cost.Text = double.Parse(product_selling_cost.Text.Replace(" ", "")).Amount();
                }
                else
                {
                }

                product_selling_cost.CaretIndex = product_selling_cost.Text.Length;
            }
            catch
            {

            }
        }

        private void product_selling_cost_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;

            productSellingPriceGorFocus = true;
            productNameGorFocus = false;
            productQuantityGorFocus = false;
            productIncomePriceGorFocus = false;
        }

        private void product_income_cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (product_income_cost.Text != "" && product_income_cost.Text != null)
                {
                    product_income_cost.Text = double.Parse(product_income_cost.Text.Replace(" ", "")).Amount();
                }
                else
                {
                }

                product_income_cost.CaretIndex = product_income_cost.Text.Length;
            }
            catch
            {

            }
        }

        private void product_income_cost_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;

            productIncomePriceGorFocus = true;
            productSellingPriceGorFocus = false;
            productNameGorFocus = false;
            productQuantityGorFocus = false;
        }
    }
}
