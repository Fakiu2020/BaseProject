using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Application.Infrastructure.Request.Queries.GetById;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;

namespace BaseProject.Application.Users.Administrators.Queries.GetAdministratorDetailQuery
{
    public class GetAdministratorDetailQueryHandler : GetByIdQueryHandler<AdministratorDetailModel, Administrator>,
        IRequestHandler<GetAdministratorDetailQuery, AdministratorDetailModel>
    {
        public GetAdministratorDetailQueryHandler(BaseProjectDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public Task<AdministratorDetailModel> Handle(GetAdministratorDetailQuery request, CancellationToken cancellationToken)
        {
            return base.Handle(request, cancellationToken);
        }
    }
}
