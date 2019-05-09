namespace Whoever.Entities.Interfaces
{
    /// <summary>
    /// This interface ads <see cref="IDeletionAudited"/> to <see cref="IAudited"/> for a fully audited entity.
    /// </summary>
    public interface IFullAudited<TKey> : IAudited<TKey>, IDeletionAudited<TKey>
        where TKey : struct
    {

    }

    /// <summary>
    /// Adds navigation properties to <see cref="IFullAudited"/> interface for user.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IFullAudited<TUser, TKey> : IAudited<TUser, TKey>, IFullAudited<TKey>, IDeletionAudited<TUser, TKey>
        where TUser : IEntity<TKey>
        where TKey : struct
    {

    }
}
