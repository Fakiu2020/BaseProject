using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class StateConfiguration : BaseEntityTypeConfiguration<State>
    {
        public override void Configure(EntityTypeBuilder<State> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.Property(x => x.ABR)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.KioskLeasingSalesTaxPercentage)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
