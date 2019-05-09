using BaseProject.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace BaseProject.Persistence.Stores
{
    public partial class UserStore
    {

        /// <summary>
        /// Find a user token if it exists.
        /// </summary>
        /// <param name="user">The token owner.</param>
        /// <param name="loginProvider">The login provider for the token.</param>
        /// <param name="name">The name of the token.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The user token if it exists.</returns>
        protected override Task<UserToken> FindTokenAsync(User user, string loginProvider, string name,
            CancellationToken cancellationToken)
            => _db.UserTokens.FindAsync(user.Id, loginProvider, name);

        /// <summary>
        /// Add a new user token.
        /// </summary>
        /// <param name="token">The token to be added.</param>
        /// <returns></returns>
        protected override Task AddUserTokenAsync(UserToken token)
        {
            _db.UserTokens.Add(token);
            return SaveChanges(default(CancellationToken));
        }


        /// <summary>
        /// Remove a new user token.
        /// </summary>
        /// <param name="token">The token to be removed.</param>
        /// <returns></returns>
        protected override Task RemoveUserTokenAsync(UserToken token)
        {
            _db.UserTokens.Remove(token);
            return SaveChanges(default(CancellationToken));
        }



    }
}
