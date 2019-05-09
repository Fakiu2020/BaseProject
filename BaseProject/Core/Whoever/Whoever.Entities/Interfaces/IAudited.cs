namespace Whoever.Entities.Interfaces
{
    /// <summary>
    /// This interface is implemented by entities which must be audited.
    /// Related properties automatically set when saving/updating <see cref="Entity"/> objects.
    /// </summary>
    public interface IAudited<TKey> : ICreationAudited<TKey>, IModificationAudited<TKey>
        where TKey : struct
    {

    }

    /// <summary>
    /// Adds navigation properties to <see cref="IAudited"/> interface for user.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IAudited<TUser, TKey> : IAudited<TKey>, ICreationAudited<TUser, TKey>, IModificationAudited<TUser, TKey>
        where TUser : IEntity<TKey>
        where TKey : struct
    {

    }
}
