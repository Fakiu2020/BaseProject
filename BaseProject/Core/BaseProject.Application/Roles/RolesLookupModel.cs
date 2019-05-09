using System.Collections.Generic;
using BaseProject.Application.Roles;
using BaseProject.Domain;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Roles
{
    public class RolesLookupModel
    {
        public IList<RolesViewModel> Roles { get; set; }
    }
}
