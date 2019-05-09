using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class RoleClaimConfiguration : BaseEntityTypeConfiguration<RoleClaim>
    {
        public override void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.RoleId);
        }
    }
}
