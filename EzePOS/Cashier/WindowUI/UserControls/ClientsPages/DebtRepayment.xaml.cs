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
    /// Interaction logic for DebtRepayment.xaml
    /// </summary>
    public partial class DebtRepayment : UserControl
    {
        public DebtRepayment()
        {
            InitializeComponent();
        }
        Client updateClient = new Client();


        public void SetClient(Client client)
        {
            clientName.Text = client.FullName;
            debtBox.Text = client.Debt.Amount();
            clientDebt.Text = client.Debt.Amount();
            debtBox.Text = client.Debt.Amount();
            updateClient = client;
        }
        private async void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            double temp = debtBox.Text == "" ? 0 : debtBox.Text == null ? 0 : double.Parse(debtBox.Text.Replace(" ", ""));

            if(temp > 0)
            {
                if (updateClient.Debt == temp || updateClient.Debt > temp)
                {
                    updateClient.Debt = updateClient.Debt - temp;
                    var result = await targetWindow._clientService.UpdateAsync(updateClient, targetWindow.dashboard.user);
                    targetWindow.dashboard.debtRepayment.Visibility = Visibility.Hidden;
                    debtBox.Text = "0";
                    await targetWindow.dashboard.clients.SetClientsAsync();
                }

            }
            else
            {
                targetWindow.dashboard.debtRepayment.Visibility = Visibility.Hidden;

                debtBox.Text = "0";
            }

        }

        private void debtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.debtRepayment.Visibility = Visibility.Hidden;

            debtBox.Text = "0";
        }
    }
}
