using System;

namespace Whoever.Common.Helpers
{
    // <summary>
    public static class DateHelper
    {
        public static WeekDay DateDiffInWeek(DateTime dateFrom, DateTime dateTo)
        {
            var daysDifference = (dateTo - dateFrom).TotalDays;
            var week = Convert.ToInt32(Math.Floor(daysDifference / 7));
            var days = Convert.ToInt32(daysDifference - (week * 7));

            return new WeekDay { TotalDay = daysDifference, Weeks = week, Days = days };
        }
    }

    public class WeekDay
    {
        public double TotalDay {get;set;}
        public int Weeks { get; set; }
        public int Days { get; set; }
    }
}



