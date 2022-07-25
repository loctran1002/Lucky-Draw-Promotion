using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    internal class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Setting");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.GenQR).IsRequired();
            builder.Property(s => s.LandingPage).IsRequired();
            builder.Property(s => s.SMSText).IsRequired().IsUnicode();
            builder.Property(s => s.DailyReport).IsRequired();
            builder.Property(s => s.TimeSend).IsRequired().HasColumnType("datetime");
            builder.Property(s => s.Email).IsRequired();
        }
    }
}