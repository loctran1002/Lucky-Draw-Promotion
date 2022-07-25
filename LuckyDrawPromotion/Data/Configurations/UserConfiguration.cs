using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.PhoneNumber);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.Fullname).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(u => u.Address).IsRequired().HasMaxLength(200);
            builder.Property(u => u.DoB).IsRequired().HasColumnType("date");
            builder.Property(u => u.Position).IsRequired().IsUnicode();
            builder.Property(u => u.TypeBusiness).IsRequired().IsUnicode();
            builder.Property(u => u.Block).IsRequired().HasDefaultValue(false);
        }
    }
}