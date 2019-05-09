using Whoever.Entities.Common;

namespace BaseProject.Domain.Enums
{
    public abstract class AnnualFeeSchedule : Enumeration
    {
        public static AnnualFeeSchedule None = new NoneType();
        public static AnnualFeeSchedule Biannual = new BiannualType();
        public static AnnualFeeSchedule Annual = new AnnualType();

        protected AnnualFeeSchedule(int id, string name)
            : base(id, name)
        {
        }

        private class NoneType : AnnualFeeSchedule
        {
            public NoneType() : base(1, "None")
            { }
        }

        private class BiannualType : AnnualFeeSchedule
        {
            public BiannualType() : base(2, "Biannual")
            { }
        }

        private class AnnualType : AnnualFeeSchedule
        {
            public AnnualType() : base(3, "Annual")
            { }
        }
    }
}
