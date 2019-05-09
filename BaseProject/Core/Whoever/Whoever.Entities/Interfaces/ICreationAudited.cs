namespace Whoever.Entities.Interfaces
{
    /// <summary>
    /// This interface is implemented by entities that is wanted to store creation information (who and when created).
    /// Creation time and creator user are automatically set when saving <see cref="Entity"/> to database.
    /// </summary>
    public interface ICreationAudited<TUserKey> : IHasCreationTime 
        where TUserKey : struct
    {
        /// <summary>
        /// Id of the creator user of this entity.
        /// </summary>
        TUserKey? CreatorUserId { get; set; }
    }

    /// <summary>
    /// Adds navigation properties to <see cref="ICreationAudited"/> interface for user.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface ICreationAudited<TUser, TUserKey> : ICreationAudited<TUserKey>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {
        /// <summary>
        /// Reference to the creator user of this entity.
        /// </summary>
        TUser CreatorUser { get; set; }
    }
}
