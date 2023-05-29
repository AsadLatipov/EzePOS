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

namespace EzePOS.Cashier.WindowUI.UserControls.CommonPages
{
    /// <summary>
    /// Interaction logic for LeftMenu.xaml
    /// </summary>
    public partial class LeftMenu : UserControl
    {
        public LeftMenu()
        {
            InitializeComponent();
        }

        public double CurrentPage = 1.1;

        // if false back if true forward
        bool cashButtonChecker = false;
        private void btn_1_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButton(1);
        }
        private void btn_2_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButton(2);
            //ChangePage(2);
        }
     
        private void btn_4_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButton(4);
            ChangePage(4);
        }
        private void btn_5_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButton(5);
            //CurrentPage = 5;
        }
        private void btn_6_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButton(6);
            //CurrentPage = 6;
        }

        private void btn_right_1_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButtonRight(1);
            ChangePage(1.1);
        }
        private void btn_right_2_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButtonRight(2);
            //ChangePage(1.2);
        }
        private void btn_right_3_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButtonRight(3);
            //CurrentPage = 1.3;
            //ChangePage(1.3);

        }
        private void btn_right_4_click(object sender, RoutedEventArgs e)
        {

            BackgrounColorChangeButtonRight(4);
            //ChangePage(1.4);
        }
        private void btn_right_5_click(object sender, RoutedEventArgs e)
        {
            BackgrounColorChangeButtonRight(6);
            //ChangePage(1.6);
        }
        public async void  ChangePage(double pageId)
        {
            var targetWindow = Application.Current.Windows?.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.salesPanel.Visibility = Visibility.Hidden;
            //targetWindow.dashboard.products.Visibility = Visibility.Hidden;
            //targetWindow.dashboard.debts.Visibility = Visibility.Hidden;
            //targetWindow.dashboard.returnPage.Visibility = Visibility.Hidden;
            targetWindow.dashboard.clients.Visibility = Visibility.Hidden;
            //targetWindow.dashboard.close_the_shift.Visibility = Visibility.Hidden;
            //targetWindow.dashboard.history.Visibility = Visibility.Hidden;
            //targetWindow.dashboard.puttingMoney.Visibility = Visibility.Hidden;
            //targetWindow.dashboard.discount.Visibility = Visibility.Hidden;

            switch (pageId)
            {
                case 1.1:
                    targetWindow.dashboard.page_name.Text = "Kassa";
                    targetWindow.dashboard.salesPanel.Visibility = Visibility.Visible;
                    CurrentPage = 1.1;
                    ChangeNavBar(1);
                    break;

                case 1.2:
                    targetWindow.dashboard.page_name.Text = "Sotuv tarixi";
                    //targetWindow.dashboard.history.Visibility = Visibility.Visible;
                    CurrentPage = 1.2;
                    ChangeNavBar(5);
                    break;

                case 1.3:
                    targetWindow.dashboard.page_name.Text = "Qaytarish";
                    //targetWindow.dashboard.returnPage.Visibility = Visibility.Visible;
                    CurrentPage = 1.3;
                    ChangeNavBar(3);
                    break;


                case 1.4:
                    //targetWindow.dashboard.puttingMoney.Visibility = Visibility.Visible;
                    targetWindow.dashboard.page_name.Text = "Sotuv tarixi";
                    //targetWindow.dashboard.history.Visibility = Visibility.Visible;
                    CurrentPage = 1.2;
                    ChangeNavBar(5);
                    //targetWindow.dashboard.puttingMoney.Visibility = Visibility.Visible;
                    BackgrounColorChangeButtonRight(2);
                    break;

                case 1.5:
                    break;



                case 1.6:
                    targetWindow.dashboard.page_name.Text = "Nasiyalar";
                    //targetWindow.dashboard.debts.Visibility = Visibility.Visible;
                    ChangeNavBar(2);
                    CurrentPage = 1.6;
                    break;



                case 2:
                    targetWindow.dashboard.page_name.Text = "Mahsulotlar";
                    //targetWindow.dashboard.products.Visibility = Visibility.Visible;
                    CurrentPage = 2;
                    ChangeNavBar(1);
                    break;

                case 3:
                    targetWindow.dashboard.page_name.Text = "Chegirma";
                    //targetWindow.dashboard.discount.Visibility = Visibility.Visible;
                    CurrentPage = 3;
                    ChangeNavBar(2);
                    break;

                case 4:
                    targetWindow.dashboard.page_name.Text = "Klientlar";
                    targetWindow.dashboard.clients.Visibility = Visibility.Visible;
                    await targetWindow.dashboard.clients.SetClientsAsync();
                    CurrentPage = 4;
                    ChangeNavBar(3);
                    break;


                case 5:
                    break;

                //CloseTheShift
                case 6:

                    targetWindow.dashboard.page_name.Text = "Smenani yopish";
                    //targetWindow.dashboard.close_the_shift.Visibility = Visibility.Visible;
                    CurrentPage = 6;
                    ChangeNavBar(4);
                    break;

                default:
                    break;
            }
            targetWindow.dashboard.leftMenu.Visibility = Visibility.Hidden;
            second_part.Visibility = Visibility.Hidden;
            first_part.Visibility = Visibility.Visible;
            cashButtonChecker = false;

            cash_image_forward.Visibility = Visibility.Visible;
            cash_image_back.Visibility = Visibility.Hidden;
        }

        public void ChangeNavBar(int id)
        {
            var targetWindow = Application.Current.Windows?.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            if (id == 1)
            {
                targetWindow.dashboard.cash_navbar.Visibility = Visibility.Visible;
                targetWindow.dashboard.search_filter_navbar.Visibility = Visibility.Hidden;
                targetWindow.dashboard.search_navbar.Visibility = Visibility.Hidden;
                //targetWindow.dashboard.close_the_shift_navBar.Visibility = Visibility.Hidden;
            }
            else if (id == 2)
            {
                targetWindow.dashboard.search_filter_navbar.Visibility = Visibility.Visible;
                targetWindow.dashboard.cash_navbar.Visibility = Visibility.Hidden;
                targetWindow.dashboard.search_navbar.Visibility = Visibility.Hidden;
                //targetWindow.dashboard.close_the_shift_navBar.Visibility = Visibility.Hidden;

            }
            else if (id == 3)
            {
                targetWindow.dashboard.search_navbar.Visibility = Visibility.Visible;
                targetWindow.dashboard.cash_navbar.Visibility = Visibility.Hidden;
                targetWindow.dashboard.search_filter_navbar.Visibility = Visibility.Hidden;
                //targetWindow.dashboard.close_the_shift_navBar.Visibility = Visibility.Hidden;
            }
            else if (id == 4)
            {
                //targetWindow.dashboard.close_the_shift_navBar.Visibility = Visibility.Visible;
                targetWindow.dashboard.search_navbar.Visibility = Visibility.Hidden;
                targetWindow.dashboard.cash_navbar.Visibility = Visibility.Hidden;
                targetWindow.dashboard.search_filter_navbar.Visibility = Visibility.Hidden;
            }
            else if (id == 5)
            {
                //targetWindow.dashboard.close_the_shift_navBar.Visibility = Visibility.Hidden;
                targetWindow.dashboard.search_navbar.Visibility = Visibility.Hidden;
                targetWindow.dashboard.cash_navbar.Visibility = Visibility.Hidden;
                targetWindow.dashboard.search_filter_navbar.Visibility = Visibility.Hidden;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows?.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.leftMenu.Visibility = Visibility.Hidden;
            cashButtonChecker = false;
            cash_image_forward.Visibility = Visibility.Visible;
            cash_image_back.Visibility = Visibility.Hidden;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows?.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow!.dashboard.leftMenu.Visibility = Visibility.Hidden;
            second_part.Visibility = Visibility.Hidden;
            first_part.Visibility = Visibility.Visible;
            cashButtonChecker = false;

            cash_image_forward.Visibility = Visibility.Visible;
            cash_image_back.Visibility = Visibility.Hidden;
        }

        public void BackgrounColorChangeButton(int buttonnumber)
        {
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc!.ConvertFrom("#F0F5F3");
            Brush brush2 = (Brush)bc!.ConvertFrom("#DCE1DF");
            brush?.Freeze();
            brush2?.Freeze();

            switch (buttonnumber)
            {
                case 1:
                    if (cashButtonChecker is false)
                    {
                        second_part.Visibility = Visibility.Visible;
                        first_part.Visibility = Visibility.Hidden;
                        cash_image_forward.Visibility = Visibility.Hidden;
                        cash_image_back.Visibility = Visibility.Visible;
                        cashButtonChecker = true;

                    }
                    else
                    {
                        second_part.Visibility = Visibility.Hidden;
                        first_part.Visibility = Visibility.Visible;
                        cash_image_forward.Visibility = Visibility.Visible;
                        cash_image_back.Visibility = Visibility.Hidden;
                        cashButtonChecker = false;
                    }
                    break;
                case 2:
                    button_1_background_color.Background = Brushes.Transparent;
                    button_2_background_color.Background = brush;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;

                    break;
                case 3:
                    button_1_background_color.Background = Brushes.Transparent;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;
                    break;
                case 4:
                    button_1_background_color.Background = Brushes.Transparent;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = brush;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;
                    break;
                case 5:
                    button_1_background_color.Background = Brushes.Transparent;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = brush;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;
                    break;
                case 6:
                    button_1_background_color.Background = Brushes.Transparent;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;
                    button_6_background_color.Background = brush;
                    break;
                default:
                    break;

            }


        }
        public void BackgrounColorChangeButtonRight(int buttonnumber)
        {
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc?.ConvertFrom("#F0F5F3");
            Brush brush2 = (Brush)bc?.ConvertFrom("#DCE1DF");
            brush?.Freeze();
            brush2?.Freeze();

            switch (buttonnumber)
            {
                case 1:
                    button_1_background_color.Background = brush;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = brush2;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;
                    break;
                case 2:
                    button_1_background_color.Background = brush;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = brush2;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;

                    break;
                case 3:
                    button_1_background_color.Background = brush;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = brush2;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;
                    break;
                case 4:
                    button_1_background_color.Background = brush;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = brush2;
                    button_5_right.Background = Brushes.Transparent;
                    break;
                case 5:
                    button_1_background_color.Background = brush;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = brush2;
                    break;
                case 6:
                    button_1_background_color.Background = brush;
                    button_2_background_color.Background = Brushes.Transparent;
                    button_4_background_color.Background = Brushes.Transparent;
                    button_5_background_color.Background = Brushes.Transparent;
                    button_6_background_color.Background = Brushes.Transparent;

                    button_1_right.Background = Brushes.Transparent;
                    button_2_right.Background = Brushes.Transparent;
                    button_3_right.Background = Brushes.Transparent;
                    button_4_right.Background = Brushes.Transparent;
                    button_5_right.Background = Brushes.Transparent;
                    break;
                default:
                    break;

            }
        }
    }
}
