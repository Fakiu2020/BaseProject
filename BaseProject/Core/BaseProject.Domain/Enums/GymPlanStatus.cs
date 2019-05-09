using Whoever.Entities.Common;

namespace BaseProject.Domain.Enums
{
    public abstract class GymPlanStatus : Enumeration
    {
        public static GymPlanStatus Pending = new PendingType();
        public static GymPlanStatus Active = new ActiveType();
        public static GymPlanStatus PastDue = new PastDueType();
        public static GymPlanStatus Cancelled = new CancelledType();
        public static GymPlanStatus Lock = new LockType();

        protected GymPlanStatus(int id, string name)
            : base(id, name)
        {
        }

        private class PendingType : GymPlanStatus
        {
            public PendingType() : base(0, "Pending")
            { }
        }

        private class ActiveType : GymPlanStatus
        {
            public ActiveType() : base(1, "Active")
            { }
        }

        private class PastDueType : GymPlanStatus
        {
            public PastDueType() : base(2, "Past Due")
            { }
        }

        private class CancelledType : GymPlanStatus
        {
            public CancelledType() : base(3, "Cancelled")
            { }
        }

        private class LockType : GymPlanStatus
        {
            public LockType() : base(4, "Lock")
            { }
        }

    }
}
