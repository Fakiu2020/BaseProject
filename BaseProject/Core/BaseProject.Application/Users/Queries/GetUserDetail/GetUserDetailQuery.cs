using BaseProject.Application.Infrastructure.Request.Queries.GetById;
using MediatR;

namespace BaseProject.Application.Users.Queries.GetAllUsers
{
    public class GetUserDetailQuery : GetByIdQuery<int>, IRequest<UserDetailModel>
    {
       
    }
}
