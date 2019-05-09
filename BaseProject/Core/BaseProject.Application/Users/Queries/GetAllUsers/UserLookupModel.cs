using System.Collections.Generic;
using BaseProject.Domain;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Users.Queries.GetAllUsers
{
    public class UserLookupModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public virtual ICollection<UserRole> Roles { get; private set; }
    }
}
