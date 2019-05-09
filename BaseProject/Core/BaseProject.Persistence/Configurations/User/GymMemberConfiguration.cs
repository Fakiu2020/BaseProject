using BaseProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class GymMemberConfiguration : BaseEntityTypeConfiguration<GymMember>
    {
        public override void Configure(EntityTypeBuilder<GymMember> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Gender)
                .HasMaxLength(1);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(50);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.User);
               // .WithOne(x => x.GymMember)
               // .HasForeignKey<GymMember>(x => x.Id);

            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.GymMembers)
                .HasForeignKey(x => x.AddressId);
        }
    }
}
