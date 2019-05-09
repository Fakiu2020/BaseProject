using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Whoever.Common.Extensions;
using Whoever.Common.Helpers;
using Whoever.Common.Interfaces;
using Whoever.Data.EntityFramework.Extensions;
using Whoever.Entities.Helpers;
using Whoever.Entities.Interfaces;

namespace Whoever.Data.EntityFramework
{
    /// <summary>
    /// Base class for all DbContext classes in the application.
    /// </summary>
    public abstract class DbContextBase<TUserKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        : IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        where TUserKey : struct
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        /// <summary>
        /// Reference to GUID generator.
        /// </summary>
        public IGuidGenerator GuidGenerator { get; set; }

        public ICurrentUser<TUserKey> CurrentUser { get; set; }

        private static readonly MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(DbContextBase<TUserKey, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

        /// <summary>
        /// Constructor.
        /// </summary>
        protected DbContextBase(DbContextOptions options, IGuidGenerator guidGenerator, ICurrentUser<TUserKey> currentUser)
            : base(options)
        {
            InitializeDbContext(guidGenerator, currentUser);
        }

        private void InitializeDbContext(IGuidGenerator guidGenerator, ICurrentUser<TUserKey> currentUser)
        {
            GuidGenerator = guidGenerator;
            CurrentUser = currentUser;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.RemovePluralizingTableNameConvention();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFiltersMethodInfo
                    .MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] { modelBuilder, entityType });
            }

            List<IMutableEntityType> identiyEntities = new List<IMutableEntityType>
            {
                modelBuilder.Model.FindEntityType(typeof(TUser)),
                modelBuilder.Model.FindEntityType(typeof(TRole)),
                modelBuilder.Model.FindEntityType(typeof(TUserRole)),
                modelBuilder.Model.FindEntityType(typeof(TUserClaim)),
                modelBuilder.Model.FindEntityType(typeof(TUserLogin)),
                modelBuilder.Model.FindEntityType(typeof(TUserToken)),
                modelBuilder.Model.FindEntityType(typeof(TRoleClaim)),
            };
            var entities = modelBuilder
                .Model
                .GetEntityTypes()
                .Except(identiyEntities)
                .Where(e => !e.IsOwned())
                .SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in entities)
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType)
            where TEntity : class
        {
            if (entityType.BaseType == null && ShouldFilterEntity<TEntity>(entityType))
            {
                var filterExpression = CreateFilterExpression<TEntity>();
                if (filterExpression != null)
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
            }
        }

        protected virtual bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType) where TEntity : class
        {
            return typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity));
        }

        protected virtual Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expression1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expression1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expression2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expression2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
            where TEntity : class
        {
            Expression<Func<TEntity, bool>> expression = null;

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                /* This condition should normally be defined as below:
                 * !IsSoftDeleteFilterEnabled || !((ISoftDelete) e).IsDeleted
                 * But this causes a problem with EF Core (see https://github.com/aspnet/EntityFrameworkCore/issues/9502)
                 * So, we made a workaround to make it working. It works same as above.
                 */

                Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDelete)e).IsDeleted;
                expression = expression == null ? softDeleteFilter : CombineExpressions(expression, softDeleteFilter);
            }

            return expression;
        }

        public override int SaveChanges()
        {
            try
            {
                ApplyConcepts();
                var result = base.SaveChanges();
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.ReThrow();
                return 0;
                // TODO: Strategy for ConcurrencyExceptions
                //throw new AbpDbConcurrencyException(ex.Message, ex);
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                ApplyConcepts();
                var result = await base.SaveChangesAsync(cancellationToken);
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.ReThrow();
                return 0;
                // TODO: Strategy for ConcurrencyExceptions
                //throw new AbpDbConcurrencyException(ex.Message, ex);
            }
        }

        protected virtual void ApplyConcepts()
        {
            var userId = GetAuditUserId();

            var entries = ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ApplyConceptsForAddedEntity(entry, userId);
                        break;
                    case EntityState.Modified:
                        ApplyConceptsForModifiedEntity(entry, userId);
                        break;
                    case EntityState.Deleted:
                        ApplyConceptsForDeletedEntity(entry, userId);
                        break;
                }
            }
        }

        protected virtual TUserKey? GetAuditUserId()
        {
            if (CurrentUser == null || !CurrentUser.IsAuthenticated)
                return null;
            return CurrentUser.Id;
        }

        protected virtual void ApplyConceptsForAddedEntity(EntityEntry entry, TUserKey? userId)
        {
            CheckAndSetId(entry);
            SetCreationAuditProperties(entry.Entity, userId);
        }

        protected virtual void ApplyConceptsForModifiedEntity(EntityEntry entry, TUserKey? userId)
        {
            SetModificationAuditProperties(entry.Entity, userId);
            if (entry.Entity is ISoftDelete && entry.Entity.As<ISoftDelete>().IsDeleted)
            {
                SetDeletionAuditProperties(entry.Entity, userId);
            }
        }

        protected virtual void ApplyConceptsForDeletedEntity(EntityEntry entry, TUserKey? userId)
        {
            CancelDeletionForSoftDelete(entry);
            SetDeletionAuditProperties(entry.Entity, userId);
        }

        protected virtual void CheckAndSetId(EntityEntry entry)
        {
            //Set GUID Ids
            var entity = entry.Entity as IEntity<Guid>;
            if (entity != null && entity.Id == Guid.Empty)
            {
                var dbGeneratedAttr = ReflectionHelper
                    .GetSingleAttributeOrDefault<DatabaseGeneratedAttribute>(
                        entry.Property("Id").Metadata.PropertyInfo
                    );

                if (dbGeneratedAttr == null || dbGeneratedAttr.DatabaseGeneratedOption == DatabaseGeneratedOption.None)
                {
                    entity.Id = GuidGenerator.Create();
                }
            }
        }

        public virtual TransactionScope BeginTransaction()
        {
            return DbHelper.CreateTransactionScope();
        }

        protected virtual void SetCreationAuditProperties(object entityAsObj, TUserKey? userId)
        {
            EntityAuditingHelper.SetCreationAuditProperties(entityAsObj, userId);
        }

        protected virtual void SetModificationAuditProperties(object entityAsObj, TUserKey? userId)
        {
            EntityAuditingHelper.SetModificationAuditProperties(entityAsObj, userId);
        }

        protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
        {
            if (!(entry.Entity is ISoftDelete))
            {
                return;
            }

            entry.Reload();
            entry.State = EntityState.Modified;
            entry.Entity.As<ISoftDelete>().IsDeleted = true;
        }

        protected virtual void SetDeletionAuditProperties(object entityAsObj, TUserKey? userId)
        {
            EntityAuditingHelper.SetDeletionAuditProperties(entityAsObj, userId);
        }

    }
}
