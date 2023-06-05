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

namespace EzePOS.Cashier.WindowUI.UserControls.ClientsPages
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        public List<Client> clients = new List<Client>();
        public Clients()
        {

            InitializeComponent();
        }

        public async Task SetClientsAsync()
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;
                var temp = await targetWindow._clientService.GetAllAsync();

                clients = temp.Data.ToList();

                datagrid.ItemsSource = clients;
                datagrid.Items.Refresh();

                object aa = new object();
                RoutedEventArgs aaa = new RoutedEventArgs();
                targetWindow.dashboard.searchpart.cancel_Click(aa, aaa);
            }
            catch
            {

            }
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = datagrid.SelectedItem as Client;
                if (client != null)
                {
                    var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

                    targetWindow.dashboard.addclient.Visibility = Visibility.Visible;
                    targetWindow.dashboard.addclient.Edit = true;
                    targetWindow.dashboard.addclient.Add = false;

                    targetWindow.dashboard.addclient.SetClient(client);
                }
            }
            catch
            {

            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = datagrid.SelectedItem as Client;
                if (client != null)
                {
                    var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

                    targetWindow.dashboard.warningStack.informText.Text = "O'chirish tugmasini bosdingiz";
                    targetWindow.dashboard.warningStack.Visibility = Visibility.Visible;
                    targetWindow.dashboard.warningStack.client = client;
                }
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.addclient.Visibility = Visibility.Visible;
            targetWindow.dashboard.addclient.Add = true;
            targetWindow.dashboard.addclient.Edit = false;

            object aa = new object();
            RoutedEventArgs aaa = new RoutedEventArgs();
            targetWindow.dashboard.searchpart.cancel_Click(aa, aaa);

        }

        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Client client = datagrid.SelectedItem as Client;
                if (client != null)
                {
                    if (client.Debt > 0)
                    {
                        var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

                        targetWindow.dashboard.debtRepayment.Visibility = Visibility.Visible;
                        targetWindow.dashboard.debtRepayment.SetClient(client);
                    }
                }
            }
            catch
            {

            }
        }

        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            object aa = new object();
            RoutedEventArgs aaa = new RoutedEventArgs();
            targetWindow.dashboard.searchpart.cancel_Click(aa, aaa);
        }
    }
}
