﻿using EzePOS.Business.Helper;
using EzePOS.Business.Models;
using EzePOS.Cashier.WindowUI.Windows;
using EzePOS.Infrastructure.Data;
using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.Entities.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using EzePOS.Business.IServices;
using EzePOS.Business.Services;
using EzePOS.Infrastructure.IRepositories;
using EzePOS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Configuration;
using System.Data;

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
        public double Discount = 0;
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
                    else if (withDebtGotFocus)
                    {
                        withDebt_cash_text.Text += button.Content.ToString();
                    }
                    else if (withCardGotFocus)
                    {
                        withCard_card_text.Text += button.Content.ToString();
                    }
                }
                else
                {
                    if (isDebtInvolved)
                    {
                        if (withDebtGotFocus)
                        {
                            withDebt_cash_text.Text += button.Content.ToString();

                        }
                        else if (withMainCashGotFocus)
                        {
                            withoutcard_txt.Text += button.Content.ToString();
                        }
                    }
                    else
                    {
                        withoutcard_txt.Text += button.Content.ToString();
                    }

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
                    else if (withDebtGotFocus)
                    {
                        if (withDebt_cash_text.Text != "" && withDebt_cash_text.Text != null)
                        {
                            withDebt_cash_text.Text = withDebt_cash_text.Text.Remove(withDebt_cash_text.Text.Length - 1);
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
                    if (isDebtInvolved)
                    {
                        if (withDebtGotFocus)
                        {
                            if (withDebt_cash_text.Text != "" && withDebt_cash_text.Text != null)
                            {
                                withDebt_cash_text.Text = withDebt_cash_text.Text.Remove(withDebt_cash_text.Text.Length - 1);
                            }
                        }
                        else if (withMainCashGotFocus)
                        {
                            if (withoutcard_txt.Text != "" && withoutcard_txt.Text != null)
                            {
                                withoutcard_txt.Text = withoutcard_txt.Text.Remove(withoutcard_txt.Text.Length - 1);
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
                Discount = 0;
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
                Discount = discount;
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


        private async void ClientsList_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            clients_list_grid.Visibility = Visibility.Visible;
            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

            List<Client> clients = new List<Client>();

            var aa = await targetWindow._clientService.GetAllAsync();

            clients = aa.Data.ToList();

            dataGrid.ItemsSource = clients;
            dataGrid.Items.Refresh();
        }

        private void clients_list_cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            clients_list_grid.Visibility = Visibility.Hidden;
        }

        private async void total_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                Shop shop = new Shop();
                shop.Cash = double.Parse(GetButtonText().Replace(" ", "")); ;
                shop.TotalAmount = shop.Cash;
                shop.Card = 0;
                shop.Debt = 0;

                Client client = targetWindow.dashboard.cash_navbar.GetClient();
                if (client != null)
                    shop.ClientId = client.Id;

                shop.Discount = Discount;

                List<ShopItem> shopitems = new List<ShopItem>();

                var shops = targetWindow.dashboard.cash_navbar.GetPageItems();

                foreach (var items in shops)
                {
                    ShopItem shopitem = new ShopItem();

                    shopitem.Total = items.TotalPrice;
                    shopitem.Count = items.Count;
                    shopitem.ShopId = shop.Id;
                    shopitem.ProductName = items.Product.Name;
                    shopitem.ProductIncomePrice = items.Product.IncomePrice;
                    shopitem.ProductSellingPrice = items.Product.SellingPrice;
                    shopitem.ProductBarcode = items.Product.Barcode;

                    shopitems.Add(shopitem);

                }

                bool result = await ShopCreate(shopitems, shop);
                if (result)
                {
                    CloseAllPaymentStuffs();
                    targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
                    targetWindow.dashboard.printCheck.Visibility = Visibility.Visible;
                }
            }
            catch
            {

            }
        }

        private async void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            try
            {
                if (withCard)
                {
                    double cash = double.Parse(string.IsNullOrEmpty(withCard_cash_text.Text) ? "0" : withCard_cash_text.Text.Replace(" ", ""));
                    double card = double.Parse(string.IsNullOrEmpty(withCard_card_text.Text) ? "0" : withCard_card_text.Text.Replace(" ", ""));
                    double debt = double.Parse(string.IsNullOrEmpty(withDebt_cash_text.Text) ? "0" : withDebt_cash_text.Text.Replace(" ", ""));

                    double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                    double total = cash + card + debt;
                    if (total >= totalAmount)
                    {

                        Shop shop = new Shop();
                        shop.Cash = cash;
                        shop.TotalAmount = totalAmount;
                        shop.Card = card;
                        shop.Debt = debt;

                        Client client = targetWindow.dashboard.cash_navbar.GetClient();
                        if (client != null)
                            shop.ClientId = client.Id;

                        shop.Discount = Discount;

                        List<ShopItem> shopitems = new List<ShopItem>();

                        var shops = targetWindow.dashboard.cash_navbar.GetPageItems();

                        foreach (var items in shops)
                        {
                            ShopItem shopitem = new ShopItem();

                            shopitem.Total = items.TotalPrice;
                            shopitem.Count = items.Count;
                            shopitem.ShopId = shop.Id;
                            shopitem.ProductName = items.Product.Name;
                            shopitem.ProductIncomePrice = items.Product.IncomePrice;
                            shopitem.ProductSellingPrice = items.Product.SellingPrice;
                            shopitem.ProductBarcode = items.Product.Barcode;

                            shopitems.Add(shopitem);

                        }

                        bool result = await ShopCreate(shopitems, shop);
                        if (result)
                        {
                            CloseAllPaymentStuffs();
                            targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
                            targetWindow.dashboard.printCheck.Visibility = Visibility.Visible;
                        }
                    }
                }
                else
                {

                    double cash = double.Parse(string.IsNullOrEmpty(withoutcard_txt.Text) ? "0" : withoutcard_txt.Text.Replace(" ", ""));
                    double debt = double.Parse(string.IsNullOrEmpty(withDebt_cash_text.Text) ? "0" : withDebt_cash_text.Text.Replace(" ", ""));

                    double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                    double total = cash + debt;
                    if (total >= totalAmount)
                    {
                        Shop shop = new Shop();
                        shop.Cash = cash;
                        shop.TotalAmount = totalAmount;
                        shop.Card = 0;
                        shop.Debt = debt;

                        Client client = targetWindow.dashboard.cash_navbar.GetClient();
                        if (client != null)
                            shop.ClientId = client.Id;

                        shop.Discount = Discount;

                        List<ShopItem> shopitems = new List<ShopItem>();

                        var shops = targetWindow.dashboard.cash_navbar.GetPageItems();

                        foreach (var items in shops)
                        {
                            ShopItem shopitem = new ShopItem();

                            shopitem.Total = items.TotalPrice;
                            shopitem.Count = items.Count;
                            shopitem.ShopId = shop.Id;
                            shopitem.ProductName = items.Product.Name;
                            shopitem.ProductIncomePrice = items.Product.IncomePrice;
                            shopitem.ProductSellingPrice = items.Product.SellingPrice;
                            shopitem.ProductBarcode = items.Product.Barcode;

                            shopitems.Add(shopitem);

                        }

                        bool result = await ShopCreate(shopitems, shop);
                        if (result)
                        {
                            CloseAllPaymentStuffs();
                            targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
                            targetWindow.dashboard.printCheck.Visibility = Visibility.Visible;
                        }
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
            Discount = 0;
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
            isDebtInvolved = false;


            debt_btn.Visibility = Visibility.Visible;
            withDebt_grid.Visibility = Visibility.Collapsed;
            withDebt_cash_text.Text = "";

        }

        private void withoutcard_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (isDebtInvolved)
                {
                    double cash = double.Parse(string.IsNullOrEmpty(withoutcard_txt.Text) ? "0" : withoutcard_txt.Text.Replace(" ", ""));
                    double debt = double.Parse(string.IsNullOrEmpty(withDebt_cash_text.Text) ? "0" : withDebt_cash_text.Text.Replace(" ", ""));

                    double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                    double total = cash + debt;

                    if (cash == 0)
                    {
                        withoutcard_txt.Text = "";
                    }
                    else
                    {
                        withoutcard_txt.Text = cash.Amount();
                    }
                    if (debt == 0)
                    {
                        withDebt_cash_text.Text = "";
                    }
                    else
                    {
                        withDebt_cash_text.Text = debt.Amount();
                    }

                   

                    if (total > totalAmount)
                    {
                        change_text.Text = (total - totalAmount).Amount();
                    }
                    else
                    {
                        change_text.Text = "0";
                    }

                    withoutcard_txt.Focus();
                    withoutcard_txt.CaretIndex = withoutcard_txt.Text.Length;
                }
                else
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

        public async Task<bool> ShopCreate(List<ShopItem> shopitems, Shop shop)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            var dbContext = App.ServiceProvider.GetRequiredService<EzeposContext>();

            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var result = await targetWindow._shopService.CreateAsync(shop, targetWindow.dashboard.user);

                    if (result.Data != null)
                    {
                        shopitems.ForEach(obj => obj.ShopId = result.Data.Id);

                        foreach (ShopItem shopitem in shopitems)
                        {
                            await targetWindow._shopItemService.CreateAsync(shopitem, targetWindow.dashboard.user);
                        }

                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        private async void submit_btn_withcard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                Shop shop = new Shop();
                shop.Card = double.Parse(GetButtonText().Replace(" ", ""));
                shop.TotalAmount = shop.Card;
                shop.Cash = 0;
                shop.Debt = 0;

                Client client = targetWindow.dashboard.cash_navbar.GetClient();
                if (client != null)
                    shop.ClientId = client.Id;

                shop.Discount = Discount;

                List<ShopItem> shopitems = new List<ShopItem>();

                var shops = targetWindow.dashboard.cash_navbar.GetPageItems();

                foreach (var items in shops)
                {
                    ShopItem shopitem = new ShopItem();

                    shopitem.Total = items.TotalPrice;
                    shopitem.Count = items.Count;
                    shopitem.ShopId = shop.Id;
                    shopitem.ProductName = items.Product.Name;
                    shopitem.ProductIncomePrice = items.Product.IncomePrice;
                    shopitem.ProductSellingPrice = items.Product.SellingPrice;
                    shopitem.ProductBarcode = items.Product.Barcode;

                    shopitems.Add(shopitem);
                }

                bool result = await ShopCreate(shopitems, shop);
                if (result)
                {
                    CloseAllPaymentStuffs();
                    targetWindow.dashboard.cash_navbar.closeWindow(targetWindow.dashboard.cash_navbar.currentPage);
                    targetWindow.dashboard.printCheck.Visibility = Visibility.Visible;
                }
            }
            catch
            {

            }
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
                double debt = double.Parse(string.IsNullOrEmpty(withDebt_cash_text.Text) ? "0" : withDebt_cash_text.Text.Replace(" ", ""));

                double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                double total = cash + card + debt;

                if (cash == 0)
                {
                    withCard_cash_text.Text = "";
                }
                else
                {
                    withCard_cash_text.Text = cash.Amount();
                }
                if(debt == 0)
                {
                    withDebt_cash_text.Text = "";
                }
                else
                {
                    withDebt_cash_text.Text = debt.Amount();

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
                double debt = double.Parse(string.IsNullOrEmpty(withDebt_cash_text.Text) ? "0" : withDebt_cash_text.Text.Replace(" ", ""));

                double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                double total = cash + card + debt;

                if (cash == 0)
                {
                    withCard_cash_text.Text = "";
                }
                else
                {
                    withCard_cash_text.Text = cash.Amount();
                }
                if(debt == 0)
                {
                    withDebt_cash_text.Text = "";
                }
                else
                {
                    withDebt_cash_text.Text = debt.Amount();
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
        bool withDebtGotFocus = false;
        bool withMainCashGotFocus = false;

        private void withCard_cash_text_GotFocus(object sender, RoutedEventArgs e)
        {
            withCashGotFocus = true;
            withCardGotFocus = false;
            withDebtGotFocus = false;
        }

        private void withCard_card_text_GotFocus(object sender, RoutedEventArgs e)
        {
            withCardGotFocus = true;
            withCashGotFocus = false;
            withDebtGotFocus = false;

        }
        private void withDebt_cash_text_GotFocus(object sender, RoutedEventArgs e)
        {
            withDebtGotFocus = true;
            withCashGotFocus = false;
            withCardGotFocus = false;
            withMainCashGotFocus = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = dataGrid.SelectedItem as Client;
                if (client != null)
                {
                    var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

                    clients_list_grid.Visibility = Visibility.Hidden;
                    client_grid.Visibility = Visibility.Hidden;
                    client_name.Text = "";
                    client_number.Text = "";

                    targetWindow.dashboard.cash_navbar.AddClient(client);
                    debt_btn.Visibility = Visibility.Visible;

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

                withDebt_grid.Visibility = Visibility.Collapsed;
                withDebt_cash_text.Text = "";
                isDebtInvolved = false;
                object aa = null;
                TextChangedEventArgs temp = null;
                if (withCard)
                {

                    withDebt_cash_text_TextChanged(aa, temp);
                }
                else
                {
                    withoutcard_txt_TextChanged(aa, temp);

                }
            }
            catch
            {

            }
        }

        private void withDebt_cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            debt_btn.Visibility = Visibility.Visible;
            withDebt_grid.Visibility = Visibility.Collapsed;
            withDebt_cash_text.Text = "";
            isDebtInvolved = false;
            object aa = null;
            TextChangedEventArgs temp = null;
            if (withCard)
            {
                
                withDebt_cash_text_TextChanged(aa, temp);
            }
            else
            {
                withoutcard_txt_TextChanged(aa, temp);

            }
        }

        private void withDebt_cash_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (withCard)
                {
                    double card = double.Parse(string.IsNullOrEmpty(withCard_card_text.Text) ? "0" : withCard_card_text.Text.Replace(" ", ""));
                    double cash = double.Parse(string.IsNullOrEmpty(withCard_cash_text.Text) ? "0" : withCard_cash_text.Text.Replace(" ", ""));
                    double debt = double.Parse(string.IsNullOrEmpty(withDebt_cash_text.Text) ? "0" : withDebt_cash_text.Text.Replace(" ", ""));

                    double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                    double total = cash + card + debt;

                    if (cash == 0)
                    {
                        withCard_cash_text.Text = "";
                    }
                    else
                    {
                        withCard_cash_text.Text = cash.Amount();
                    }
                    if (debt == 0)
                    {
                        withDebt_cash_text.Text = "";
                    }
                    else
                    {
                        withDebt_cash_text.Text = debt.Amount();
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

                    withDebt_cash_text.Focus();
                    withDebt_cash_text.CaretIndex = withDebt_cash_text.Text.Length;
                }
                else
                {
                    double cash = double.Parse(string.IsNullOrEmpty(withoutcard_txt.Text) ? "0" : withoutcard_txt.Text.Replace(" ", ""));
                    double debt = double.Parse(string.IsNullOrEmpty(withDebt_cash_text.Text) ? "0" : withDebt_cash_text.Text.Replace(" ", ""));

                    double totalAmount = double.Parse(string.IsNullOrEmpty(GetButtonText()) ? "0" : GetButtonText().Replace(" ", ""));

                    double total = cash + debt;

                    if (cash == 0)
                    {
                        withCard_cash_text.Text = "";
                    }
                    else
                    {
                        withCard_cash_text.Text = cash.Amount();
                    }
                    if (debt == 0)
                    {
                        withDebt_cash_text.Text = "";
                    }
                    else
                    {
                        withDebt_cash_text.Text = debt.Amount();
                    }
                    if (total > totalAmount)
                    {
                        change_text.Text = (total - totalAmount).Amount();
                    }
                    else
                    {
                        change_text.Text = "0";
                    }

                    withDebt_cash_text.Focus();
                    withDebt_cash_text.CaretIndex = withDebt_cash_text.Text.Length;
                }
                
            }
            catch
            {

            }
        }

        bool isDebtInvolved = false;
        private void debt_btn_Click(object sender, RoutedEventArgs e)
        {
            withDebt_grid.Visibility = Visibility.Visible;
            debt_btn.Visibility = Visibility.Collapsed;
            isDebtInvolved = true;
        }

        private void withoutcard_txt_GotFocus(object sender, RoutedEventArgs e)
        {
            withMainCashGotFocus = true;
            withDebtGotFocus = false;
        }

        private async void add_client_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (client_name.Text != "" && client_name.Text != null)
                {
                    if (client_number.Text != "" && client_number.Text != null)
                    {

                        Client client = new Client() { FullName = client_name.Text, PhoneNumber = client_number.Text, Debt = 0 };

                        var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
                        var result = await targetWindow._clientService.CreateAsync(client, targetWindow.dashboard.user);

                        if(result.Data != null)
                        {
                            client_grid.Visibility = Visibility.Hidden;
                            client_name.Text = "";
                            client_number.Text = "";

                            targetWindow.dashboard.cash_navbar.AddClient(result.Data);
                            debt_btn.Visibility = Visibility.Visible;
                            removeClient_btn.Visibility = Visibility.Visible;
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
