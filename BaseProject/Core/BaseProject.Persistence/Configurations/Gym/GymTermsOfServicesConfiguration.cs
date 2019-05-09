using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymTermsOfServicesConfiguration : BaseEntityTypeConfiguration<GymTermsOfServices>
    {
        public override void Configure(EntityTypeBuilder<GymTermsOfServices> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.ValidFrom)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.GymId)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Gym)
                .WithMany(x => x.GymTermsOfServices)
                .HasForeignKey(x => x.GymId);
        }
    }
}
