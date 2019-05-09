using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class ApplicationClientConfiguration : BaseEntityTypeConfiguration<ApplicationClient>
    {
        public override void Configure(EntityTypeBuilder<ApplicationClient> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasMaxLength(128);

            builder.Property(x => x.Secret)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ApplicationType)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.RefreshTokenLifeTime)
                .IsRequired();

            builder.Property(x => x.AllowedOrigin)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
