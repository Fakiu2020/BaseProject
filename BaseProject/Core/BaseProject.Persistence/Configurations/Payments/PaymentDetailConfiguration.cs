using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class PaymentDetailConfiguration : BaseEntityTypeConfiguration<PaymentDetail>
    {
        public override void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.PaymentId)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.PaymentTypeId)
                .IsRequired();

            builder.Ignore(x => x.PaymentType);


            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Payment)
                .WithMany(x => x.Details)
                .HasForeignKey(x => x.PaymentId);

            builder
                .HasOne(x => x.Transaction)
                .WithMany(x => x.Details)
                .HasForeignKey(x => x.BraintreeTransactionId);
        }
    }

}
