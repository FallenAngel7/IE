using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.ExtensionMethods
{
    public static class DateTimeExtension
    {
        public static DateTime ConvertToDateTime(this string input)
        {
            var year = int.Parse(input.Split('/')[0]);
            var month = int.Parse(input.Split('/')[1]);
            var day = int.Parse(input.Split('/')[2]);

            return new DateTime(year, month, day, new System.Globalization.PersianCalendar());
        }
    }
}
