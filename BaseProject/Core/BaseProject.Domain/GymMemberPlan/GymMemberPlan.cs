using BaseProject.Domain.Enums;
using System;
using System.Collections.Generic;
using Whoever.Entities;
using Whoever.Entities.Common;

namespace BaseProject.Domain
{

    public partial class GymMemberPlan : Entity
    {
        public GymMemberPlan()
        {
            Payments = new HashSet<Payment>();
            KioskAccesses = new HashSet<KioskAccess>();
        }

        public int GymMemberId { get; set; }
        public int GymPlanId { get; set; }
        public int CreditCardId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? CancelledDate { get; set; }
        public int StatusId { get; set; }
        public DateTime? ActiveUntil { get; set; }
        public int? AdditionalMembers { get; set; }
        public int? PriceRangeId { get; set; }
        public int? EnrollmentFeeId { get; set; }
        public DateTime? LastSuccessfullBillingDate { get; set; }
        public DateTime? CommitmentEndDate { get; set; }

        public virtual EnrollmentFee EnrollmentFee { get; set; }
        public virtual PriceRange PriceRange { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual GymMember GymMember { get; set; }
        public virtual GymPlan GymPlan { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Payment> Payments { get; private set; }
        public virtual ICollection<KioskAccess> KioskAccesses { get; private set; }

        public virtual GymPlanStatus Status => Enumeration.GetById<GymPlanStatus>(StatusId);

    }
}
