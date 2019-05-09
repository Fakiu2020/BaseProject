using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Application.Infrastructure.Request.Queries.GetById;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Whoever.Common.Exceptions;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BaseProject.Application.Roles;

namespace BaseProject.Application.Users.Queries.GetAllUsers
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailModel>
    {
        private readonly BaseProjectDbContext _context;
        private readonly IMapper _mapper;
        public GetUserDetailQueryHandler(BaseProjectDbContext db, IMapper mapper)
        {
            _context = db;
            _mapper=mapper;
        }

        public async Task<UserDetailModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {

            var user = await (from userResult in _context.Users
                               where userResult.Id == request.Id
                               select new
                               {
                                   Id = userResult.Id,
                                   Email = userResult.Email,
                                   FirstName = userResult.FirstName,
                                   LastName = userResult.LastName,
                                   PhoneNumber=userResult.PhoneNumber,
                                   Roles = (from userRole in userResult.Roles
                                            join role in _context.Roles
                                            on userRole.RoleId equals role.Id
                                            select new { role.Name, role.Id }).ToList()
                               }).FirstOrDefaultAsync();


            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }


            return new UserDetailModel {
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                Roles = user.Roles.AsQueryable().ProjectTo<RolViewModel>(_mapper.ConfigurationProvider).ToList()                                    
        };

        }
    }
}
