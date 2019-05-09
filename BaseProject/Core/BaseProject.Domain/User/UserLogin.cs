using Microsoft.AspNetCore.Identity;

namespace BaseProject.Domain
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public virtual User User { get; set; }
    }
}
