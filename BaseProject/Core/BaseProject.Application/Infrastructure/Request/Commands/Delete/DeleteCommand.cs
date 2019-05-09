namespace BaseProject.Application.Infrastructure.Request.Commands.Delete
{
    public abstract class DeleteCommand : DeleteCommand<int>
    {
    }

    public abstract class DeleteCommand<TKey>
    {
        public TKey Id { get; set; }
    }
}
