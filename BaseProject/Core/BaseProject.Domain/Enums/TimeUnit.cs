using Whoever.Entities.Common;

namespace BaseProject.Domain.Enums
{
    public abstract class TimeUnit : Enumeration
    {
        public static TimeUnit Day = new DayType();
        public static TimeUnit Week = new WeekType();
        public static TimeUnit Month = new MonthType();
        public static TimeUnit Year = new YearType();

        protected TimeUnit(int id, string name)
            : base(id, name)
        {
        }

        private class DayType : TimeUnit
        {
            public DayType() : base(0, "Day")
            { }
        }

        private class WeekType : TimeUnit
        {
            public WeekType() : base(1, "Week")
            { }
        }

        private class MonthType : TimeUnit
        {
            public MonthType() : base(2, "Month")
            { }
        }

        private class YearType : TimeUnit
        {
            public YearType() : base(3, "Year")
            { }
        }
    }

}
