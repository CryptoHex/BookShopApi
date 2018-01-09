using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static int GetValueOrOneIfDefault(this string value)
        {
            int result = 0;
            if (value == null)
            {
                return 1;
            }
            if (int.TryParse(value, out result))
            {
                return result;
            }
            return 1;
        }
    }
}
