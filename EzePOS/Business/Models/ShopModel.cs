using EzePOS.Business.Helper;
using EzePOS.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EzePOS.Business.Models
{
    public class ShopModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public double Count { get; set; }
        public double Discount { get; set; }
        public double TotalPrice
        {
            get { return Count * Product.SellingPrice;}
            set { TotalPrice = value; }
        }
        public string TotalPriceShow
        {
            get
            {
                return (Product.SellingPrice * Count).Amount();
            }
        }
        public string CountShow
        {
            get
            {
                return Count.Amount();
            }
        }
        public Visibility Visibility { get; set; } = Visibility.Hidden;
        public Thickness Margin { get; set; } = new Thickness(0, 0, 10, 0);
        public bool DeleteStatus { get; set; } = false;
    }
}
