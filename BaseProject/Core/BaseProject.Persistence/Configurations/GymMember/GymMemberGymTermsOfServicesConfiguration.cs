using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymMemberGymTermsOfServicesConfiguration : BaseEntityTypeConfiguration<GymMemberGymTermsOfServices>
    {
        public override void Configure(EntityTypeBuilder<GymMemberGymTermsOfServices> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => new { x.GymMemberId, x.GymTermsOfServicesId });

            builder.Property(x => x.GymMemberId)
                .IsRequired();

            builder.Property(x => x.GymTermsOfServicesId)
                .IsRequired();

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.GymMember)
                .WithMany(x => x.GymTermsOfServices)
                .HasForeignKey(x => x.GymMemberId);

            builder
                .HasOne(x => x.GymTermsOfServices)
                .WithMany(x => x.GymMembers)
                .HasForeignKey(x => x.GymTermsOfServicesId);

        }
    }
}
