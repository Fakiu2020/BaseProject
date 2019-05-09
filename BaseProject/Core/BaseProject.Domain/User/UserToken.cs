using Microsoft.AspNetCore.Identity;

namespace BaseProject.Domain
{
    public class UserToken : IdentityUserToken<int>
    {
        public virtual User User { get; set; }
    }
}
