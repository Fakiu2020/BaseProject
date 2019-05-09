using BaseProject.Domain.Enums;
using System;
using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class KioskAccess : Entity
    {
        public int KioskId { get; set; }
        public int GymMemberPlanId { get; set; }
        public int GymMemberId { get; set; }
        public int? GymMemberChildId { get; set; }
        public DateTime AccessDate { get; set; }
        public AccessSourceType SourceType { get; set; }

        public virtual Kiosk Kiosk { get; set; }
        public virtual GymMemberPlan GymMemberPlan { get; set; }
        public virtual GymMember GymMember { get; set; }
        public virtual GymMemberChild GymMemberChild { get; set; }
        
    }
}
