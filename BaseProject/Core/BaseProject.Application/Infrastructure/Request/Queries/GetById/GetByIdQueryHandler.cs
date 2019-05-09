using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Persistence;
using Microsoft.EntityFrameworkCore;
using Whoever.Common.Exceptions;
using Whoever.Entities.Interfaces;

namespace BaseProject.Application.Infrastructure.Request.Queries.GetById
{
    public abstract class GetByIdQueryHandler<TResult, TDomain> : GetByIdQueryHandler<TResult, TDomain, int>
        where TDomain : class, IEntity
    {
        protected GetByIdQueryHandler(BaseProjectDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }

    public abstract class GetByIdQueryHandler<TResult, TDomain, TKey>
        where TDomain : class, IEntity<TKey>
    {
        protected readonly BaseProjectDbContext Db;
        protected readonly IMapper Mapper;
        protected readonly DbSet<TDomain> Set;

        protected GetByIdQueryHandler(BaseProjectDbContext db, IMapper mapper)
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

        #endregion

        protected virtual async Task<TResult> Handle(GetByIdQuery<TKey> request, CancellationToken cancellationToken)
        {
            var entity = await FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(TDomain), request.Id);
            }

            return Mapper.Map<TResult>(entity);
        }
    }
}
