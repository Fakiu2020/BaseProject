using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class GymPlanDay : Entity
    {
        public int DayId { get; set; }
        public int GymPlanId { get; set; }

        public virtual Day Day { get; set; }
        public virtual GymPlan GymPlan { get; set; }
    }
}
