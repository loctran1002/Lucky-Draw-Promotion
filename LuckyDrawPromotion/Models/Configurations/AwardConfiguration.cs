using LuckyDrawPromotion.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    internal class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.ToTable("Award");
            builder.HasKey(a => new { a.IdCode, a.PhoneNumberUser });
            builder.Property(a => a.UsedDate).HasColumnType("datetime");
            builder.Property(a => a.IsSent).IsRequired();

            builder.HasOne(a => a.Code)
                .WithMany(c => c.Awards)
                .HasForeignKey(a => a.IdCode);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Awards)
                .HasForeignKey(a => a.PhoneNumberUser);
        }
    }
}