using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using EzePOS.Business.Helper;
using EzePOS.Business.Models;
using EzePOS.Cashier.WindowUI.Windows;
using EzePOS.Infrastructure.Entities;

namespace EzePOS.Cashier.WindowUI.UserControls.Navs
{
    /// <summary>
    /// Interaction logic for CashNavBar.xaml
    /// </summary>
    public partial class CashNavBar : UserControl
    {
        public CashNavBar()
        {
            InitializeComponent();
        }

        //public DiscountCard card1card = new DiscountCard();
        public List<ShopModel> page1Items = new List<ShopModel>();
        //public bool page1Card = false;
        public Client page1Client = new Client();
        public bool page1ClientExist = false;

        //public DiscountCard card2card = new DiscountCard();
        public List<ShopModel> page2Items = new List<ShopModel>();
        //public bool page2Card = false;
        public Client page2Client = new Client();
        public bool page2ClientExist = false;

        //public DiscountCard card3card = new DiscountCard();
        public List<ShopModel> page3Items = new List<ShopModel>();
        //public bool page3Card = false;
        public Client page3Client = new Client();
        public bool page3ClientExist = false;

        //public DiscountCard card4card = new DiscountCard();
        public List<ShopModel> page4Items = new List<ShopModel>();
        //public bool page4Card = false;
        public Client page4Client = new Client();
        public bool page4ClientExist = false;

        //public DiscountCard card5card = new DiscountCard();
        public List<ShopModel> page5Items = new List<ShopModel>();
        //public bool page5Card = false;
        public Client page5Client = new Client();
        public bool page5ClientExist = false;
        public int currentPage = 1;

        int l = 1;
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            l++;
            if (l == 2)
            {
                page2_button.Visibility = Visibility.Visible;
                page2_border.Visibility = Visibility.Visible;
                ChooseBtn(2);
            }
            if (l == 3)
            {
                page3_button.Visibility = Visibility.Visible;
                page3_border.Visibility = Visibility.Visible;
                ChooseBtn(3);

            }
            if (l == 4)
            {
                page4_button.Visibility = Visibility.Visible;
                page4_border.Visibility = Visibility.Visible;
                ChooseBtn(4);

            }
            if (l == 5)
            {
                page5_button.Visibility = Visibility.Visible;
                page5_border.Visibility = Visibility.Visible;
                ChooseBtn(5);
            }
            if (l > 5)
            {

                //MessageBox.Show((string)FindResource("can_not_add"));
                MessageBox.Show("can_not_add");
                //targetWindow.dashboard.barcodeReader_txt.Focus();
            }
        }

        private void ChooseBtn(int btnNumber)
        {
            BrushConverter bc = new BrushConverter();
            Brush brushSc = (Brush)bc?.ConvertFrom("#09C5A3");
            Brush brushCus = (Brush)bc?.ConvertFrom("#969B99");
            brushSc.Freeze();
            brushCus.Freeze();
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            try
            {
                //targetWindow.dashboard.datagridBorder.Height = new GridLength(5, GridUnitType.Star);
                //targetWindow.dashboard.ClientnameBorder.Height = new GridLength(100, GridUnitType.Star);
                //targetWindow.dashboard.shopgrid.Height = 370;
                //targetWindow.dashboard.clientnameStack.Visibility = Visibility.Hidden;
                targetWindow.dashboard.salesPanel.client_name.Text = "";
                targetWindow.dashboard.salesPanel.client_number.Text = "";
                //targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Hidden;
                targetWindow.dashboard.salesPanel.client_show_stack.Visibility = Visibility.Hidden;
                targetWindow.dashboard.salesPanel.client_show_stack.Height = 0;
                //targetWindow.dashboard.clientLastname.Text = "";
                //targetWindow.dashboard.belongToDebt.Visibility = Visibility.Hidden;

                //targetWindow.dashboard.card_txt.Text = "0000 0000 0000 0000";
                //targetWindow.dashboard.card_residu_txt.Text = "0";

                //targetWindow.dashboard.card_bonus_txt.Text = "0";
                switch (btnNumber)
                {
                    case 1:
                        page1_button.Foreground = brushSc;
                        page2_button.Foreground = brushCus;
                        page3_button.Foreground = brushCus;
                        page4_button.Foreground = brushCus;
                        page5_button.Foreground = brushCus;

                        //page1radiusBorder.BorderThickness = new Thickness(1);
                        //page2radiusBorder.BorderThickness = new Thickness(0);
                        //page3radiusBorder.BorderThickness = new Thickness(0);
                        //page4radiusBorder.BorderThickness = new Thickness(0);
                        //page5radiusBorder.BorderThickness = new Thickness(0);

                        targetWindow.dashboard.salesPanel.shopdatagrid.ItemsSource = page1Items;
                        targetWindow.dashboard.salesPanel.shopdatagrid.Items.Refresh();
                        //if (page1Card == true)
                        //{
                        //    targetWindow.dashboard.card_txt.Text = card1card.CardNumberShow;
                        //    targetWindow.dashboard.card_residu_txt.Text = card1card.CardResidue.Amount();

                        //    targetWindow.dashboard.datagridBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.ClientnameBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.shopgrid.Height = 330;
                        //    targetWindow.dashboard.clientnameStack.Visibility = Visibility.Visible;
                        //    targetWindow.dashboard.clientFirstname.Text = card1card.ClientName;
                        //    targetWindow.dashboard.clientLastname.Text = "";
                        //    targetWindow.dashboard.card_bonus_txt.Text = card1card.Percent.ToString();

                        //}
                        //else
                        //{

                        if (page1ClientExist)
                        {
                            targetWindow.dashboard.salesPanel.client_name.Text = page1Client.FullName;
                            targetWindow.dashboard.salesPanel.client_number.Text = page1Client.PhoneNumber;
                            //targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Height = 50;
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Collapsed;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Hidden;
                        }

                        //}

                        break;

                    case 2:
                        page1_button.Foreground = brushCus;
                        page2_button.Foreground = brushSc;
                        page3_button.Foreground = brushCus;
                        page4_button.Foreground = brushCus;
                        page5_button.Foreground = brushCus;
                        //page1radiusBorder.BorderThickness = new Thickness(0);
                        //page2radiusBorder.BorderThickness = new Thickness(1);
                        //page3radiusBorder.BorderThickness = new Thickness(0);
                        //page4radiusBorder.BorderThickness = new Thickness(0);
                        //page5radiusBorder.BorderThickness = new Thickness(0);

                        targetWindow.dashboard.salesPanel.shopdatagrid.ItemsSource = page2Items;
                        targetWindow.dashboard.salesPanel.shopdatagrid.Items.Refresh();
                        //if (page2Card == true)
                        //{
                        //    targetWindow.dashboard.card_txt.Text = card2card.CardNumberShow;
                        //    targetWindow.dashboard.card_residu_txt.Text = card2card.CardResidue.Amount();

                        //    targetWindow.dashboard.datagridBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.ClientnameBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.shopgrid.Height = 330;
                        //    targetWindow.dashboard.clientnameStack.Visibility = Visibility.Visible;
                        //    targetWindow.dashboard.clientFirstname.Text = card2card.ClientName;
                        //    targetWindow.dashboard.clientLastname.Text = "";
                        //    targetWindow.dashboard.card_bonus_txt.Text = card2card.Percent.ToString();


                        //}
                        //else
                        //{

                        if (page2ClientExist)
                        {
                            targetWindow.dashboard.salesPanel.client_name.Text = page2Client.FullName;
                            targetWindow.dashboard.salesPanel.client_number.Text = page2Client.PhoneNumber;
                            //targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Height = 50;
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Collapsed;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Hidden;
                        }

                        //}

                        break;
                    case 3:
                        page1_button.Foreground = brushCus;
                        page2_button.Foreground = brushCus;
                        page3_button.Foreground = brushSc;
                        page4_button.Foreground = brushCus;
                        page5_button.Foreground = brushCus;
                        //page1radiusBorder.BorderThickness = new Thickness(0);
                        //page2radiusBorder.BorderThickness = new Thickness(0);
                        //page3radiusBorder.BorderThickness = new Thickness(1);
                        //page4radiusBorder.BorderThickness = new Thickness(0);
                        //page5radiusBorder.BorderThickness = new Thickness(0);

                        targetWindow.dashboard.salesPanel.shopdatagrid.ItemsSource = page3Items;
                        targetWindow.dashboard.salesPanel.shopdatagrid.Items.Refresh();
                        //if (page3Card == true)
                        //{
                        //    targetWindow.dashboard.card_txt.Text = card3card.CardNumberShow;
                        //    targetWindow.dashboard.card_residu_txt.Text = card3card.CardResidue.Amount();

                        //    targetWindow.dashboard.datagridBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.ClientnameBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.shopgrid.Height = 330;
                        //    targetWindow.dashboard.clientnameStack.Visibility = Visibility.Visible;
                        //    targetWindow.dashboard.clientFirstname.Text = card3card.ClientName;
                        //    targetWindow.dashboard.clientLastname.Text = "";
                        //    targetWindow.dashboard.card_bonus_txt.Text = card3card.Percent.ToString();


                        //}
                        //else
                        //{

                        if (page3ClientExist)
                        {
                            targetWindow.dashboard.salesPanel.client_name.Text = page3Client.FullName;
                            targetWindow.dashboard.salesPanel.client_number.Text = page3Client.PhoneNumber;
                            //targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Height = 50;
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Collapsed;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Hidden;
                        }
                        //}

                        break;
                    case 4:
                        page1_button.Foreground = brushCus;
                        page2_button.Foreground = brushCus;
                        page3_button.Foreground = brushCus;
                        page4_button.Foreground = brushSc;
                        page5_button.Foreground = brushCus;
                        //page1radiusBorder.BorderThickness = new Thickness(0);
                        //page2radiusBorder.BorderThickness = new Thickness(0);
                        //page3radiusBorder.BorderThickness = new Thickness(0);
                        //page4radiusBorder.BorderThickness = new Thickness(1);
                        //page5radiusBorder.BorderThickness = new Thickness(0);

                        targetWindow.dashboard.salesPanel.shopdatagrid.ItemsSource = page4Items;
                        targetWindow.dashboard.salesPanel.shopdatagrid.Items.Refresh();
                        //if (page4Card == true)
                        //{
                        //    targetWindow.dashboard.card_txt.Text = card4card.CardNumberShow;
                        //    targetWindow.dashboard.card_residu_txt.Text = card4card.CardResidue.Amount();

                        //    targetWindow.dashboard.datagridBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.ClientnameBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.shopgrid.Height = 330;
                        //    targetWindow.dashboard.clientnameStack.Visibility = Visibility.Visible;
                        //    targetWindow.dashboard.clientFirstname.Text = card4card.ClientName;
                        //    targetWindow.dashboard.clientLastname.Text = "";
                        //    targetWindow.dashboard.card_bonus_txt.Text = card4card.Percent.ToString();


                        //}
                        //else
                        //{
                        if (page4ClientExist)
                        {
                            targetWindow.dashboard.salesPanel.client_name.Text = page4Client.FullName;
                            targetWindow.dashboard.salesPanel.client_number.Text = page4Client.PhoneNumber;
                            //targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Height = 50;
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Collapsed;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Hidden;
                        }

                        //}

                        break;
                    case 5:
                        page1_button.Foreground = brushCus;
                        page2_button.Foreground = brushCus;
                        page3_button.Foreground = brushCus;
                        page4_button.Foreground = brushCus;
                        page5_button.Foreground = brushSc;
                        //page1radiusBorder.BorderThickness = new Thickness(0);
                        //page2radiusBorder.BorderThickness = new Thickness(0);
                        //page3radiusBorder.BorderThickness = new Thickness(0);
                        //page4radiusBorder.BorderThickness = new Thickness(0);
                        //page5radiusBorder.BorderThickness = new Thickness(1);

                        targetWindow.dashboard.salesPanel.shopdatagrid.ItemsSource = page5Items;
                        targetWindow.dashboard.salesPanel.shopdatagrid.Items.Refresh();
                        //if (page5Card == true)
                        //{
                        //    targetWindow.dashboard.card_txt.Text = card5card.CardNumberShow;
                        //    targetWindow.dashboard.card_residu_txt.Text = card5card.CardResidue.Amount();

                        //    targetWindow.dashboard.datagridBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.ClientnameBorder.Height = new GridLength(3, GridUnitType.Star);
                        //    targetWindow.dashboard.shopgrid.Height = 330;
                        //    targetWindow.dashboard.clientnameStack.Visibility = Visibility.Visible;
                        //    targetWindow.dashboard.clientFirstname.Text = card5card.ClientName;
                        //    targetWindow.dashboard.clientLastname.Text = "";
                        //    targetWindow.dashboard.card_bonus_txt.Text = card5card.Percent.ToString();

                        //}
                        //else
                        //{

                        if (page5ClientExist)
                        {
                            targetWindow.dashboard.salesPanel.client_name.Text = page5Client.FullName;
                            targetWindow.dashboard.salesPanel.client_number.Text = page5Client.PhoneNumber;
                            //targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Visibility = Visibility.Visible;
                            targetWindow.dashboard.salesPanel.client_show_stack.Height = 50;
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Visible;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            targetWindow.dashboard.paymentpart.debt_btn.Visibility = Visibility.Collapsed;
                            targetWindow.dashboard.paymentpart.removeClient_btn.Visibility = Visibility.Hidden;
                        }
                        //}

                        break;

                }
                currentPage = btnNumber;
                RefreshItems();
                //targetWindow.dashboard.productname_txt.Text = "";
                //targetWindow.dashboard.calculate_txt.Text = "";
                //targetWindow.dashboard.barcodeReader_txt.Focus();
            }
            catch
            {
                //targetWindow.dashboard.barcodeReader_txt.Focus();
            }
        }

        public void RefreshItems()
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
                List<ShopModel> Items = GetPageItems();


                int number = 1;
                if (Items.Count > 0)
                {
                    foreach (var shopitem in Items)
                    {
                        //shopitem.Number = number;
                        number++;
                    }
                    double total = 0;
                    Items.ForEach(obj => total += obj.TotalPrice);
                    ConvertHelper.Amount(total);
                    targetWindow.dashboard.salesPanel.submit_btn.Content = ConvertHelper.Amount(total);
                    targetWindow.dashboard.salesPanel.shopdatagrid.ItemsSource = Items;
                    targetWindow.dashboard.salesPanel.shopdatagrid.Items.Refresh();
                    targetWindow.dashboard.salesPanel.withdatagrid.Visibility = Visibility.Visible;
                    targetWindow.dashboard.salesPanel.withoutshopgrid.Visibility = Visibility.Hidden;


                }
                else
                {
                    targetWindow.dashboard.salesPanel.submit_btn.Content = "0";
                    targetWindow.dashboard.salesPanel.shopdatagrid.ItemsSource = Items;
                    targetWindow.dashboard.salesPanel.shopdatagrid.Items.Refresh();
                    targetWindow.dashboard.salesPanel.withoutshopgrid.Visibility = Visibility.Visible;
                    targetWindow.dashboard.salesPanel.withdatagrid.Visibility = Visibility.Hidden;

                }
            }
            catch
            {

            }
        }

        public void closeWindow(int i)
        {
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            int w = 0;
            if (i == 1)
            {
                if (page5_button.Visibility == Visibility.Visible)
                {
                    //card1card = card2card;
                    //page1Card = page2Card;
                    page1Items = page2Items;
                    page1Client = page2Client;
                    page1ClientExist = page2ClientExist;

                    //card2card = card3card;
                    //page2Card = page3Card;
                    page2Items = page3Items;
                    page2Client = page3Client;
                    page2ClientExist = page3ClientExist;

                    //card3card = card4card;
                    //page3Card = page4Card;
                    page3Items = page4Items;
                    page3Client = page4Client;
                    page3ClientExist = page4ClientExist;

                    //card4card = card5card;
                    //page4Card = page5Card;
                    page4Items = page5Items;
                    page4Client = page5Client;
                    page4ClientExist = page5ClientExist;

                    //card5card = new DiscountCard();
                    //page5Card = false;
                    page5Items = new List<ShopModel>();
                    page5Client = new Client();
                    page5ClientExist = false;

                    l = 4;
                    page5_button.Visibility = Visibility.Hidden;
                    page5_border.Visibility = Visibility.Hidden;

                    w++;
                    ChooseBtn(4);
                }

                if (page4_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card1card = card2card;
                        //page1Card = page2Card;
                        page1Items = page2Items;
                        page1Client = page2Client;
                        page1ClientExist = page2ClientExist;

                        //card2card = card3card;
                        //page2Card = page3Card;
                        page2Items = page3Items;
                        page2Client = page3Client;
                        page2ClientExist = page3ClientExist;

                        //card3card = card4card;
                        //page3Card = page4Card;
                        page3Items = page4Items;
                        page3Client = page4Client;
                        page3ClientExist = page4ClientExist;

                        //card4card = new DiscountCard();
                        //page4Card = false;
                        page4Items = new List<ShopModel>();
                        page4Client = new Client();
                        page4ClientExist = false;


                        l = 3;
                        page4_button.Visibility = Visibility.Hidden;
                        page4_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(3);
                    }
                }

                if (page3_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card1card = card2card;
                        //page1Card = page2Card;
                        page1Items = page2Items;
                        page1Client = page2Client;
                        page1ClientExist = page2ClientExist;

                        //card2card = card3card;
                        //page2Card = page3Card;
                        page2Items = page3Items;
                        page2Client = page3Client;
                        page2ClientExist = page3ClientExist;

                        //card3card = new DiscountCard();
                        //page3Card = false;
                        page3Items = new List<ShopModel>();
                        page3Client = new Client();
                        page3ClientExist = false;

                        l = 2;
                        page3_button.Visibility = Visibility.Hidden;
                        page3_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(2);
                    }
                }

                if (page2_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card1card = card2card;
                        //page1Card = page2Card;
                        page1Items = page2Items;
                        page1Client = page2Client;
                        page1ClientExist = page2ClientExist;

                        //card2card = new DiscountCard();
                        //page2Card = false;
                        page2Items = new List<ShopModel>();
                        page2Client = new Client();
                        page2ClientExist = false;

                        l = 1;
                        page2_button.Visibility = Visibility.Hidden;
                        page2_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(1);

                    }
                }

                if (page1_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card1card = new DiscountCard();
                        //page1Card = false;
                        page1Items = new List<ShopModel>();
                        page1Client = new Client();
                        page1ClientExist = false;

                        ChooseBtn(1);
                    }
                }

            }

            if (i == 2)
            {
                if (page5_button.Visibility == Visibility.Visible)
                {
                    //card2card = card3card;
                    //page2Card = page3Card;
                    page2Items = page3Items;
                    page2Client = page3Client;
                    page2ClientExist = page3ClientExist;

                    //card3card = card4card;
                    //page3Card = page4Card;
                    page3Items = page4Items;
                    page3Client = page4Client;
                    page3ClientExist = page4ClientExist;

                    //card4card = card5card;
                    //page4Card = page5Card;
                    page4Items = page5Items;
                    page4Client = page5Client;
                    page4ClientExist = page5ClientExist;

                    //card5card = new DiscountCard();
                    //page5Card = false;
                    page5Items = new List<ShopModel>();
                    page5Client = new Client();
                    page5ClientExist = false;

                    l = 4;
                    page5_button.Visibility = Visibility.Hidden;
                    page5_border.Visibility = Visibility.Hidden;

                    w++;
                    ChooseBtn(3);

                }

                if (page4_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card2card = card3card;
                        //page2Card = page3Card;
                        page2Items = page3Items;
                        page2Client = page3Client;
                        page2ClientExist = page3ClientExist;

                        //card3card = card4card;
                        //page3Card = page4Card;
                        page3Items = page4Items;
                        page3Client = page4Client;
                        page3ClientExist = page4ClientExist;

                        //card4card = new DiscountCard();
                        //page4Card = false;
                        page4Items = new List<ShopModel>();
                        page4Client = new Client();
                        page4ClientExist = false;


                        l = 3;
                        page4_button.Visibility = Visibility.Hidden;
                        page4_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(3);

                    }
                }

                if (page3_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card1card = card2card;
                        //page1Card = page2Card;
                        page1Items = page2Items;
                        page1Client = page2Client;
                        page1ClientExist = page2ClientExist;

                        //card2card = card3card;
                        //page2Card = page3Card;
                        page2Items = page3Items;
                        page2Client = page3Client;
                        page2ClientExist = page3ClientExist;

                        //card3card = new DiscountCard();
                        //page3Card = false;
                        page3Items = new List<ShopModel>();
                        page3Client = new Client();
                        page3ClientExist = false;

                        l = 2;
                        page3_button.Visibility = Visibility.Hidden;
                        page3_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(2);

                    }
                }

                if (page2_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card2card = new DiscountCard();
                        //page2Card = false;
                        page2Items = new List<ShopModel>();
                        page2Client = new Client();
                        page2ClientExist = false;

                        l = 1;
                        page2_button.Visibility = Visibility.Hidden;
                        page2_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(1);

                    }
                }


            }

            if (i == 3)
            {
                if (page5_button.Visibility == Visibility.Visible)
                {
                    //card3card = card4card;
                    //page3Card = page4Card;
                    page3Items = page4Items;
                    page3Client = page4Client;
                    page3ClientExist = page4ClientExist;

                    //card4card = card5card;
                    //page4Card = page5Card;
                    page4Items = page5Items;
                    page4Client = page5Client;
                    page4ClientExist = page5ClientExist;

                    //card5card = new DiscountCard();
                    //page5Card = false;
                    page5Items = new List<ShopModel>();
                    page5Client = new Client();
                    page5ClientExist = false;

                    l = 4;
                    page5_button.Visibility = Visibility.Hidden;
                    page5_border.Visibility = Visibility.Hidden;

                    w++;
                    ChooseBtn(4);

                }

                if (page4_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card3card = card4card;
                        //page3Card = page4Card;
                        page3Items = page4Items;
                        page3Client = page4Client;
                        page3ClientExist = page4ClientExist;

                        //card4card = new DiscountCard();
                        //page4Card = false;
                        page4Items = new List<ShopModel>();
                        page4Client = new Client();
                        page4ClientExist = false;


                        l = 3;
                        page4_button.Visibility = Visibility.Hidden;
                        page4_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(3);
                    }
                }

                if (page3_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card3card = new DiscountCard();
                        //page3Card = false;
                        page3Items = new List<ShopModel>();
                        page3Client = new Client();
                        page3ClientExist = false;

                        l = 2;
                        page3_button.Visibility = Visibility.Hidden;
                        page3_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(2);
                    }
                }


            }

            if (i == 4)
            {
                if (page5_button.Visibility == Visibility.Visible)
                {
                    //card4card = card5card;
                    //page4Card = page5Card;
                    page4Items = page5Items;
                    page4Client = page5Client;
                    page4ClientExist = page5ClientExist;

                    ////card5card = new DiscountCard();
                    ////page5Card = false;
                    page5Items = new List<ShopModel>();
                    page5Client = new Client();
                    page5ClientExist = false;

                    l = 4;
                    page5_button.Visibility = Visibility.Hidden;
                    page5_border.Visibility = Visibility.Hidden;

                    w++;
                    ChooseBtn(4);

                }

                if (page4_button.Visibility == Visibility.Visible)
                {
                    if (w == 0)
                    {
                        //card4card = new DiscountCard();
                        //page4Card = false;
                        page4Items = new List<ShopModel>();
                        page4Client = new Client();
                        page4ClientExist = false;


                        l = 3;
                        page4_button.Visibility = Visibility.Hidden;
                        page4_border.Visibility = Visibility.Hidden;

                        w++;
                        ChooseBtn(3);
                    }

                }


            }
            if (i == 5)
            {
                //card5card = new DiscountCard();
                //page5Card = false;
                page5Items = new List<ShopModel>();
                page5Client = new Client();
                page5ClientExist = false;

                l = 4;
                page5_button.Visibility = Visibility.Hidden;
                page5_border.Visibility = Visibility.Hidden;

                w++;
                ChooseBtn(4);

            }
        }
        public List<ShopModel> GetPageItems()
        {
            switch (currentPage)
            {
                case 1:
                    return page1Items;
                case 2:
                    return page2Items;
                case 3:
                    return page3Items;
                case 4:
                    return page4Items;
                case 5:
                    return page5Items;
                default:
                    return new List<ShopModel>();
            }
        }


        public void RemoveClient()
        {

            if (currentPage == 1)
            {
                page1ClientExist = false;
                page1Client = new Client();
            }
            else if (currentPage == 2)
            {
                page2ClientExist = false;
                page2Client = new Client();
            }
            else if (currentPage == 3)
            {
                page3ClientExist = false;
                page3Client = new Client();
            }
            else if (currentPage == 4)
            {
                page4ClientExist = false;
                page4Client = new Client();
            }
            else if (currentPage == 5)
            {
                page5ClientExist = false;
                page5Client = new Client();
            }

            ChooseBtn(currentPage);

        }

        public void AddClient(Client client)
        {
            if (client != null)
            {
                if (currentPage == 1)
                {
                    page1ClientExist = true;
                    page1Client = client;
                }
                else if (currentPage == 2)
                {
                    page2ClientExist = true;
                    page2Client = client;
                }
                else if (currentPage == 3)
                {
                    page3ClientExist = true;
                    page3Client = client;
                }
                else if (currentPage == 4)
                {
                    page4ClientExist = true;
                    page4Client = client;
                }
                else if (currentPage == 5)
                {
                    page5ClientExist = true;
                    page5Client = client;
                }

                ChooseBtn(currentPage);
            }

        }

        private void page1_button_Click(object sender, RoutedEventArgs e)
        {
            ChooseBtn(1);
        }

        private void page2_button_Click(object sender, RoutedEventArgs e)
        {
            ChooseBtn(2);

        }

        private void page3_button_Click(object sender, RoutedEventArgs e)
        {
            ChooseBtn(3);

        }

        private void page4_button_Click(object sender, RoutedEventArgs e)
        {
            ChooseBtn(4);

        }

        private void page5_button_Click(object sender, RoutedEventArgs e)
        {
            ChooseBtn(5);

        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            targetWindow.dashboard.searchpartgrid.Visibility = Visibility.Visible;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
            targetWindow.dashboard.searchpart.search_txt.Focus();
        }
    }
}
