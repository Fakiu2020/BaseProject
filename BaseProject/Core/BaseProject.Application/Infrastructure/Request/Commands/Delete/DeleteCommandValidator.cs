using FluentValidation;

namespace BaseProject.Application.Infrastructure.Request.Commands.Delete
{
    public abstract class DeleteCommandValidator<TCommand> : DeleteCommandValidator<TCommand, int>
        where TCommand : DeleteCommand
    {
        public DeleteCommandValidator()
        {
            RuleFor(v => v.Id).NotNull();
        }
    }

    public abstract class DeleteCommandValidator<TCommand, TKey> : AbstractValidator<TCommand>
        where TCommand : DeleteCommand<TKey>
    {
        public DeleteCommandValidator()
        {
            RuleFor(v => v.Id).NotNull();
        }
    }
}
