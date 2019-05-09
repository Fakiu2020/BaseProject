using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class DeviceTokenConfiguration : BaseEntityTypeConfiguration<DeviceToken>
    {
        public override void Configure(EntityTypeBuilder<DeviceToken> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DeviceId)
                .IsRequired();

            builder.Property(x => x.Token)
                .IsRequired();

            builder.Property(x => x.Version)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Platform)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.DeviceToken)
                .HasForeignKey<DeviceToken>(x => x.Id);
        }
    }
}
