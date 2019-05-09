using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class SettingConfiguration : BaseEntityTypeConfiguration<Setting>
    {
        public override void Configure(EntityTypeBuilder<Setting> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.KioskLicensingFeePerMonth)
                .IsRequired();

            builder.Property(x => x.KioskLeasingFeePerMonth)
                .IsRequired();

            builder.Property(x => x.AnnualMaintenanceFeeMessage)
                .HasMaxLength(300);

            builder.Property(x => x.SignupSubcriptionMessage)
                .HasMaxLength(300);

        }
    }
}
