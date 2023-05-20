using EzePOS.Cashier.WindowUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace EzePOS.Cashier.WindowUI.UserControls.SalesPages
{
    /// <summary>
    /// Interaction logic for AddDiscountToShop.xaml
    /// </summary>
    public partial class AddDiscountToShop : UserControl
    {
        public AddDiscountToShop()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.addDiscountToShop.Visibility = Visibility.Hidden;
            textBox.Text = "";
            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            try
            {
                double temp = double.Parse(textBox.Text);
                if (temp > 0 && temp < 100)
                {
                    targetWindow.dashboard.paymentpart.SetDiscount(temp);
                    cancel_Click(sender, e);
                }
            }
            catch
            {

            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9^.]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
