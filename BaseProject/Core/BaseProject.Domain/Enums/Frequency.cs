using Whoever.Entities.Common;

namespace BaseProject.Domain.Enums
{
    public abstract class Frequency : Enumeration
    {
        public static Frequency Month = new MonthType();
        public static Frequency Year = new YearType();

        protected Frequency(int id, string name)
            : base(id, name)
        {
        }

        private class MonthType : Frequency
        {
            public MonthType() : base(1, "Month")
            { }
        }

        private class YearType : Frequency
        {
            public YearType() : base(2, "Year")
            { }
        }
    }
}
