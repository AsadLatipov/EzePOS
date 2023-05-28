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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            //targetWindow.dashboard.debts.filter_grid.Visibility = Visibility.Visible;
            //targetWindow.dashboard.debts.chosen_combo.ItemsSource = targetWindow.dashboard.debts.debts;
            //targetWindow.dashboard.debts.chosen_combo.Items.Refresh();
        }
    }
}
