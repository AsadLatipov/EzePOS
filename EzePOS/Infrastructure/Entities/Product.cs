using EzePOS.Business.Helper;
using EzePOS.Infrastructure.Entities.Base;
using EzePOS.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public double IncomePrice { get; set; }
        public double SellingPrice { get; set;}
        public string Barcode { get; set; }
        public DateTime? ExprirationDate { get; set; }
        public Measure Measure { get; set; }

        public string ExprirationDateShow
        {
            get { return ExprirationDate?.ToString("dd MM yyyy");}
        }

        [NotMapped]
        public string SellingPriceShow
        {
            get { return SellingPrice.Amount(); }
        }
        [NotMapped]

        public string IncomePriceShow
        {
            get { return IncomePrice.Amount(); }
        }

    }
}
