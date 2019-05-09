using BaseProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Whoever.Common.Exceptions;
using Whoever.Entities.Interfaces;

namespace BaseProject.Application.Infrastructure.Request.Commands.Delete
{
    public abstract class DeleteCommandHandler<TDomain> : DeleteCommandHandler<TDomain, int>
        where TDomain : class, IEntity
    {
        protected DeleteCommandHandler(BaseProjectDbContext db) : base(db)
        {
        }
    }

    public abstract class DeleteCommandHandler<TDomain, TKey>
        where TDomain : class, IEntity<TKey>
    {
        protected readonly BaseProjectDbContext Db;
        protected readonly DbSet<TDomain> Set;

        protected DeleteCommandHandler(BaseProjectDbContext db)
        {
            Db = db;
            Set = db.Set<TDomain>();
        }

        #region Common Actions

        protected virtual Task<TDomain> FindAsync(TKey key)
        {
            return Set.FindAsync(key);
        }

        protected virtual void Remove(TDomain entity)
        {
            Set.Remove(entity);
        }

        #endregion

        #region SaveChanges Events

        protected virtual Task BeforeSaveChangesAsync(TDomain entity)
        {
            return Task.CompletedTask;
        }

        protected virtual void BeforeSaveChanges(TDomain entity)
        {
        }

        protected virtual Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Db.SaveChangesAsync(cancellationToken);
        }

        protected virtual void PostSaveChanges(TDomain entity)
        {
        }

        protected virtual Task PostSaveChangesAsync(TDomain entity)
        {
            return Task.CompletedTask;
        }

        #endregion

        protected virtual Task<bool> CanDeleteAsync(TDomain entity)
        {
            return Task.FromResult(true);
        }

        protected virtual void CheckIfDelete(TDomain entity)
        {
            
        }

        protected virtual async Task<Unit> Handle(DeleteCommand<TKey> request, CancellationToken cancellationToken)
        {
            var entity = await FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(TDomain), request.Id);
            }

            CheckIfDelete(entity);
            Remove(entity);

            // BEFORE
            BeforeSaveChanges(entity);
            await BeforeSaveChangesAsync(entity);

            // SAVE
            await SaveChangesAsync(cancellationToken);

            // POST
            PostSaveChanges(entity);
            await PostSaveChangesAsync(entity);

            return Unit.Value;
        }
    }
}
