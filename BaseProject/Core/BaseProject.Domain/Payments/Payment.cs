using System;
using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public partial class Payment : Entity, IHasCreationTime
    {
        public Payment()
        {
            Details = new HashSet<PaymentDetail>();
        }
        public int? GymOwnerId { get; set; }
        public int? KioskId { get; set; }
        public int? GymMemberId{ get; set; }
        public int? GymMemberPlanId { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual GymOwner GymOwner { get; set; }
        public virtual Kiosk Kiosk { get; set; }
        public virtual GymMember GymMember { get; set; }
        public virtual GymMemberPlan GymMemberPlan { get; set; }
        public virtual ICollection<PaymentDetail> Details { get; private set; }
    }
}
