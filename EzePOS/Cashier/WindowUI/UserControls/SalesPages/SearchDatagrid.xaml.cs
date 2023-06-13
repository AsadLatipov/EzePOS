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

namespace EzePOS.Cashier.WindowUI.UserControls.SalesPages
{
    /// <summary>
    /// Interaction logic for SearchDatagrid.xaml
    /// </summary>
    public partial class SearchDatagrid : UserControl
    {
        public SearchDatagrid()
        {
            InitializeComponent();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                var selected = dataGrid.SelectedItem as Product;
                if (selected != null)
                {
                    targetWindow.dashboard.salesPanel.AddProduct(selected.Id);
                    targetWindow.dashboard.searchpart.cancel_Click(sender, new RoutedEventArgs());
                }
                else
                {

                }
            }
            catch
            {

            }
        }
    }
}
