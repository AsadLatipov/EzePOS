using EzePOS.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
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
    }
}
