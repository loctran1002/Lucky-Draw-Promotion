using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDrawPromotion.Models.Configurations
{
    internal class InsCodeConfiguration : IEntityTypeConfiguration<InsCode>
    {
        public void Configure(EntityTypeBuilder<InsCode> builder)
        {
            builder.ToTable("InsCode");
            builder.HasKey(ins => ins.Id);
            builder.Property(ins => ins.Charset).IsRequired();
            builder.Property(ins => ins.Length).IsRequired();
            builder.Property(ins => ins.Prefix).IsRequired();
            builder.Property(ins => ins.Postfix).IsRequired();
            builder.Property(ins => ins.NameCampaign).IsRequired();

            builder.HasOne(ins => ins.Campaign)
                .WithMany(c => c.InsCodes)
                .HasForeignKey(ins => ins.NameCampaign);
        }
    }
}