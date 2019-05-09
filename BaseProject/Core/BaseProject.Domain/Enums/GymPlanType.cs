using Whoever.Entities.Common;

namespace BaseProject.Domain.Enums
{
    public abstract class GymPlanType : Enumeration
    {
        public static GymPlanType OneTime = new OneTimeType();
        public static GymPlanType Recurring = new RecurringType();

        protected GymPlanType(int id, string name)
            : base(id, name)
        {
        }

        private class OneTimeType : GymPlanType
        {
            public OneTimeType() : base(1, "One Time")
            { }
        }

        private class RecurringType : GymPlanType
        {
            public RecurringType() : base(2, "Recurring")
            { }
        }
    }
}
