using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public class EnrollmentFee : Entity, ISoftDelete
    {
        public EnrollmentFee()
        {
            GymMemberPlans = new HashSet<GymMemberPlan>();
        }

        public decimal Price { get; set; }
        public int Months { get; set; }
        public int GymPlanId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual GymPlan GymPlan { get; set; }
        public virtual ICollection<GymMemberPlan> GymMemberPlans { get; private set; }
    }
}
