using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class GroupGymMember : Entity
    {
        public int GroupId { get; set; }
        public int? GymMemberId { get; set; }
        public int? GymMemberChildId { get; set; }
        public bool IsLeader { get; set; }

        public virtual GymMember GymMember { get; set; }
        public virtual GymMemberChild GymMemberChild { get; set; }
        public virtual Group Group { get; set; }
    }
}