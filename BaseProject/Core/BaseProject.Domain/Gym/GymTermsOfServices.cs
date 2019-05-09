using System;
using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class GymTermsOfServices : Entity
    {
        public GymTermsOfServices()
        {
            GymMembers = new HashSet<GymMemberGymTermsOfServices>();
        }

        public string Description { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int GymId { get; set; }

        public virtual Gym Gym { get; set; }
        public virtual ICollection<GymMemberGymTermsOfServices> GymMembers { get; private set; }
    }
}
