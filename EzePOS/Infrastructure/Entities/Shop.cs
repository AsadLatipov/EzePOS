using EzePOS.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.Entities
{
    public class Shop : BaseEntity
    {
        public double TotalAmount { get; set; }
        public double Cash { get; set; }
        public double Card { get; set; }
        public double Debt { get; set; }
        public double Discount { get; set; }
        public int ClientId { get; set; }
    }
}
