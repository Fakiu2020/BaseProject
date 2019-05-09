using Whoever.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Whoever.Data.EntityFramework.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void BuildIEntity<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IEntity
        {
            builder
                .HasKey(i => i.Id);
        }

        public static void BuildIEntity<TEntity, TKey>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IEntity<TKey>
        {
            builder
                .HasKey(i => i.Id);
        }

        public static void BuildISoftDelete<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, ISoftDelete
        {
            builder
                .Property(i => i.IsDeleted)
                .HasDefaultValue(false);
        }

        public static void BuildIHasCreationTime<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IHasCreationTime
        {
            builder
                .Property(i => i.CreationTime)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
