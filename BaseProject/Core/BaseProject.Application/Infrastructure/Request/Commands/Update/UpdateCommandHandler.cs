using AutoMapper;
using BaseProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Whoever.Common.Exceptions;
using Whoever.Entities.Interfaces;

namespace BaseProject.Application.Infrastructure.Request.Commands.Update
{
    public abstract class UpdateCommandHandler<TDomain> : UpdateCommandHandler<TDomain, int>
        where TDomain : class, IEntity
    {
        protected UpdateCommandHandler(BaseProjectDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }

    public abstract class UpdateCommandHandler<TDomain, TKey>
        where TDomain : class, IEntity<TKey>
    {
        protected readonly BaseProjectDbContext Db;
        protected readonly IMapper Mapper;
        protected readonly DbSet<TDomain> Set;

        protected UpdateCommandHandler(BaseProjectDbContext db, IMapper mapper)
        {
            Db = db;
            Mapper = mapper;
            Set = db.Set<TDomain>();
        }

        #region Common Actions

        protected virtual Task<TDomain> FindAsync(TKey key)
        {
            return Set.FindAsync(key);
        }

        protected abstract void UpdateValues(TDomain newValues, TDomain original);

        protected virtual void Update(TDomain original)
        {
            Set.Update(original);
        }

        #endregion

        #region SaveChanges Events

        protected virtual Task BeforeSaveChangesAsync(TDomain newValues, TDomain original)
        {
            return Task.CompletedTask;
        }

        protected virtual void BeforeSaveChanges(TDomain newValues, TDomain original)
        {
        }

        protected virtual Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Db.SaveChangesAsync(cancellationToken);
        }

        protected virtual void PostSaveChanges(TDomain newValues, TDomain original)
        {
        }

        protected virtual Task PostSaveChangesAsync(TDomain newValues, TDomain original)
        {
            return Task.CompletedTask;
        }

        #endregion

        protected virtual Task<bool> CanUpdateAsync(TDomain newValues, TDomain original)
        {
            return Task.FromResult(true);
        }

        protected virtual void CheckIfUpdate(TDomain newValues, TDomain original)
        {
            
        }

        protected virtual async Task<Unit> Handle(UpdateCommand<TKey> request, CancellationToken cancellationToken)
        {
            var original = await FindAsync(request.Id);
            if (original == null)
            {
                throw new NotFoundException(nameof(TDomain), request.Id);
            }
            var newValues = Mapper.Map<TDomain>(request);

            CheckIfUpdate(newValues, original);
            UpdateValues(newValues, original);
            Update(original);

            // BEFORE
            BeforeSaveChanges(newValues, original);
            await BeforeSaveChangesAsync(newValues, original);

            // SAVE
            await SaveChangesAsync(cancellationToken);

            // POST
            PostSaveChanges(newValues, original);
            await PostSaveChangesAsync(newValues, original);

            return Unit.Value;
        }
    }
}
