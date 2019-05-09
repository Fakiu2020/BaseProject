using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymConfiguration : BaseEntityTypeConfiguration<Gym>
    {
        public override void Configure(EntityTypeBuilder<Gym> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.AddressId)
                .IsRequired();

            builder.Property(x => x.GymOwnerId)
                .IsRequired();

            builder.Property(x => x.Website)
                .HasMaxLength(200);

            builder.Property(x => x.AllowMobileFingerPrints)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(200);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.Gyms)
                .HasForeignKey(x => x.AddressId);

            builder
                .HasOne(x => x.GymOwner)
                .WithMany(x => x.Gyms)
                .HasForeignKey(x => x.GymOwnerId);

        }
    }
}
