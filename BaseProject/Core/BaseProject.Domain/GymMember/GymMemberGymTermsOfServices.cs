using System;
using Whoever.Entities;
using Whoever.Entities.Interfaces;

namespace BaseProject.Domain
{
    public partial class GymMemberGymTermsOfServices : IHasCreationTime
    {
        public int GymMemberId { get; set; }
        public int GymTermsOfServicesId { get; set; }
        public DateTime CreationTime { get; set; }
        
        public virtual GymMember GymMember { get; set; }
        public virtual GymTermsOfServices GymTermsOfServices { get; set; }
    }
}
