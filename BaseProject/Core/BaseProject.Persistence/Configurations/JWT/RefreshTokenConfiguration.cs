using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class RefreshTokenConfiguration : BaseEntityTypeConfiguration<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ApplicationClientId)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.IssuedUtc)
                .IsRequired();

            builder.Property(x => x.ExpiresUtc)
                .IsRequired();

            builder.Property(x => x.ProtectedTicket)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            //builder
                //.HasOne(x => x.ApplicationClient)
                //.WithMany(x => x.RefreshTokens)
                //.HasForeignKey(x => x.ApplicationClientId);
        }
    }

}
