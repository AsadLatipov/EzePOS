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
    /// Interaction logic for WarningStack.xaml
    /// </summary>
    public partial class WarningStack : UserControl
    {
        public WarningStack()
        {
            InitializeComponent();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.warningStack.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
            targetWindow.dashboard.warningStack.Visibility = Visibility.Hidden;
        }
    }
}
