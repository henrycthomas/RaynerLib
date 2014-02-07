using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rayner.Extensions
{
    public static class Dates
    {
        public static bool IsSameDay(this DateTime d1, DateTime d2)
        {
            return d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day;
        }
        public static string ToShortDateTimeString(this DateTime d1)
        {
            return d1.ToShortDateString() + " " + d1.ToShortTimeString();
        }
        public static string ToFriendlyString(this DateTime d1)
        {
            if (d1.IsSameDay(DateTime.Now))
            {
                return "Today " + d1.ToShortTimeString();
            }
            else if (d1.IsSameDay(DateTime.Now.AddDays(-1)))
            {
                return "Yesterday " + d1.ToShortTimeString();
            }
            else if (d1 >= DateTime.Now.AddDays(-7))
            {
                return d1.DayOfWeek.ToString() + " " + d1.ToShortTimeString();
            }
            else
            {
                return d1.ToShortDateTimeString();
            }
        }
    }
}
