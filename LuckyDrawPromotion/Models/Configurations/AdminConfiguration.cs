using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Entity
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admin");
            builder.HasKey(a => a.Email);
            builder.Property(a => a.PasswordHash).IsRequired();
            builder.Property(a => a.Fullname).IsRequired().IsUnicode().HasMaxLength(100);
        }
    }
}