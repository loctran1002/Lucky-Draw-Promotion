using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly PromotionDbContext _context;

        public CampaignService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string name)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == name);
            if (campaign == null)
                return false;
            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Campaign>?> Get()
        {
            var listCampaign = await _context.Campaigns.ToListAsync();
            if (listCampaign == null)
                return null;
            foreach (var temp in listCampaign)
            {
                temp.StartedDate = temp.StartedDate.ToLocalTime();
                temp.ExpiredDate = temp.ExpiredDate.ToLocalTime();
            }
            return listCampaign;
        }

        public async Task<Campaign?> Get(string name)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == name);
            if (campaign == null)
                return null;
            campaign.StartedDate = campaign.StartedDate.ToLocalTime();
            campaign.ExpiredDate = campaign.ExpiredDate.ToLocalTime();
            return campaign;
        }

        public async Task<bool> CreateAsync(Campaign campaign)
        {
            var exist = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == campaign.Name);
            var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Email == campaign.EmailAdmin);
            var setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == campaign.IdSetting);
            if (exist != null || admin == null || setting == null || campaign.StartedDate >= campaign.ExpiredDate)
                return false;
            campaign.StartedDate = campaign.StartedDate.ToUniversalTime();
            campaign.ExpiredDate = campaign.ExpiredDate.ToUniversalTime();
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Put(Campaign campaign)
        {
            var exist = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == campaign.Name);
            if (exist == null || campaign.StartedDate >= campaign.ExpiredDate)
                return false;

            campaign.StartedDate = campaign.StartedDate.ToUniversalTime();
            campaign.ExpiredDate = campaign.ExpiredDate.ToUniversalTime();
            _context.Campaigns.Update(campaign);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
