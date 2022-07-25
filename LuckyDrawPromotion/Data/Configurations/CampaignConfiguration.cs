using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    internal class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaign");
            builder.HasKey(c => c.Name);
            builder.Property(c => c.StartedDate).IsRequired().HasColumnType("smalldatetime");
            builder.Property(c => c.ExpiredDate).IsRequired().HasColumnType("smalldatetime");
            builder.Property(c => c.Description).IsRequired().IsUnicode();
            builder.Property(c => c.AutoUpdate).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.UseOnlyOnce).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.IdSetting).IsRequired();
            builder.Property(c => c.EmailAdmin).IsRequired();

            builder.HasOne(c => c.Setting)
                .WithOne(s => s.Campaign)
                .HasForeignKey<Campaign>(c => c.IdSetting);

            builder.HasOne(c => c.Admin)
                .WithMany(a => a.Campaigns)
                .HasForeignKey(c => c.EmailAdmin);
        }
    }
}