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

namespace EzePOS.Cashier.WindowUI.UserControls.Products
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : UserControl
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.addCategory.Visibility = Visibility.Hidden;
            targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

        }

        private async void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(category_name.Text))
            {
                Category category = new Category();
                category.Name = category_name.Text;
                var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

                var temp = await targetWindow._categoryService.GetAsync(obj => obj.Name.ToLower() == category_name.Text.ToLower());
                if(temp.Data == null)
                {
                    var result = await targetWindow._categoryService.CreateAsync(category, targetWindow.dashboard.user);

                    if (result.Data != null)
                    {
                        targetWindow.dashboard.addCategory.Visibility = Visibility.Hidden;
                        category_name.Text = "";
                        targetWindow.dashboard.products.setCategories();
                        targetWindow.dashboard.keyboard.Visibility = Visibility.Hidden;

                    }
                }
                
            }
        }

        private void category_name_GotFocus(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.keyboard.Visibility = Visibility.Visible;
        }
    }
}
