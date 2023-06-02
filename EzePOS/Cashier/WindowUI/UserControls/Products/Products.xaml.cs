﻿using EzePOS.Cashier.WindowUI.Windows;
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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        public List<Category> categories = new List<Category>();
        public List<Product> products = new List<Product>();
        Category currentCategory = new Category();

        public Products()
        {
            InitializeComponent();
            setCategories();

        }


        public void BackButton()
        {
            if (categories_grid.Visibility == Visibility.Visible)
            {

            }
            else if (products_grid.Visibility == Visibility.Visible)
            {
                products_grid.Visibility = Visibility.Hidden;
                categories_grid.Visibility = Visibility.Visible;
            }
        }
        public async void setCategories()
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
                var temp = await targetWindow._categoryService.GetAllAsync();
                categories = temp.Data.ToList();

                dataGrid_categories.ItemsSource = categories;
                dataGrid_categories.Items.Refresh();
            }
            catch
            {

            }
        }

        public async void AfterchangeCategory()
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            var temp = await targetWindow._productService.GetAllAsync(obj => obj.CategoryId == currentCategory.Id);
            products = temp.Data.ToList();
            dataGrid_products.ItemsSource = products;
            dataGrid_products.Items.Refresh();
        }

        private async void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                Category selected = dataGrid_categories.SelectedItem as Category;

                if (selected != null)
                {
                    currentCategory = selected;
                    var temp = await targetWindow._productService.GetAllAsync(obj => obj.CategoryId == selected.Id);
                    products = temp.Data.ToList();
                    dataGrid_products.ItemsSource = products;
                    dataGrid_products.Items.Refresh();

                    categories_grid.Visibility = Visibility.Hidden;
                    products_grid.Visibility = Visibility.Visible;
                }

            }
            catch
            {

            }
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.product_edit_exchange.Visibility = Visibility.Visible;

            targetWindow.dashboard.product_edit_exchange.edit_grid.Visibility = Visibility.Visible;
            targetWindow.dashboard.product_edit_exchange.exchange_grid.Visibility = Visibility.Hidden;

            Product product = dataGrid_products.SelectedItem as Product;

            if (product != null)
                targetWindow.dashboard.product_edit_exchange.SetProductToEdit(product);
        }

        private void exchange_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            Product temp = dataGrid_products.SelectedItem as Product;
            if (temp != null)
            {
                List<string> categoryNames = new List<string>();
                foreach (var item in categories)
                {
                    categoryNames.Add(item.Name);
                }

                targetWindow.dashboard.product_edit_exchange.Visibility = Visibility.Visible;
                targetWindow.dashboard.product_edit_exchange.exchange_grid.Visibility = Visibility.Visible;
                targetWindow.dashboard.product_edit_exchange.edit_grid.Visibility = Visibility.Hidden;

                Category category = categories.Where(obj => obj.Id == temp.CategoryId).FirstOrDefault();

                targetWindow.dashboard.product_edit_exchange.current_combo.ItemsSource = categories;
                targetWindow.dashboard.product_edit_exchange.current_combo.SelectedItem = category;

                targetWindow.dashboard.product_edit_exchange.chosen_combo.ItemsSource = categories;

                Product product = dataGrid_products.SelectedItem as Product;

                if (product != null)
                    targetWindow.dashboard.product_edit_exchange.SetProductToEdit(product);

            }
        }

        private void cancel_delete_window_btn_Click(object sender, RoutedEventArgs e)
        {
            delete_window.Visibility = Visibility.Hidden;
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            Product product = dataGrid_products.SelectedItem as Product;
            products.Remove(product);
            dataGrid_products.Items.Refresh();
            delete_window.Visibility = Visibility.Hidden;
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            delete_window.Visibility = Visibility.Visible;

        }
    }
}