using System.Collections.Generic;
using BaseProject.Application.Common;
using BaseProject.Application.Infrastructure.Request.Queries.GetById;
using BaseProject.Domain;
using MediatR;

namespace BaseProject.Application.Users.Queries.GetAllUsers
{
    public class GetUserListQuery : FilterBase, IRequest<UserListViewModel>
    {
        public string Email { get; set; }
    }
}
