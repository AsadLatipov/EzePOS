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

namespace EzePOS.Cashier.WindowUI.UserControls.CommonPages
{
    /// <summary>
    /// Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class Keyboard : UserControl
    {
        public Keyboard()
        {
            InitializeComponent();
        }
        private void btnQ_Click(object sender, RoutedEventArgs e)
        {
            Write(btnQ);
        }

        private void btnW_Click(object sender, RoutedEventArgs e)
        {
            Write(btnW);
        }


        private void btnE_Click(object sender, RoutedEventArgs e)
        {
            Write(btnE);
        }

        private void btnR_Click(object sender, RoutedEventArgs e)
        {
            Write(btnR);
        }

        private void btnT_Click(object sender, RoutedEventArgs e)
        {
            Write(btnT);
        }

        private void btnY_Click(object sender, RoutedEventArgs e)
        {
            Write(btnY);
        }

        private void btnU_Click(object sender, RoutedEventArgs e)
        {
            Write(btnU);

        }

        private void btnI_Click(object sender, RoutedEventArgs e)
        {
            Write(btnI);
        }

        private void btnO_Click(object sender, RoutedEventArgs e)
        {
            Write(btnO);
        }

        private void btnP_Click(object sender, RoutedEventArgs e)
        {
            Write(btnP);
        }

        private void btnA_Click(object sender, RoutedEventArgs e)
        {
            Write(btnA);

        }

        private void btnS_Click(object sender, RoutedEventArgs e)
        {
            Write(btnS);
        }

        private void btnD_Click(object sender, RoutedEventArgs e)
        {
            Write(btnD);

        }

        private void btnF_Click(object sender, RoutedEventArgs e)
        {
            Write(btnF);
        }

        private void btnG_Click(object sender, RoutedEventArgs e)
        {
            Write(btnG);
        }

        private void btnH_Click(object sender, RoutedEventArgs e)
        {
            Write(btnH);
        }

        private void btnJ_Click(object sender, RoutedEventArgs e)
        {
            Write(btnJ);
        }

        private void btnK_Click(object sender, RoutedEventArgs e)
        {
            Write(btnK);

        }

        private void btnL_Click(object sender, RoutedEventArgs e)
        {
            Write(btnL);
        }

        private void btnZ_Click(object sender, RoutedEventArgs e)
        {
            Write(btnZ);
        }
        private void btnZZ_Click(object sender, RoutedEventArgs e)
        {
            Write(btnZZ);
        }


        private void btnX_Click(object sender, RoutedEventArgs e)
        {
            Write(btnX);
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            Write(btnC);
        }

        private void btnV_Click(object sender, RoutedEventArgs e)
        {
            Write(btnV);
        }

        private void btnB_Click(object sender, RoutedEventArgs e)
        {
            Write(btnB);
        }

        private void btnN_Click(object sender, RoutedEventArgs e)
        {
            Write(btnN);
        }

        private void btnM_Click(object sender, RoutedEventArgs e)
        {
            Write(btnM);
        }

        private void btnSpace_Click(object sender, RoutedEventArgs e)
        {
            Write(btnSpace);
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
            Write(btnDot);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            Write(btn0);
        }

        public void Write(Button button)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            //if (targetWindow.dashboard.searchpartgrid.Visibility == Visibility.Visible)
            //{
            //    targetWindow.dashboard.searchpart.search_txt.Text += button.Content.ToString();
            //    targetWindow.dashboard.searchpart.search_txt.Focus();

            //    targetWindow.dashboard.searchpart.search_txt.CaretIndex = targetWindow.dashboard.searchpart.search_txt.Text.Length;
            //}
            
            //Payment Clients
            if (targetWindow.dashboard.paymentpart.client_grid.Visibility == Visibility.Visible)
            {
                if (targetWindow.dashboard.paymentpart.clientNameGotFocus)
                {
                    targetWindow.dashboard.paymentpart.client_name.Text += button.Content.ToString();
                    targetWindow.dashboard.paymentpart.client_name.Focus();

                    targetWindow.dashboard.paymentpart.client_name.CaretIndex = targetWindow.dashboard.paymentpart.client_name.Text.Length;
                }
                else if (targetWindow.dashboard.paymentpart.clientNumberGotFocus)
                {
                    targetWindow.dashboard.paymentpart.client_number.Text += button.Content.ToString();
                    targetWindow.dashboard.paymentpart.client_number.Focus();

                    targetWindow.dashboard.paymentpart.client_number.CaretIndex = targetWindow.dashboard.paymentpart.client_number.Text.Length;
                }
            }
            //Payment Discount
            else if (targetWindow.dashboard.addDiscountToShop.Visibility == Visibility.Visible)
            {
                Regex regex = new Regex("[^0-9^]");
                bool temp = regex.IsMatch(button.Content.ToString());
                if (temp == false)
                {
                    targetWindow.dashboard.addDiscountToShop.textBox.Text += button.Content.ToString();
                }
                targetWindow.dashboard.addDiscountToShop.textBox.Focus();

                targetWindow.dashboard.addDiscountToShop.textBox.CaretIndex = targetWindow.dashboard.addDiscountToShop.textBox.Text.Length;

            }
            //NewPassword
            //else if (targetWindow.dashboard.newPassword.Visibility == Visibility.Visible)
            //{
            //    if (targetWindow.dashboard.newPassword.New)
            //    {
            //        targetWindow.dashboard.newPassword.textBoxNew.Text += button.Content.ToString();
            //        targetWindow.dashboard.newPassword.textBoxNew.Focus();

            //        targetWindow.dashboard.newPassword.textBoxNew.CaretIndex = targetWindow.dashboard.newPassword.textBoxNew.Text.Length;
            //    }
            //    else if (targetWindow.dashboard.newPassword.Again)
            //    {
            //        targetWindow.dashboard.newPassword.textBoxAgain.Text += button.Content.ToString();
            //        targetWindow.dashboard.newPassword.textBoxAgain.Focus();

            //        targetWindow.dashboard.newPassword.textBoxAgain.CaretIndex = targetWindow.dashboard.newPassword.textBoxAgain.Text.Length;
            //    }

            //}
            ////OldPassword
            //else if (targetWindow.dashboard.oldPassword.Visibility == Visibility.Visible)
            //{
            //    targetWindow.dashboard.oldPassword.textBox.Text += button.Content.ToString();
            //    targetWindow.dashboard.oldPassword.textBox.Focus();

            //    targetWindow.dashboard.oldPassword.textBox.CaretIndex = targetWindow.dashboard.oldPassword.textBox.Text.Length;
            //}

            ////EditProductAndExchange
            //else if (targetWindow.dashboard.product_edit_exchange.Visibility == Visibility.Visible)
            //{
            //    if (targetWindow.dashboard.product_edit_exchange.productNameGorFocus)
            //    {
            //        targetWindow.dashboard.product_edit_exchange.product_name.Text += button.Content.ToString();
            //        targetWindow.dashboard.product_edit_exchange.product_name.Focus();

            //        targetWindow.dashboard.product_edit_exchange.product_name.CaretIndex = targetWindow.dashboard.product_edit_exchange.product_name.Text.Length;
            //    }
            //    else if (targetWindow.dashboard.product_edit_exchange.productPriceGorFocus)
            //    {
            //        targetWindow.dashboard.product_edit_exchange.product_cost.Text += button.Content.ToString();
            //        targetWindow.dashboard.product_edit_exchange.product_cost.Focus();

            //        targetWindow.dashboard.product_edit_exchange.product_cost.CaretIndex = targetWindow.dashboard.product_edit_exchange.product_cost.Text.Length;
            //    }
            //    else if (targetWindow.dashboard.product_edit_exchange.productQuantityGorFocus)
            //    {
            //        targetWindow.dashboard.product_edit_exchange.product_qauntity.Text += button.Content.ToString();
            //        targetWindow.dashboard.product_edit_exchange.product_qauntity.Focus();

            //        targetWindow.dashboard.product_edit_exchange.product_qauntity.CaretIndex = targetWindow.dashboard.product_edit_exchange.product_qauntity.Text.Length;
            //    }
            //}
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;
            //if (targetWindow.dashboard.searchpartgrid.Visibility == Visibility.Visible)
            //{
            //    if (targetWindow.dashboard.searchpart.search_txt.Text != "" && targetWindow.dashboard.searchpart.search_txt.Text != null)
            //        targetWindow.dashboard.searchpart.search_txt.Text = targetWindow.dashboard.searchpart.search_txt.Text.Remove(targetWindow.dashboard.searchpart.search_txt.Text.Length - 1);

            //    targetWindow.dashboard.searchpart.search_txt.Focus();
            //    targetWindow.dashboard.searchpart.search_txt.CaretIndex = targetWindow.dashboard.searchpart.search_txt.Text.Length;
            //}
            
            //NewPassword
            //else if (targetWindow.dashboard.newPassword.Visibility == Visibility.Visible)
            //{
            //    if (targetWindow.dashboard.newPassword.New)
            //    {
            //        if (targetWindow.dashboard.newPassword.textBoxNew.Text != "" && targetWindow.dashboard.newPassword.textBoxNew.Text != null)
            //            targetWindow.dashboard.newPassword.textBoxNew.Text = targetWindow.dashboard.newPassword.textBoxNew.Text.Remove(targetWindow.dashboard.newPassword.textBoxNew.Text.Length - 1);

            //        targetWindow.dashboard.newPassword.textBoxNew.Focus();
            //        targetWindow.dashboard.newPassword.textBoxNew.CaretIndex = targetWindow.dashboard.newPassword.textBoxNew.Text.Length;
            //    }
            //    else if (targetWindow.dashboard.newPassword.Again)
            //    {
            //        if (targetWindow.dashboard.newPassword.textBoxAgain.Text != "" && targetWindow.dashboard.newPassword.textBoxAgain.Text != null)
            //            targetWindow.dashboard.newPassword.textBoxAgain.Text = targetWindow.dashboard.newPassword.textBoxAgain.Text.Remove(targetWindow.dashboard.newPassword.textBoxAgain.Text.Length - 1);

            //        targetWindow.dashboard.newPassword.textBoxAgain.Focus();
            //        targetWindow.dashboard.newPassword.textBoxAgain.CaretIndex = targetWindow.dashboard.newPassword.textBoxAgain.Text.Length;
            //    }

            //}
            //OldPasword
            //else if (targetWindow.dashboard.oldPassword.Visibility == Visibility.Visible)
            //{
            //    if (targetWindow.dashboard.oldPassword.textBox.Text != "" && targetWindow.dashboard.oldPassword.textBox.Text != null)
            //        targetWindow.dashboard.oldPassword.textBox.Text = targetWindow.dashboard.oldPassword.textBox.Text.Remove(targetWindow.dashboard.oldPassword.textBox.Text.Length - 1);

            //    targetWindow.dashboard.oldPassword.textBox.Focus();
            //    targetWindow.dashboard.oldPassword.textBox.CaretIndex = targetWindow.dashboard.oldPassword.textBox.Text.Length;

            //}
            //Payment Clients
            if (targetWindow.dashboard.paymentpart.client_grid.Visibility == Visibility.Visible)
            {
                if (targetWindow.dashboard.paymentpart.clientNameGotFocus)
                {
                    if (targetWindow.dashboard.paymentpart.client_name.Text != "" && targetWindow.dashboard.paymentpart.client_name.Text != null)
                        targetWindow.dashboard.paymentpart.client_name.Text = targetWindow.dashboard.paymentpart.client_name.Text.Remove(targetWindow.dashboard.paymentpart.client_name.Text.Length - 1);


                    targetWindow.dashboard.paymentpart.client_name.Focus();
                    targetWindow.dashboard.paymentpart.client_name.CaretIndex = targetWindow.dashboard.paymentpart.client_name.Text.Length;
                }
                else if (targetWindow.dashboard.paymentpart.clientNumberGotFocus)
                {
                    if (targetWindow.dashboard.paymentpart.client_number.Text != "" && targetWindow.dashboard.paymentpart.client_number.Text != null)
                        targetWindow.dashboard.paymentpart.client_number.Text = targetWindow.dashboard.paymentpart.client_number.Text.Remove(targetWindow.dashboard.paymentpart.client_number.Text.Length - 1);

                    targetWindow.dashboard.paymentpart.client_number.Focus();
                    targetWindow.dashboard.paymentpart.client_number.CaretIndex = targetWindow.dashboard.paymentpart.client_number.Text.Length;
                }
            }

            //Payment Discount
            else if (targetWindow.dashboard.addDiscountToShop.Visibility == Visibility.Visible)
            {
                if (targetWindow.dashboard.addDiscountToShop.textBox.Text != "" && targetWindow.dashboard.addDiscountToShop.textBox.Text != null)
                    targetWindow.dashboard.addDiscountToShop.textBox.Text = targetWindow.dashboard.addDiscountToShop.textBox.Text.Remove(targetWindow.dashboard.addDiscountToShop.textBox.Text.Length - 1);

                targetWindow.dashboard.addDiscountToShop.textBox.Focus();
                targetWindow.dashboard.addDiscountToShop.textBox.CaretIndex = targetWindow.dashboard.addDiscountToShop.textBox.Text.Length;

            }
            //EditProductAndExchange
            //else if (targetWindow.dashboard.product_edit_exchange.Visibility == Visibility.Visible)
            //{
            //    if (targetWindow.dashboard.product_edit_exchange.productNameGorFocus)
            //    {
            //        if (targetWindow.dashboard.product_edit_exchange.product_name.Text != "" && targetWindow.dashboard.product_edit_exchange.product_name.Text != null)
            //            targetWindow.dashboard.product_edit_exchange.product_name.Text = targetWindow.dashboard.product_edit_exchange.product_name.Text.Remove(targetWindow.dashboard.product_edit_exchange.product_name.Text.Length - 1);

            //        targetWindow.dashboard.product_edit_exchange.product_name.Focus();
            //        targetWindow.dashboard.product_edit_exchange.product_name.CaretIndex = targetWindow.dashboard.product_edit_exchange.product_name.Text.Length;
            //    }
            //    else if (targetWindow.dashboard.product_edit_exchange.productPriceGorFocus)
            //    {
            //        if (targetWindow.dashboard.product_edit_exchange.product_cost.Text != "" && targetWindow.dashboard.product_edit_exchange.product_cost.Text != null)
            //            targetWindow.dashboard.product_edit_exchange.product_cost.Text = targetWindow.dashboard.product_edit_exchange.product_cost.Text.Remove(targetWindow.dashboard.product_edit_exchange.product_cost.Text.Length - 1);

            //        targetWindow.dashboard.product_edit_exchange.product_cost.Focus();
            //        targetWindow.dashboard.product_edit_exchange.product_cost.CaretIndex = targetWindow.dashboard.product_edit_exchange.product_cost.Text.Length;
            //    }
            //    else if (targetWindow.dashboard.product_edit_exchange.productQuantityGorFocus)
            //    {
            //        if (targetWindow.dashboard.product_edit_exchange.product_qauntity.Text != "" && targetWindow.dashboard.product_edit_exchange.product_qauntity.Text != null)
            //            targetWindow.dashboard.product_edit_exchange.product_qauntity.Text = targetWindow.dashboard.product_edit_exchange.product_qauntity.Text.Remove(targetWindow.dashboard.product_edit_exchange.product_qauntity.Text.Length - 1);

            //        targetWindow.dashboard.product_edit_exchange.product_qauntity.Focus();
            //        targetWindow.dashboard.product_edit_exchange.product_qauntity.CaretIndex = targetWindow.dashboard.product_edit_exchange.product_qauntity.Text.Length;
            //    }
            //}
        }

        bool checker = false;

        private void changeLang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checker)
                {
                    btnQ.Content = "Q";
                    btnW.Content = "W";
                    btnE.Content = "E";
                    btnR.Content = "R";
                    btnT.Content = "T";
                    btnY.Content = "Y";
                    btnU.Content = "U";
                    btnI.Content = "I";
                    btnO.Content = "O";
                    btnP.Content = "P";
                    btnA.Content = "A";
                    btnS.Content = "S";
                    btnD.Content = "D";
                    btnF.Content = "F";
                    btnG.Content = "G";
                    btnH.Content = "H";
                    btnJ.Content = "J";
                    btnK.Content = "K";
                    btnL.Content = "L";
                    btnZ.Content = "Z";
                    btnX.Content = "X";
                    btnC.Content = "C";
                    btnV.Content = "V";
                    btnB.Content = "B";
                    btnN.Content = "N";
                    btnM.Content = "M";
                    btnZZ.Content = "Z";
                    checker = false;
                    lang.Text = "RU";
                }
                else
                {
                    btnQ.Content = "Й";
                    btnW.Content = "Ц";
                    btnE.Content = "У";
                    btnR.Content = "К";
                    btnT.Content = "Е";
                    btnY.Content = "Н";
                    btnU.Content = "Г";
                    btnI.Content = "Ш";
                    btnO.Content = "Щ";
                    btnP.Content = "З";
                    btnA.Content = "Ф";
                    btnS.Content = "Ы";
                    btnD.Content = "В";
                    btnF.Content = "Ю";
                    btnG.Content = "П";
                    btnH.Content = "Р";
                    btnJ.Content = "О";
                    btnK.Content = "Л";
                    btnL.Content = "Д";
                    btnZ.Content = "Я";
                    btnX.Content = "Ч";
                    btnC.Content = "С";
                    btnV.Content = "М";
                    btnB.Content = "И";
                    btnN.Content = "Т";
                    btnM.Content = "Ь";
                    btnZZ.Content = "Б";
                    lang.Text = "EN";

                    checker = true;
                }
            }
            catch
            {
                btnQ.Content = "Q";
                btnW.Content = "W";
                btnE.Content = "E";
                btnR.Content = "R";
                btnT.Content = "T";
                btnY.Content = "Y";
                btnU.Content = "U";
                btnI.Content = "I";
                btnO.Content = "O";
                btnP.Content = "P";
                btnA.Content = "A";
                btnS.Content = "S";
                btnD.Content = "D";
                btnF.Content = "F";
                btnG.Content = "G";
                btnH.Content = "H";
                btnJ.Content = "J";
                btnK.Content = "K";
                btnL.Content = "L";
                btnZ.Content = "Z";
                btnX.Content = "X";
                btnC.Content = "C";
                btnV.Content = "V";
                btnB.Content = "B";
                btnN.Content = "N";
                btnM.Content = "M";
                btnZZ.Content = "Z";
                checker = false;
                lang.Text = "RU";
            }
        }
    }
}
