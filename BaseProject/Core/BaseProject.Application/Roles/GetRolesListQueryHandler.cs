using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseProject.Application.Common;
using BaseProject.Application.Infrastructure.Request.Queries.GetById;
using BaseProject.Application.Managers;
using BaseProject.Application.Roles;
using BaseProject.Application.Users.Queries.GetAllUsers;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Application.Users.Administrators.Queries.GetAdministratorDetailQuery
{
    public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, RolesLookupModel>
    {
        private readonly BaseProjectDbContext _context;
        private readonly IMapper _mapper;
        public GetRolesListQueryHandler(BaseProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RolesLookupModel> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
        
           return new RolesLookupModel {
               Roles = await _context.Roles.ProjectTo<RolesViewModel>(_mapper.ConfigurationProvider)
                                            .ToListAsync(cancellationToken)
           };
        }
    }
}