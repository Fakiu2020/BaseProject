using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class FingerPrintConfiguration : BaseEntityTypeConfiguration<FingerPrint>
    {
        public override void Configure(EntityTypeBuilder<FingerPrint> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FingerPrintXml)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.User);
                //.WithOne(x => x.FingerPrint)
                //.HasForeignKey<FingerPrint>(x => x.Id);
        }
    }
}
