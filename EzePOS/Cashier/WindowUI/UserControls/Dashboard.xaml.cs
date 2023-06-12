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

namespace EzePOS.Cashier.WindowUI.UserControls
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public User user = new User() { Id = 1, FirstName = "Asadbek", LastName ="Latipov"};

        private void btn_menu_click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;
            leftMenu.Visibility = Visibility.Visible;

            object aa = new object();
            RoutedEventArgs aaa = new RoutedEventArgs();
            targetWindow.dashboard.searchpart.cancel_Click(aa, aaa);

            targetWindow.dashboard.products.addborder.Visibility = Visibility.Collapsed;
            targetWindow.dashboard.products.isopen = false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetTrueMethod(leftMenu.CurrentPage);


            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;
            object aa = new object();
            RoutedEventArgs aaa = new RoutedEventArgs();
            targetWindow.dashboard.searchpart.cancel_Click(aa, aaa);
        }

        public void GetTrueMethod(double pageNumber)
        {
            switch (pageNumber)
            {
                case 1:
                    break;
                case 2:
                    products.BackButton();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 1.1:
                    break;
                case 1.2:
                    break;
                case 1.3:
                    break;
                case 1.4:
                    break;
                case 1.5:
                    break;
                case 1.6:
                    break;
                default:
                    break;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
