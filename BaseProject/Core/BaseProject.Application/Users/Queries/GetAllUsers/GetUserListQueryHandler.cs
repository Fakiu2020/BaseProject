using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseProject.Application.Common;
using BaseProject.Application.Infrastructure.Request.Queries.GetById;
using BaseProject.Application.Managers;
using BaseProject.Application.Users.Queries.GetAllUsers;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Application.Users.Administrators.Queries.GetAdministratorDetailQuery
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListViewModel>
    {
        private readonly BaseProjectDbContext _context;
        private readonly IMapper _mapper;
        public GetUserListQueryHandler(BaseProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserListViewModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = _context.CurrentUser.Id;
            
            var data = _context.Users
                                      .OrderByDescending(x => x.CreationTime)
                                      .Where(x => !x.IsDeleted && x.Id!=currentUserId &&
                                                         (string.IsNullOrEmpty(request.Email) || x.Email.Contains(request.Email)))
                                      .AsQueryable().ProjectTo<UserLookupModel>(_mapper.ConfigurationProvider);
           var pageList = await PagedList<UserLookupModel>.CreateAsync(data, request.PageNumber, request.PageSize);
            
            return new UserListViewModel {
                PageNumber=pageList.CurrentPage,
                PageSize=pageList.PageSize,
                PageTotal=pageList.TotalPages,
                TotalRecords=pageList.TotalCount,
                Users = pageList.Entities
            };

        }
    }
}