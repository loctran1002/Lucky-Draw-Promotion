using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    internal class CodeConfiguration : IEntityTypeConfiguration<Code>
    {
        public void Configure(EntityTypeBuilder<Code> builder)
        {
            builder.ToTable("Code");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Active).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.Target).IsRequired().HasMaxLength(5);
            builder.Property(c => c.CreatedDate).IsRequired().HasColumnType("datetime");
            builder.Property(c => c.ExpiredDate).IsRequired().HasColumnType("datetime");
            builder.Property(c => c.Type).IsRequired().HasMaxLength(10);
            builder.Property(c => c.UsedCount).IsRequired().HasDefaultValue(0);
            builder.Property(c => c.LimitUsage).IsRequired();
            builder.Property(c => c.NameCampaign).IsRequired();
            builder.Property(c => c.IdGift).IsRequired();

            builder.HasOne(c => c.Campaign)
                .WithMany(cp => cp.Codes)
                .HasForeignKey(c => c.NameCampaign)
                .OnDelete(DeleteBehavior.Restrict); ;

            builder.HasOne(c => c.Gift)
                .WithMany(g => g.Codes)
                .HasForeignKey(c => c.IdGift)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}