using EzePOS.Business.Helper;
using EzePOS.Business.Models;
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

namespace EzePOS.Cashier.WindowUI.UserControls.SalesPages
{
    /// <summary>
    /// Interaction logic for PaymentPart.xaml
    /// </summary>
    public partial class PaymentPart : UserControl
    {
        public PaymentPart()
        {
            InitializeComponent();
        }
        public bool withCard = false;
        public double TotalAmount = 0;
        public bool clientNameGotFocus = false;
        public bool clientNumberGotFocus = false;
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Write(btn1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Write(btn2);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Write(btn3);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Write(btn4);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            Write(btn5);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            Write(btn6);
         

        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            Write(btn7);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            Write(btn8);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            Write(btn9);
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            Write(btnDot);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            Write(btn0);
        }


        public void Write(Button button)
        {
            try
            {
                if (withCard)
                {
                    if (withCashGotFocus)
                    {
                        withCard_cash_text.Text += button.Content.ToString();
                    }
                    else if (withCardGotFocus)
                    {
                        withCard_card_text.Text += button.Content.ToString();
                    }
                }
                else
                {
                    withoutcard_txt.Text += button.Content.ToString();

                    //withoutcard_txt.Text = double.Parse(withoutcard_txt.Text.Replace(" ", "")).Amount();

                    //withoutcard_txt.Focus();
                    //withoutcard_txt.CaretIndex = withoutcard_txt.Text.Length;
                }
            }
            catch
            {

            }
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (withCard)
                {
                    if (withCashGotFocus)
                    {
                        if (withCard_cash_text.Text != "" && withCard_cash_text.Text != null)
                        {
                            withCard_cash_text.Text = withCard_cash_text.Text.Remove(withCard_cash_text.Text.Length - 1);
                        }
                    }
                    else if (withCardGotFocus)
                    {
                        if (withCard_card_text.Text != "" && withCard_card_text.Text != null)
                        {
                            withCard_card_text.Text = withCard_card_text.Text.Remove(withCard_card_text.Text.Length - 1);
                        }
                    }
                }
                else
                {
                    if (withoutcard_txt.Text != "" && withoutcard_txt.Text != null)
                    {
                        withoutcard_txt.Text = withoutcard_txt.Text.Remove(withoutcard_txt.Text.Length - 1);

                        //if (withoutcard_txt.Text != "" && withoutcard_txt.Text != null)
                        //{
                        //    withoutcard_txt.Text = double.Parse(withoutcard_txt.Text.Replace(" ", "")).Amount();
                        //}
                        //withoutcard_txt.Focus();
                        //withoutcard_txt.CaretIndex = withoutcard_txt.Text.Length;
                    }
                }
            }
            catch
            {

            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.paymentpart.Visibility = Visibility.Hidden;
            CloseAllPaymentStuffs();

        }

        private void discounts_btn_Click(object sender, RoutedEventArgs e)
        {
            if (discounts_grid.Visibility == Visibility.Hidden)
            {
                discounts_grid.Visibility = Visibility.Visible;
            }
            else
            {
                discounts_grid.Visibility = Visibility.Hidden;
            }
        }


        private void discount_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.addDiscountToShop.Visibility = Visibility.Visible;
        }

        private void ten_btn_Click(object sender, RoutedEventArgs e)
        {
            SetDiscount(10);
        }

        private void fifteen_btn_Click(object sender, RoutedEventArgs e)
        {
            SetDiscount(15);
        }
        private void twenty_btn_Click(object sender, RoutedEventArgs e)
        {
            SetDiscount(20);
        }

        private void btn_x_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                discounts_btn.Content = "Chegirma";
                ChangeButtonText(TotalAmount.Amount());
                btn_x.Visibility = Visibility.Hidden;
            }
            catch
            {

            }
        }

        public void SetDiscount(double discount_percent)
        {
            try
            {
                discounts_btn.Content = discount_percent.ToString() + "% Cheg.";
                btn_x.Visibility = Visibility.Visible;
                discounts_grid.Visibility = Visibility.Hidden;
                double temp = TotalAmount / 100;
                double discount = temp * discount_percent;
                ChangeButtonText((TotalAmount - discount).Amount());
            }
            catch
            {

            }
        }

        private void client_btn_Click(object sender, RoutedEventArgs e)
        {
            client_grid.Visibility = Visibility.Visible;
        }



        private void client_name_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
            clientNameGotFocus = true;
            clientNumberGotFocus = false;
        }


        private void client_number_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
            clientNameGotFocus = false;
            clientNumberGotFocus = true;
        }

        private void client_cancel_back_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;
            client_number.Text = "";
            client_name.Text = "";
            client_grid.Visibility = Visibility.Hidden;
        }


        private void ClientsList_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            clients_list_grid.Visibility = Visibility.Visible;
            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

            List<ClientModel> clients = new List<ClientModel>();

            clients.Add(new ClientModel { Id = 1, FirstName = "Asadbek", LastName = "Latipov", PhoneNumber = "+998913561310" });
            clients.Add(new ClientModel { Id = 2, FirstName = "Ahmadjon", LastName = "Sirojiddinov", PhoneNumber = "+998913561310" });
            clients.Add(new ClientModel { Id = 3, FirstName = "Qosim", LastName = "Qosimov", PhoneNumber = "+998913561310" });
            clients.Add(new ClientModel { Id = 4, FirstName = "Umar", LastName = "Fozilov", PhoneNumber = "+998913561310" });
            clients.Add(new ClientModel { Id = 5, FirstName = "Madina", LastName = "Abdullayeva", PhoneNumber = "+998913561310" });


            dataGrid.ItemsSource = clients;
            dataGrid.Items.Refresh();
        }

        private void clients_list_cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            clients_list_grid.Visibility = Visibility.Hidden;
        }

        private void total_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            CloseAllPaymentStuffs();
            targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
            targetWindow.dashboard.printCheck.Visibility = Visibility.Visible;
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            try
            {
                if (withCard)
                {
                    double cash = double.Parse(string.IsNullOrEmpty(withCard_cash_text.Text) ? "0" : withCard_cash_text.Text.Replace(" ", ""));
                    double card = double.Parse(string.IsNullOrEmpty(withCard_card_text.Text) ? "0" : withCard_card_text.Text.Replace(" ", ""));
                    double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                    double total = cash + card;
                    if (total >= totalAmount)
                    {
                        CloseAllPaymentStuffs();
                        targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
                        targetWindow.dashboard.printCheck.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    double amount = double.Parse(withoutcard_txt.Text.Replace(" ", ""));

                    if (amount >= double.Parse(GetButtonText().Replace(" ", "")))
                    {
                        CloseAllPaymentStuffs();
                        targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
                        targetWindow.dashboard.printCheck.Visibility = Visibility.Visible;
                    }
                    else
                    {

                    }
                }
            }
            catch
            {

            }
        }
        public void CloseAllPaymentStuffs()
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            withCard = false;
            TotalAmount = 0;
            discounts_grid.Visibility = Visibility.Hidden;
            clients_list_grid.Visibility = Visibility.Hidden;
            client_grid.Visibility = Visibility.Hidden;
            withoutcard_txt.Text = "";
            ChangeButtonText("0");
            change_text.Text = "0";
            card_amount_text.Text = "";
            withCard_card_text.Text = "";
            withCard_cash_text.Text = "";
            card_confirmation.Visibility = Visibility.Hidden;
            withCard_grid.Visibility = Visibility.Hidden;
            withoutCard_grid.Visibility = Visibility.Visible;
            targetWindow.dashboard.paymentpart.Visibility = Visibility.Hidden;
            discounts_btn.Content = "Chegirma";
            ChangeButtonText(TotalAmount.Amount());
            btn_x.Visibility = Visibility.Hidden;

        }

        private void withoutcard_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (withoutcard_txt.Text != "" && withoutcard_txt.Text != null)
                {
                    withoutcard_txt.Text = double.Parse(withoutcard_txt.Text.Replace(" ", "")).Amount();

                    double amount = double.Parse(withoutcard_txt.Text.Replace(" ", ""));

                    if (amount > double.Parse(GetButtonText().Replace(" ", "")))
                    {
                        change_text.Text = (amount - double.Parse(GetButtonText().Replace(" ", ""))).Amount();
                    }
                    else
                    {
                        change_text.Text = "0";
                    }
                }
                else
                {
                    change_text.Text = "0";
                }

                withoutcard_txt.Focus();
                withoutcard_txt.CaretIndex = withoutcard_txt.Text.Length;
            }
            catch
            {

            }
        }

        private void card_btn_Click(object sender, RoutedEventArgs e)
        {
            card_amount_text.Text = GetButtonText();
            card_confirmation.Visibility = Visibility.Visible;
        }

        private void cancel_btn_withcard_Click(object sender, RoutedEventArgs e)
        {
            card_confirmation.Visibility = Visibility.Hidden;
        }

        private void submit_btn_withcard_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            CloseAllPaymentStuffs();
            targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
            targetWindow.dashboard.printCheck.Visibility = Visibility.Visible;
        }

        private void withCard_cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            withCard_grid.Visibility = Visibility.Hidden;
            withoutCard_grid.Visibility = Visibility.Visible;

            withCard_card_text.Text = "";
            withCard_cash_text.Text = "";
            change_text.Text = "";
            withCard = false;
        }

        private void withCard_cash_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double cash = double.Parse(string.IsNullOrEmpty(withCard_cash_text.Text) ? "0" : withCard_cash_text.Text.Replace(" ", ""));
                double card = double.Parse(string.IsNullOrEmpty(withCard_card_text.Text) ? "0" : withCard_card_text.Text.Replace(" ", ""));
                double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                double total = cash + card;

                if (cash == 0)
                {
                    withCard_cash_text.Text = "";
                }
                else
                {
                    withCard_cash_text.Text = cash.Amount();
                }

                if (card == 0)
                {
                    withCard_card_text.Text = "";
                }
                else
                {
                    withCard_card_text.Text = card.Amount();
                }

                if (total > totalAmount)
                {
                    change_text.Text = (total - totalAmount).Amount();
                }
                else
                {
                    change_text.Text = "0";
                }

                withCard_cash_text.Focus();
                withCard_cash_text.CaretIndex = withCard_cash_text.Text.Length;
            }
            catch
            {

            }
        }

        private void withCard_card_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double card = double.Parse(string.IsNullOrEmpty(withCard_card_text.Text) ? "0" : withCard_card_text.Text.Replace(" ", ""));
                double cash = double.Parse(string.IsNullOrEmpty(withCard_cash_text.Text) ? "0" : withCard_cash_text.Text.Replace(" ", ""));
                double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                double total = cash + card;

                if (cash == 0)
                {
                    withCard_cash_text.Text = "";
                }
                else
                {
                    withCard_cash_text.Text = cash.Amount();
                }

                if (card == 0)
                {
                    withCard_card_text.Text = "";
                }
                else
                {
                    withCard_card_text.Text = card.Amount();
                }

                if (total > totalAmount)
                {
                    change_text.Text = (total - totalAmount).Amount();
                }
                else
                {
                    change_text.Text = "0";
                }

                withCard_card_text.Focus();
                withCard_card_text.CaretIndex = withCard_card_text.Text.Length;
            }
            catch
            {

            }
        }

        private void addWithCardPart_btn_Click(object sender, RoutedEventArgs e)
        {
            withoutCard_grid.Visibility = Visibility.Hidden;
            withCard_grid.Visibility = Visibility.Visible;

            withoutcard_txt.Text = "";
            change_text.Text = "";
            withCard = true;
        }

        bool withCardGotFocus = false;
        bool withCashGotFocus = false;

        private void withCard_cash_text_GotFocus(object sender, RoutedEventArgs e)
        {
            withCashGotFocus = true;
            withCardGotFocus = false;
        }

        private void withCard_card_text_GotFocus(object sender, RoutedEventArgs e)
        {
            withCashGotFocus = false;
            withCardGotFocus = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = dataGrid.SelectedItem as ClientModel;
                if (client != null)
                {
                    var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                    clients_list_grid.Visibility = Visibility.Hidden;
                    client_grid.Visibility = Visibility.Hidden;
                    client_name.Text = "";
                    client_number.Text = "";

                    targetWindow.dashboard.cash_navbar.AddClient(client);

                    removeClient_btn.Visibility = Visibility.Visible;
                }
            }
            catch
            {

            }
        }

        public void ChangeButtonText(string newText)
        {
            if (total_btn.Template.FindName("total_btn_text", total_btn) is TextBlock textBlock)
                textBlock.Text = newText;
        }

        public string GetButtonText()
        {
            if (total_btn.Template.FindName("total_btn_text", total_btn) is TextBlock textBlock)
            {
                return textBlock.Text.ToString();
            }
            else
            {
                return "";
            }
        }


        private void removeClient_btn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                clients_list_grid.Visibility = Visibility.Hidden;
                client_grid.Visibility = Visibility.Hidden;
                client_name.Text = "";
                client_number.Text = "";
                targetWindow.dashboard.cash_navbar.RemoveClient();
                removeClient_btn.Visibility = Visibility.Hidden;
            }
            catch
            {

            }
        }
    }
}
