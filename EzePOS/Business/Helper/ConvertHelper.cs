using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Business.Helper
{
    public static class ConvertHelper
    {
        public static string Amount(this double amount)
        {
            try
            {
                var numStr = amount.ToString("0.###");
                var len = numStr.Length;
                var result = new StringBuilder();
                for (var i = 0; i < len; i++)
                {
                    if (i > 0 && i % 3 == 0) result.Insert(0, " ");
                    result.Insert(0, numStr[len - 1 - i]);
                }
                return result.ToString();
            }
            catch
            {
                return amount.ToString();
            }
        }
    }
}
