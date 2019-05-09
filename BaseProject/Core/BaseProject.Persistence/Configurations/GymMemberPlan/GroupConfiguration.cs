using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GroupConfiguration : BaseEntityTypeConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.NumberOfMembers)
                .IsRequired();

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(200);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.GymMemberPlan)
                .WithOne(x => x.Group)
                .HasForeignKey<Group>(x => x.Id);
        }
    }
}
