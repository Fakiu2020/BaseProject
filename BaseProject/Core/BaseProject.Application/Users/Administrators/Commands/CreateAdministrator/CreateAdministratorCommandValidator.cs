
using FluentValidation;
using BaseProject.Application.Users.Common;

namespace BaseProject.Application.Users.Administrators.Commands.CreateAdministrator
{

    public class CreateAdministratorCommandValidator : CreateUserCommandValidator<CreateAdministratorCommand>
    {
        public CreateAdministratorCommandValidator() : base()
        {
            RuleFor(v => v.FirstName).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
        }
    }
}
