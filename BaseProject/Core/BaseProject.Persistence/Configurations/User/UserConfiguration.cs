using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{

    public class UserConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => new { u.NormalizedUserName, u.DeactivatedDate })
                .HasName("IX_User_NormalizedUserName")
                .IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("IX_User_NormalizedEmail");
        }
    }
}
