using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class EmailNotificationBatchConfiguration : BaseEntityTypeConfiguration<EmailNotificationBatch>
    {
        public override void Configure(EntityTypeBuilder<EmailNotificationBatch> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Message)
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

        }
    }
}
