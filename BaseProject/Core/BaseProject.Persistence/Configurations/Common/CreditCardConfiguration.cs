using BaseProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whoever.Data.EntityFramework;

namespace BaseProject.Persistence.Configurations
{
    public class CreditCardConfiguration : BaseEntityTypeConfiguration<CreditCard>
    {
        public override void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.CardType)
                .HasMaxLength(50);

            builder.Property(x => x.LastFourNumbers)
                .HasMaxLength(20);

            builder.Property(i => i.IsDefault)
                .HasDefaultValue(false);

            //////////////////////////////////////////
            /// FKs
            //////////////////////////////////////////

            builder
                .HasOne(x => x.User);
                //.WithMany(x => x.CreditCards)
                //.HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.CreditCards)
                .HasForeignKey(x => x.AddressId);

        }
    }
}
