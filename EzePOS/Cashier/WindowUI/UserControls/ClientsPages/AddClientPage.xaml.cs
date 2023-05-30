using EzePOS.Business.Helper;
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
    /// Interaction logic for AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : UserControl
    {
        public AddClientPage()
        {
            InitializeComponent();
        }

        Client updateClient = new Client();
        public bool Edit = false;
        public bool Add = false;

        public void SetClient(Client client)
        {
            nameBox.Text = client.FullName;
            phoneBox.Text = client.PhoneNumber;
            debtBox.Text = client.Debt.Amount();
            updateClient = client;
        }
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.addclient.Visibility = Visibility.Hidden;
            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

            nameBox.Text = "";
            phoneBox.Text = "";
            debtBox.Text = "0";

        }
        public bool nameBoxGotFocus = false;
        public bool phoneBoxGotFocus = false;
        public bool debtBoxGotFocus = false;

        

        private void nameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
            nameBoxGotFocus = true;
            phoneBoxGotFocus = false;
            debtBoxGotFocus = false;
        }

        private void phoneBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
            phoneBoxGotFocus = true;
            nameBoxGotFocus = false;
            debtBoxGotFocus = false;
        }

        private void debtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
            debtBoxGotFocus = true;
            nameBoxGotFocus = false;
            phoneBoxGotFocus = false;
        }

        private async void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;


                if (nameBox.Text != "" && nameBox.Text != null)
                {
                    if (phoneBox.Text != "" && nameBox.Text != null)
                    {
                        double temp = debtBox.Text == "" ? 0 : debtBox.Text == null ? 0 : double.Parse(debtBox.Text.Replace(" ", ""));

                        Client client = new Client() { FullName = nameBox.Text, PhoneNumber = phoneBox.Text, Debt = temp };
                        updateClient.FullName = client.FullName;
                        updateClient.PhoneNumber = client.PhoneNumber;
                        updateClient.Debt = client.Debt;

                        if (Add)
                        {
                            var result = await targetWindow._clientService.CreateAsync(client, targetWindow.dashboard.user);
                            if (result.Data != null)
                            {
                                await targetWindow.dashboard.clients.SetClientsAsync();
                                targetWindow.dashboard.addclient.Visibility = Visibility.Hidden;
                                targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

                                nameBox.Text = "";
                                phoneBox.Text = "";
                                debtBox.Text = "0";
                            }
                        }
                        else if (Edit)
                        {
                            var result = await targetWindow._clientService.UpdateAsync(updateClient, targetWindow.dashboard.user);

                            if(result.Data != null)
                            {
                                await targetWindow.dashboard.clients.SetClientsAsync();
                                targetWindow.dashboard.addclient.Visibility = Visibility.Hidden;
                                targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

                                nameBox.Text = "";
                                phoneBox.Text = "";
                                debtBox.Text = "0";
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
