using System;
using System.Linq;
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
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            var userRoles =await _userManager.GetRolesAsync(user);       
            var selectedRoles = request.Roles ?? new string[]{};
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
            if (!result.Succeeded)
                throw new ValidationException(result.ToValidationFailureList());

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
            if (!result.Succeeded)
                throw new ValidationException(result.ToValidationFailureList());

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

       
    }
}
