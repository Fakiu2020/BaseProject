using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class PaymentConfiguration : BaseEntityTypeConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.GymOwner)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.GymOwnerId);

            builder
                .HasOne(x => x.Kiosk)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.KioskId);

            builder
                .HasOne(x => x.GymMember)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.GymMemberId);

            builder
                .HasOne(x => x.GymMemberPlan)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.GymMemberPlanId);
        }
    }

}
