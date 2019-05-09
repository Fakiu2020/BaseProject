using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public class PriceRange : Entity, ISoftDelete
    {
        public PriceRange()
        {
            GymMemberPlans = new List<GymMemberPlan>();
        }

        public int From { get; set; }
        public int To { get; set; }
        public decimal Price { get; set; }
        public int GymPlanId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual GymPlan GymPlan { get; set; }
        public virtual ICollection<GymMemberPlan> GymMemberPlans { get; private set; }
    }
}
