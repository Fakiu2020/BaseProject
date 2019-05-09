using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class BraintreeSubscriptionEventConfiguration : BaseEntityTypeConfiguration<BraintreeSubscriptionEvent>
    {
        public override void Configure(EntityTypeBuilder<BraintreeSubscriptionEvent> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.BraintreeSubscriptionId)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Subscription)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.BraintreeSubscriptionId);
        }
    }
}
