using FluentValidation;

namespace BaseProject.Application.Users.Common
{
    public abstract class CreateUserCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : CreateUserCommand
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().EmailAddress();
            RuleFor(v => v.ConfirmEmail).NotEmpty().EmailAddress().Equal(v => v.Email);
            RuleFor(v => v.Password).NotEmpty();
            RuleFor(v => v.ConfirmPassword).NotEmpty().Equal(v => v.Password);
        }
    }
}
