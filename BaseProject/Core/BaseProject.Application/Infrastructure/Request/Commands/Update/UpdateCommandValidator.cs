using FluentValidation;

namespace BaseProject.Application.Infrastructure.Request.Commands.Update
{
    public abstract class UpdateCommandValidator<TCommand> : UpdateCommandValidator<TCommand, int>
        where TCommand : UpdateCommand
    {
        public UpdateCommandValidator()
        {
            RuleFor(v => v.Id).NotNull();
        }
    }

    public abstract class UpdateCommandValidator<TCommand, TKey> : AbstractValidator<TCommand>
        where TCommand : UpdateCommand<TKey>
    {
        public UpdateCommandValidator()
        {
            RuleFor(v => v.Id).NotNull();
        }
    }
}
