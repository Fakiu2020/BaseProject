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
using BaseProject.Application.Managers;

namespace BaseProject.Application.Users.Queries.GetAllUsers
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailModel>
    {
        private readonly BaseProjectDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager _userMananger;

        public GetUserDetailQueryHandler(BaseProjectDbContext db, IMapper mapper, UserManager user)
        {
            _context = db;
            _mapper=mapper;
            _userMananger = user;
        }

        public async Task<UserDetailModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {

            //var user = await (from userResult in _context.Users
            //                   where userResult.Id == request.Id
            //                   select new
            //                   {
            //                       Id = userResult.Id,
            //                       Email = userResult.Email,
            //                       FirstName = userResult.FirstName,
            //                       LastName = userResult.LastName,
            //                       PhoneNumber=userResult.PhoneNumber,
            //                       Roles = (from userRole in userResult.Roles
            //                                join role in _context.Roles
            //                                on userRole.RoleId equals role.Id
            //                                select new { role.Name, role.Id }).ToList()
            //                   }).FirstOrDefaultAsync();

            var user = await _context.Users.FindAsync(request.Id);            
            if (user == null)      
                throw new NotFoundException(nameof(User), request.Id);

            var roles = await _userMananger.GetRolesAsync(user);

            return new UserDetailModel {
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                Id= user.Id,
                Roles = roles.ToList()
            };

        }
    }
}
