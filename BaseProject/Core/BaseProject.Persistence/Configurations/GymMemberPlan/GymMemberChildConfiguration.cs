using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymMemberChildConfiguration : BaseEntityTypeConfiguration<GymMemberChild>
    {
        public override void Configure(EntityTypeBuilder<GymMemberChild> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

        }
    }
}
