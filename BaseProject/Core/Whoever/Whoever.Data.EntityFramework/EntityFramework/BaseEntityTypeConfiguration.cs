using System;
using Whoever.Entities.Interfaces;
using Whoever.Data.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Whoever.Data.EntityFramework
{
    public class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            (builder as EntityTypeBuilder<IEntity>)?.BuildIEntity();
            (builder as EntityTypeBuilder<IEntity<byte>>)?.BuildIEntity<IEntity<byte>, byte>();
            (builder as EntityTypeBuilder<IEntity<short>>)?.BuildIEntity<IEntity<short>, short>();
            (builder as EntityTypeBuilder<IEntity<int>>)?.BuildIEntity<IEntity<int>, int>();
            (builder as EntityTypeBuilder<IEntity<long>>)?.BuildIEntity<IEntity<long>, long>();
            (builder as EntityTypeBuilder<IEntity<string>>)?.BuildIEntity<IEntity<string>, string>();
            (builder as EntityTypeBuilder<IEntity<Guid>>)?.BuildIEntity<IEntity<Guid>, Guid>();
            (builder as EntityTypeBuilder<ISoftDelete>)?.BuildISoftDelete();
            (builder as EntityTypeBuilder<IHasCreationTime>)?.BuildIHasCreationTime();
        }
    }
}