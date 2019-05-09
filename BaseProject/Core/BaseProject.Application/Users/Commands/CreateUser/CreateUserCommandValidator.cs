using BaseProject.Application.Users.CreateUser;
using FluentValidation;

namespace BaseProject.Application.Users
{
    public abstract class CreateUserCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : CreateUserCommand
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().EmailAddress();
            RuleFor(v => v.ConfirmEmail).Equal(v => v.Email);
            RuleFor(v => v.Password).NotEmpty();
            RuleFor(v => v.ConfirmPassword).Equal(v => v.Password);
        }
    }
}
