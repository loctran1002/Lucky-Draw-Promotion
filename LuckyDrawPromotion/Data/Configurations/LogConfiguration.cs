using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    internal class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");
            builder.HasKey(l => l.Priority);
            builder.Property(l => l.Priority).ValueGeneratedNever();
            builder.Property(l => l.Content).IsRequired().IsUnicode();
            builder.Property(l => l.NameCampaign).IsRequired();

            builder.HasOne(l => l.Campaign)
                .WithMany(c => c.Logs)
                .HasForeignKey(l => l.NameCampaign);
        }
    }
}