using System;
using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class GymMember : Entity
    {
        public GymMember()
        {
            KioskAccesses = new HashSet<KioskAccess>();
            GymMemberPlans = new HashSet<GymMemberPlan>();
            GymTermsOfServices = new HashSet<GymMemberGymTermsOfServices>();
            Groups = new HashSet<GroupGymMember>();
            Payments = new HashSet<Payment>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressId { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string MaintenanceFee { get; set; }
        public DateTime? CancelledDate { get; set; }

        public virtual User User { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<KioskAccess> KioskAccesses { get; private set; }
        public virtual ICollection<GymMemberPlan> GymMemberPlans { get; private set; }
        public virtual ICollection<GymMemberGymTermsOfServices> GymTermsOfServices { get; private set; }
        public virtual ICollection<GroupGymMember> Groups { get; private set; }
        public virtual ICollection<Payment> Payments { get; private set; }
    }
}
