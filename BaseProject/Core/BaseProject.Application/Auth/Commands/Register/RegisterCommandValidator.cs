using FluentValidation;

namespace BaseProject.Application.Auth.Commands.Login
{

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {            
            RuleFor(v => v.Password).NotEmpty();
            RuleFor(v => v.ConfirmPassword).NotEmpty().Equal(x=>x.Password);
            RuleFor(v => v.FirstName).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
        }
    }
}
