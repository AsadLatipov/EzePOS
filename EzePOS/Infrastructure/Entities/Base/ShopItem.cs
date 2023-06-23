using EzePOS.Business.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.Entities.Base
{
    public class ShopItem : BaseEntity
    {
        public int ShopId { get; set; }
        public string ProductName { get; set; }
        public double ProductSellingPrice { get; set; }
        public double ProductIncomePrice { get; set; }
        public string ProductBarcode { get; set; }
        public double Count { get; set; }
        public double Total { get; set; }

        [NotMapped]
        public string TotalShow
        {
            get
            {
                return Total.Amount();
            }
        }
    }
}
