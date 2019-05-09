using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Whoever.Common.UniqueIdentifier;
using Whoever.Data.EntityFramework;
using Whoever.Entities.Interfaces;

namespace BaseProject.Persistence
{
    public partial class BaseProjectDbContext : DbContextBase<int, User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public BaseProjectDbContext(DbContextOptions options, ICurrentUser<int> currentUser)
            : base(options, SequentialGuidGenerator.Instance, currentUser)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(BaseProjectDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }


    }
}
