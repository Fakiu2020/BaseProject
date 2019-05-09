using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class BraintreeSubscriptionConfiguration : BaseEntityTypeConfiguration<BraintreeSubscription>
    {
        public override void Configure(EntityTypeBuilder<BraintreeSubscription> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.BraintreeId)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.PlanId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.BraintreeCustomerId)
                .IsRequired();

            builder.Property(x => x.CreditCardId)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.BraintreeCustomerId);

            builder
                .HasOne(x => x.CreditCard)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.CreditCardId);
        }
    }

}
