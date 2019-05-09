using FluentValidation;

namespace BaseProject.Application.Auth.Commands.Login
{

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty();
            RuleFor(v => v.Password).NotEmpty();
        }
    }
}
