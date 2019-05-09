using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class AdministratorConfiguration : BaseEntityTypeConfiguration<Administrator>
    {
        public override void Configure(EntityTypeBuilder<Administrator> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(200);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.User);
                //.WithOne(x => x.Administrator)
                //.HasForeignKey<Administrator>(x => x.Id);
        }
    }
}
