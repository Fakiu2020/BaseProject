using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class KioskFingerPrintConfiguration : BaseEntityTypeConfiguration<KioskFingerPrint>
    {
        public override void Configure(EntityTypeBuilder<KioskFingerPrint> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.KioskId)
                .IsRequired();

            builder.Property(x => x.FingerPrintXml)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Kiosk)
                .WithMany(x => x.KioskFingerPrints)
                .HasForeignKey(x => x.KioskId);

        }
    }
}
