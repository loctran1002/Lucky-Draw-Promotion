using LuckyDrawPromotion.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Data.Entity
{
    public class PromotionDbContext : DbContext
    {
        public PromotionDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CampaignConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new AwardConfiguration());
            modelBuilder.ApplyConfiguration(new InsCodeConfiguration());
            modelBuilder.ApplyConfiguration(new CodeConfiguration());
            modelBuilder.ApplyConfiguration(new GiftConfiguration());
            modelBuilder.ApplyConfiguration(new RuleConfiguration());
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<InsCode> InsCodes { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Rule> Rules { get; set; }
        #endregion
    }
}
