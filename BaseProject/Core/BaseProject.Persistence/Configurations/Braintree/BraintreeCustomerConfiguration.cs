using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class BraintreeCustomerConfiguration : BaseEntityTypeConfiguration<BraintreeCustomer>
    {
        public override void Configure(EntityTypeBuilder<BraintreeCustomer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.BraintreeId)
                .IsRequired()
                .HasMaxLength(30);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.User);
                //.WithOne(x => x.BraintreeCustomer)
               // .HasForeignKey<BraintreeCustomer>(x => x.Id);
        }
    }
}
