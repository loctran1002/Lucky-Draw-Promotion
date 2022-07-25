using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    internal class GiftConfiguration : IEntityTypeConfiguration<Gift>
    {
        public void Configure(EntityTypeBuilder<Gift> builder)
        {
            builder.ToTable("Gift");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).IsRequired().IsUnicode();
            builder.Property(g => g.Description).IsRequired().IsUnicode();
            builder.Property(g => g.CreatedDate).IsRequired().HasColumnType("datetime");
        }
    }
}