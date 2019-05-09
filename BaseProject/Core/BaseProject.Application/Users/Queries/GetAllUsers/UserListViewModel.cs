using System.Collections.Generic;
using BaseProject.Application.Common;
using BaseProject.Domain;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Users.Queries.GetAllUsers
{
    public class UserListViewModel:FilterBase
    {
        
        public List<UserLookupModel> Users { get; set; }
    }
}
