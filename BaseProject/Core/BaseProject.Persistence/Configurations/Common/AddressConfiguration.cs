using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class AddressConfiguration : BaseEntityTypeConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Address1)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Address2)
                .HasMaxLength(200);

            builder.Property(x => x.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.StateId)
                .IsRequired();

            builder.Property(x => x.Zip)
                .HasMaxLength(10)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.State)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.StateId);

        }
    }

}
