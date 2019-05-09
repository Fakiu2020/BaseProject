using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymMemberPlanConfiguration : BaseEntityTypeConfiguration<GymMemberPlan>
    {
        public override void Configure(EntityTypeBuilder<GymMemberPlan> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.GymMemberId)
                .IsRequired();

            builder.Property(x => x.GymPlanId)
               .IsRequired();

            builder.Property(x => x.CreditCardId)
              .IsRequired();

            builder.Property(x => x.PurchaseDate)
               .IsRequired();

            builder.Property(x => x.StatusId)
               .IsRequired();

            builder.Ignore(x => x.Status);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.EnrollmentFee)
                .WithMany(x => x.GymMemberPlans)
                .HasForeignKey(x => x.EnrollmentFeeId);

            builder
                .HasOne(x => x.PriceRange)
                .WithMany(x => x.GymMemberPlans)
                .HasForeignKey(x => x.PriceRangeId);

            builder
                .HasOne(x => x.CreditCard)
                .WithMany(x => x.GymMemberPlans)
                .HasForeignKey(x => x.CreditCardId);

            builder
                .HasOne(x => x.GymMember)
                .WithMany(x => x.GymMemberPlans)
                .HasForeignKey(x => x.GymMemberId);

            builder
                .HasOne(x => x.GymPlan)
                .WithMany(x => x.GymMemberPlans)
                .HasForeignKey(x => x.GymPlanId);

        }
    }
}
