using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class BraintreeTransactionConfiguration : BaseEntityTypeConfiguration<BraintreeTransaction>
    {
        public override void Configure(EntityTypeBuilder<BraintreeTransaction> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.BraintreeId)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.BraintreeCustomerId)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.CreditCardId)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.BraintreeCustomerId);

            builder
                .HasOne(x => x.CreditCard)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.CreditCardId);

            builder
                .HasOne(x => x.Subscription)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.BraintreeSubscriptionId);

            builder
                .HasOne(x => x.RefundedTransaction)
                .WithMany(x => x.RefundedTransactions)
                .HasForeignKey(x => x.RefundedTransactionId);

            builder
                .HasOne(x => x.TransactionToMerchantAccount)
                .WithMany(x => x.TransactionsToMerchantAccount)
                .HasForeignKey(x => x.BraintreeTransactionToMerchantAccountId);

        }
    }

}
