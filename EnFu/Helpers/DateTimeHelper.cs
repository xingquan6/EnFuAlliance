using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnFu.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetFirstSunday(int month)
        {
            // to do
            return DateTime.Now;
        }
    }

    public static class DateTimeExtension
    {
        public static DateTime CurrentSunday(this DateTime dt)
        {
            int dayOfWeek = ((int)dt.DayOfWeek == 0) ? 7 : (int)dt.DayOfWeek;
            return dt.AddDays(7 - dayOfWeek).Date;
        }
    }
}