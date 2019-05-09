namespace Whoever.Entities.Interfaces
{
    /// <summary>
    /// This interface is implemented by entities which wanted to store deletion information (who and when deleted).
    /// </summary>
    public interface IDeletionAudited<TKey> : IHasDeletionTime 
        where TKey : struct
    {
        /// <summary>
        /// Which user deleted this entity?
        /// </summary>
        TKey? DeleterUserId { get; set; }
    }

    /// <summary>
    /// Adds navigation properties to <see cref="IDeletionAudited"/> interface for user.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IDeletionAudited<TUser, TKey> : IDeletionAudited<TKey>
        where TUser : IEntity<TKey>
        where TKey : struct
    {
        /// <summary>
        /// Reference to the deleter user of this entity.
        /// </summary>
        TUser DeleterUser { get; set; }
    }
}
