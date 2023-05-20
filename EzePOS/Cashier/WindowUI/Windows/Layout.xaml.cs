using EzePOS.Business.IServices;
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
using System.Windows.Shapes;

namespace EzePOS.Cashier.WindowUI.Windows
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Window
    {
        public IUserService _userService;
        public ICategoryService _categoryService;
        public IProductService _productService;
        //public ISeedData _seedData;

        public Layout(
            IUserService userService,
            ICategoryService categoryService,
            IProductService productService)
        {
            _userService = userService;
            _productService = productService;
            _categoryService = categoryService;
            


            //_seedData.AddUser();
            //_seedData.AddCategories();
            //_seedData.AddProducts();
            InitializeComponent();
        }

        public Layout()
        {
            //Uri uri = new Uri("pack://application:,,,/Cashier/Assets/Icons/icon.ico", UriKind.RelativeOrAbsolute);

            //this.Icon = BitmapFrame.Create(uri);
        }
    }
}
