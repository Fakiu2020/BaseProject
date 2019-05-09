using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymOwnerEmailNotificationBatchConfiguration : BaseEntityTypeConfiguration<GymOwnerEmailNotificationBatch>
    {
        public override void Configure(EntityTypeBuilder<GymOwnerEmailNotificationBatch> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => new { x.GymOwnerId, x.EmailNotificationBatchId });

            builder.Property(x => x.GymOwnerId)
                .IsRequired();

            builder.Property(x => x.EmailNotificationBatchId)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.GymOwner)
                .WithMany(x => x.EmailNotificationBatches)
                .HasForeignKey(x => x.GymOwnerId);

            builder
                .HasOne(x => x.EmailNotificationBatch)
                .WithMany(x => x.GymOwners)
                .HasForeignKey(x => x.EmailNotificationBatchId);

        }
    }

}
