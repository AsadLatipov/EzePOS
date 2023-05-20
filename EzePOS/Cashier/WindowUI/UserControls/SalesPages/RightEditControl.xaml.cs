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
    /// Interaction logic for RightEditControl.xaml
    /// </summary>
    public partial class RightEditControl : UserControl
    {
        public RightEditControl()
        {
            InitializeComponent();
        }

        public int ProductId;
        double price = 0;
        double totalPrice = 0;

        private void cancel_delete_window_btn_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows?.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.rightEdit.Visibility = Visibility.Hidden;
        }
        public void SetProduct(ShopModel shop)
        {
            try
            {
                ProductId = shop.Product.Id;
                product_name.Text = shop.Product.Name;
                product_cost.Text = shop.Product.SellingPrice.ToString();
                product_count.Text = shop.CountShow.ToString();
                product_total.Text = shop.TotalPrice.ToString();
                product_discount1.Text = shop.Discount.ToString();
                price = shop.Product.SellingPrice;
                totalPrice = shop.TotalPrice;
            }
            catch
            {

            }

        }
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

        public void Write(Button btn)
        {
            try
            {
                if(product_discount.Text == "0")
                {
                    product_discount.Text = "";
                }
                double temp = double.Parse(product_discount.Text + btn.Content.ToString());

                if (temp > 100)
                {

                }
                else
                {
                    product_discount.Text = product_discount.Text + btn.Content.ToString();

                    double result = totalPrice * temp / 100;

                    product_total.Text = (totalPrice - result).Amount();
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
                if (product_discount.Text != "" && product_discount.Text != null)
                {
                    product_discount.Text = product_discount.Text.Remove(product_discount.Text.Length - 1);
                    
                    if(product_discount.Text == "")
                    {
                        product_total.Text = totalPrice.Amount();
                    }
                    else
                    {
                        double result = totalPrice * double.Parse(product_discount.Text) / 100;
                        product_total.Text = (totalPrice - result).Amount();
                    }
                }
            }
            catch
            {

            }
           
        }

        private void minus_button_Click(object sender, RoutedEventArgs e)
        {
            double count = double.Parse(product_count.Text);
            if (count == 1)
            {

            }
            else
            {
                count--;
                product_count.Text = count.ToString();
                totalPrice = totalPrice - price;

                product_total.Text = totalPrice.Amount();
            }

        }

        private void plus_button_Click(object sender, RoutedEventArgs e)
        {
            double count = double.Parse(product_count.Text);
            count++;
            product_count.Text = count.ToString();
            totalPrice = totalPrice + price;
            product_total.Text = totalPrice.Amount();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows?.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            try
            {
                List<ShopModel> items = targetWindow.dashboard.cash_navbar.GetPageItems();

                items.Where(obj => obj.Product.Id == ProductId).FirstOrDefault().Count = int.Parse(product_count.Text);
                if (double.Parse(product_total.Text.Replace(" ", "")) < totalPrice)
                {
                    var temp = double.Parse(product_total.Text.Replace(" ", "")) / totalPrice * 100;
                    items.Where(obj => obj.Product.Id == ProductId).FirstOrDefault().Discount = temp;
                }
                else
                {
                    items.Where(obj => obj.Product.Id == ProductId).FirstOrDefault().Discount = 0;
                }

                targetWindow.dashboard.rightEdit.Visibility = Visibility.Hidden;
                targetWindow.dashboard.cash_navbar.RefreshItems();
            }
            catch
            {

            }

        }
    }
}
