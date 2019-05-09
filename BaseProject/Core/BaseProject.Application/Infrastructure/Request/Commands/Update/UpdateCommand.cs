namespace BaseProject.Application.Infrastructure.Request.Commands.Update
{
    public abstract class UpdateCommand : UpdateCommand<int>
    {
    }

    public abstract class UpdateCommand<TKey>
    {
        public TKey Id { get; set; }
    }
}
