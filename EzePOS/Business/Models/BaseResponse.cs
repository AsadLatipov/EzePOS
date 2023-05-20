using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Business.Models
{
    public class BaseResponse<T>
    {
        public int? Code { get; set; } = 200;
        public T Data { get; set; }
        public ErrorModel Error { get; set; }
    }
}
