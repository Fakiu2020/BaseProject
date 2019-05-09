using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{
    public class Role : RoleEntity<int>
    {
        public Role()
        {
            Users = new HashSet<UserRole>();
            Claims = new HashSet<RoleClaim>();
        }

        public virtual ICollection<UserRole> Users { get; private set; }
        public virtual ICollection<RoleClaim> Claims { get; private set; }

    }
}
