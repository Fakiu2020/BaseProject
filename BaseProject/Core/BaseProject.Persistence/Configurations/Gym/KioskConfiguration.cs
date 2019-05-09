using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class KioskConfiguration : BaseEntityTypeConfiguration<Kiosk>
    {
        public override void Configure(EntityTypeBuilder<Kiosk> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.KioskIdentifier)
                .IsRequired()
                .HasDefaultValueSql("NEWID()");

            builder.Property(x => x.GymId)
                .IsRequired();

            builder.Property(x => x.VpnUsername)
                .HasMaxLength(200);

            builder.Property(x => x.VpnPassword)
                .HasMaxLength(200);

            builder.Property(x => x.VpnIpAddress)
                .HasMaxLength(200);

            builder.Property(x => x.Name)
                .HasMaxLength(200);

            builder.Property(x => x.IsBillingEnabled)
                .IsRequired()
                .HasDefaultValue(false);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Gym)
                .WithMany(x => x.Kiosks)
                .HasForeignKey(x => x.GymId);

        }
    }
}
