using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class KioskAccessConfiguration : BaseEntityTypeConfiguration<KioskAccess>
    {
        public override void Configure(EntityTypeBuilder<KioskAccess> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.KioskId)
                .IsRequired();

            builder.Property(x => x.GymMemberPlanId)
                .IsRequired();

            builder.Property(x => x.GymMemberId)
                .IsRequired();

            builder.Property(x => x.AccessDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Kiosk)
                .WithMany(x => x.KioskAccesses)
                .HasForeignKey(x => x.KioskId);

            builder
                .HasOne(x => x.GymMemberPlan)
                .WithMany(x => x.KioskAccesses)
                .HasForeignKey(x => x.GymMemberPlanId);

            builder
                .HasOne(x => x.GymMember)
                .WithMany(x => x.KioskAccesses)
                .HasForeignKey(x => x.GymMemberId);

            builder
                .HasOne(x => x.GymMemberChild)
                .WithMany(x => x.KioskAccesses)
                .HasForeignKey(x => x.GymMemberChildId);

        }
    }
}
