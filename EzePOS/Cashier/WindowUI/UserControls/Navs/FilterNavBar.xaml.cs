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

namespace EzePOS.Cashier.WindowUI.UserControls.Navs
{
    /// <summary>
    /// Interaction logic for FilterNavBar.xaml
    /// </summary>
    public partial class FilterNavBar : UserControl
    {
        public FilterNavBar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.filter.Visibility = Visibility.Visible;
            targetWindow.dashboard.filter.hisotry_filter.Visibility = Visibility.Visible;
            targetWindow.dashboard.filter.product_filter.Visibility = Visibility.Collapsed;
            
        }
    }
}
