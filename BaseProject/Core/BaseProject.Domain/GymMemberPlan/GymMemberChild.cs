using System;
using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class GymMemberChild : Entity
    {
        public GymMemberChild()
        {
            KioskAccesses = new HashSet<KioskAccess>();
            Groups = new HashSet<GroupGymMember>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<KioskAccess> KioskAccesses { get; private set; }
        public virtual ICollection<GroupGymMember> Groups { get; private set; }
    }
}
