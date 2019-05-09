
using FluentValidation;
using BaseProject.Application.Infrastructure.Request.Commands.Update;
using BaseProject.Application.Users.Common;

namespace BaseProject.Application.Users.Administrators.Commands.UpdateAdministrator
{

    public class UpdateAdministratorCommandValidator : UpdateCommandValidator<UpdateAdministratorCommand>
    {
        public UpdateAdministratorCommandValidator() : base()
        {
            RuleFor(v => v.FirstName).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
        }
    }
}
