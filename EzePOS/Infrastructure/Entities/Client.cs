using EzePOS.Business.Helper;
using EzePOS.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.Entities
{
    public class Client : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public double Debt { get; set; }

        [NotMapped]
        public string DebtShow
        {
            get { return Debt.Amount(); }
            set { DebtShow = value; }
        }
    }
}
