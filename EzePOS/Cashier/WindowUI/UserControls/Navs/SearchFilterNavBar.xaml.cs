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

namespace EzePOS.Cashier.WindowUI.UserControls.Navs
{
    /// <summary>
    /// Interaction logic for SearchFilterNavBar.xaml
    /// </summary>
    public partial class SearchFilterNavBar : UserControl
    {
        public SearchFilterNavBar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.cash_navbar.Button_Click_1(sender, e);

            targetWindow.dashboard.products.addborder.Visibility = Visibility.Collapsed;
            targetWindow.dashboard.products.isopen = false;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.filter.Visibility = Visibility.Visible;
            if (targetWindow.dashboard.products.Visibility == Visibility.Visible)
            {

                targetWindow.dashboard.filter.hisotry_filter.Visibility = Visibility.Collapsed;
                targetWindow.dashboard.filter.product_filter.Visibility = Visibility.Visible;
                targetWindow.dashboard.products.addborder.Visibility = Visibility.Collapsed;
                targetWindow.dashboard.products.isopen = false;
            }
            
        }
    }
}
