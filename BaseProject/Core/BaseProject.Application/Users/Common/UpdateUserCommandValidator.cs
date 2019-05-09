using FluentValidation;
using BaseProject.Application.Infrastructure.Request.Commands.Update;

namespace BaseProject.Application.Users.Common
{
    public abstract class UpdateUserCommandValidator<TCommand> : UpdateCommandValidator<TCommand>
        where TCommand : UpdateUserCommand
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Email).NotEmpty().EmailAddress();
        }
    }
}
