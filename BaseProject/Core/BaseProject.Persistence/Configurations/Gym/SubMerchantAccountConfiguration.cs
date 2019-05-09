using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class SubMerchantAccountConfiguration : BaseEntityTypeConfiguration<SubMerchantAccount>
    {
        public override void Configure(EntityTypeBuilder<SubMerchantAccount> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.SubMerchantAccountStatusId)
                .IsRequired();

            builder.Ignore(x => x.SubMerchantAccountStatus);

        }
    }
}
