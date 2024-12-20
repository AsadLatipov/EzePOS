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

namespace EzePOS.Cashier.WindowUI.UserControls.CommonPages
{
    /// <summary>
    /// Interaction logic for WarningStack.xaml
    /// </summary>
    public partial class WarningStack : UserControl
    {
        public WarningStack()
        {
            InitializeComponent();
        }

        public Client client = new Client();
        public Product product = new Product();
        public Category category = new Category();
        public bool IsProduct = false;


        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.warningStack.Visibility = Visibility.Hidden;
        }

        private async void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            if(targetWindow.dashboard.leftMenu.Visibility == Visibility.Visible)
            {
                App.Current.Shutdown();
            }
            else if (targetWindow.dashboard.salesPanel.Visibility == Visibility.Visible)
            {
                if (IsProduct)
                {
                    targetWindow.dashboard.warningStack.Visibility = Visibility.Hidden;
                    IsProduct = false;
                }
                else
                {
                    targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
                    targetWindow.dashboard.warningStack.Visibility = Visibility.Hidden;
                }
                
            }
            else if (targetWindow.dashboard.clients.Visibility == Visibility.Visible)
            {
                var result = await targetWindow._clientService.DeleteAsync(obj => obj.Id == client.Id);
                await targetWindow.dashboard.clients.SetClientsAsync();
                targetWindow.dashboard.warningStack.Visibility = Visibility.Hidden;

            }
            else if (targetWindow.dashboard.products.products_grid.Visibility == Visibility.Visible)
            {
                var result = await targetWindow._productService.DeleteAsync(obj => obj.Id == product.Id);
                targetWindow.dashboard.products.AfterchangeCategory();
                targetWindow.dashboard.warningStack.Visibility = Visibility.Hidden;
            }
            else if (targetWindow.dashboard.products.categories_grid.Visibility == Visibility.Visible)
            {
                var result = await targetWindow._categoryService.DeleteAsync(obj => obj.Id == category.Id);
                await targetWindow._productService.DeleteAsync(obj => obj.CategoryId == category.Id);
                targetWindow.dashboard.products.setCategories();
                targetWindow.dashboard.warningStack.Visibility = Visibility.Hidden;
            }
        }
    }
}
