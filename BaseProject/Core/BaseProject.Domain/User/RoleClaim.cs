using Whoever.Entities;

namespace BaseProject.Domain
{
    public class RoleClaim : RoleClaimEntity<int>
    {
        public virtual Role Role { get; set; }
    }
}
