using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymOwnerConfiguration : BaseEntityTypeConfiguration<GymOwner>
    {
        public override void Configure(EntityTypeBuilder<GymOwner> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.UseMasterMerchantAccount)
                .IsRequired()
                .HasDefaultValue(false);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.User);
                //.WithOne(x => x.GymOwner)
                //.HasForeignKey<GymOwner>(x => x.Id);
        }
    }
}
