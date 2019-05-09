namespace Whoever.Entities.Interfaces
{
    public interface ICurrentUser<TKey>
    {
        TKey Id { get; }

        string UserName { get; }

        bool IsAuthenticated { get; }
    }

}
