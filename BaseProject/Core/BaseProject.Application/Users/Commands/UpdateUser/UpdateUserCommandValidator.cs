
using FluentValidation;
using BaseProject.Application.Infrastructure.Request.Commands.Update;
using BaseProject.Application.Users.Commands.UpdateUser;

namespace BaseProject.Application.Users.Administrators.Commands.UpdateAdministrator
{

    public class UpdateUserCommandValidator : UpdateCommandValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            RuleFor(v => v.Email).NotEmpty();            
        }
    }
}
