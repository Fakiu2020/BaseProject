using Whoever.Entities;

namespace BaseProject.Domain
{
    public class UserClaim : UserClaimEntity<int>
    {
        public virtual User User { get; set; }
    }
}
