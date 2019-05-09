using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GroupGymMemberConfiguration : BaseEntityTypeConfiguration<GroupGymMember>
    {
        public override void Configure(EntityTypeBuilder<GroupGymMember> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.GroupId)
                .IsRequired();

            builder.Property(x => x.IsLeader)
                .IsRequired()
                .HasDefaultValue(false);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.GroupGymMembers)
                .HasForeignKey(x => x.GroupId);

            builder
                .HasOne(x => x.GymMember)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.GymMemberId);

            builder
                .HasOne(x => x.GymMemberChild)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.GymMemberChildId);

        }
    }
}
