using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymMonitorConfiguration : BaseEntityTypeConfiguration<GymMonitor>
    {
        public override void Configure(EntityTypeBuilder<GymMonitor> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.GymOwnerId)
               .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.User);
                //.WithOne(x => x.GymMonitor)
                //.HasForeignKey<GymMonitor>(x => x.Id);

            builder
                .HasOne(x => x.GymOwner)
                .WithMany(x => x.Monitors)
                .HasForeignKey(x => x.GymOwnerId);
        }
    }
}
