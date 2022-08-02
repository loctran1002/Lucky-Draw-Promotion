using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    internal class RuleConfiguration : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            builder.ToTable("Rule");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Schedule).IsRequired();
            builder.Property(r => r.StartTime).IsRequired().HasColumnType("time");
            builder.Property(r => r.EndTime).HasColumnType("time");
            builder.Property(r => r.Probability).IsRequired();
            builder.Property(r => r.QuantityGift).IsRequired().HasDefaultValue(0);
            builder.Property(r => r.Priority).IsRequired().HasDefaultValue(1);
            builder.Property(r => r.Active).IsRequired().HasDefaultValue(false);
            builder.Property(r => r.NameCampaign).IsRequired();
            builder.Property(r => r.IdGift).IsRequired();

            builder.HasOne(r => r.Campaign)
                .WithMany(c => c.Rules)
                .HasForeignKey(r => r.NameCampaign);

            builder.HasOne(r => r.Gift)
                .WithMany(g => g.Rules)
                .HasForeignKey(r => r.IdGift);
        }
    }
}