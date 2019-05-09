using BaseProject.Application.Infrastructure.Request.Queries.GetById;
using MediatR;

namespace BaseProject.Application.Users.Administrators.Queries.GetAdministratorDetailQuery
{
    public class GetAdministratorDetailQuery : GetByIdQuery<int>, IRequest<AdministratorDetailModel>
    {

    }
}
