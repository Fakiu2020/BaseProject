using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class Group : Entity
    {
        public Group()
        {
            GroupGymMembers = new HashSet<GroupGymMember>();
        }
        
        public string Name { get; set; }
        public int NumberOfMembers { get; set; }
        public string Code { get; set; }

        public virtual GymMemberPlan GymMemberPlan { get; set; }
        public virtual ICollection<GroupGymMember> GroupGymMembers { get; private set; }
    }
}
