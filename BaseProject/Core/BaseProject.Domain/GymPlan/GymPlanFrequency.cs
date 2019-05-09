using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class GymPlanFrequency : Entity
    {
        public string Name { get; set; }
        public string PlanId { get; set; }
        public int Order { get; set; }
    }
}
