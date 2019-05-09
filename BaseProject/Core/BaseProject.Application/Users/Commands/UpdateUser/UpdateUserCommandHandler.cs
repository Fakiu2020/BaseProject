using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Application.Infrastructure.Request.Commands.Update;
using BaseProject.Application.Managers;
using BaseProject.Application.Users.Commands.UpdateUser;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;
using Whoever.Common.Exceptions;
using Whoever.Common.Extensions;

namespace BaseProject.Application.Users.Administrators.Commands.UpdateAdministrator
{
    public class UpdateUserCommandHandler :  IRequestHandler<UpdateUserCommand>
    {
        private readonly BaseProjectDbContext _context;
        private readonly UserManager _userManager;
        public UpdateUserCommandHandler( BaseProjectDbContext db , UserManager userManager)
        {
            _context = db;
            _userManager  =userManager;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            foreach (var item in request.Roles)
            {
                if (item.Checked)
                {
                   var result = await _userManager.AddToRoleAsync(entity, item.Name);
                }
                else
                {
                    var result = await _userManager.RemoveFromRoleAsync(entity, item.Name);
                }
                
               
            }

            entity.PhoneNumber = request.PhoneNumber;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.PhoneNumber = request.PhoneNumber;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

       
    }
}
