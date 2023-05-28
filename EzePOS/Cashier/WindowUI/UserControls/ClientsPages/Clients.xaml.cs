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

namespace EzePOS.Cashier.WindowUI.UserControls.ClientsPages
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        public List<Clientt> clients = new List<Clientt>();
        public Clients()
        {
            InitializeComponent();
            clients.Add(new Clientt { Id = 1, FirstName = "Asadbek", LastName = "Latipov", PhoneNumber = "+998913561310", Discount = "Lorem ipsom doin", Debt = "0" });
            clients.Add(new Clientt { Id = 2, FirstName = "Oydina", LastName = "Fayziyeva", PhoneNumber = "+998913561310", Discount = "Lorem ipsom doin", Debt = "100 000" });
            clients.Add(new Clientt { Id = 3, FirstName = "Umar", LastName = "Qodirov", PhoneNumber = "+998913561310", Discount = "Lorem ipsom doin", Debt = "50 000" });
            clients.Add(new Clientt { Id = 4, FirstName = "Hamdam", LastName = "Umarov", PhoneNumber = "+998913561310", Discount = "Lorem ipsom doin", Debt = "18 000" });
            clients.Add(new Clientt { Id = 5, FirstName = "Sarvinoz", LastName = "Olimova", PhoneNumber = "+998913561310", Discount = "Lorem ipsom doin", Debt = "300 000" });

            datagrid.ItemsSource = clients;
            datagrid.Items.Refresh();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var targetWindow = Application.Current.Windows.Cast<Layout>().FirstOrDefault(window => window is Layout) as Layout;

            targetWindow.dashboard.addclient.Visibility = Visibility.Visible;
        }
    }

    public class Clientt
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Discount { get; set; }
        public string Debt { get; set; }
        public string Fullname
        {
            get { return LastName + " " + FirstName; }
        }
    }
}
