using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class RuleService : IRuleService
    {
        private readonly PromotionDbContext _context;

        public RuleService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Rule rule)
        {
            var checkRule = await _context.Rules.FirstOrDefaultAsync(x => x.Id == rule.Id);
            var checkCampaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == rule.NameCampaign);
            var checkGift = await _context.Gifts.FirstOrDefaultAsync(x => x.Id == rule.IdGift);
            if (checkRule != null || checkCampaign == null || checkGift == null || rule.StartTime >= rule.EndTime)
                return false;

            var listRule = await _context.Rules.Where(x => x.NameCampaign == rule.NameCampaign).ToListAsync();
            rule.Priority = listRule.Count() + 1;
            await _context.Rules.AddAsync(rule);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var rule = await _context.Rules.FirstOrDefaultAsync(x => x.Id == id);
            if (rule == null)
                return false;
            var campaign = rule.NameCampaign;
            var priority = rule.Priority;
            _context.Rules.Remove(rule);
            await _context.SaveChangesAsync();
            var listRule = await _context.Rules.Where(x => x.NameCampaign == campaign && x.Priority > priority).ToListAsync();
            foreach (var item in listRule)
            {
                item.Priority--;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Rule>?> GetAsync(string nameCampaign)
        {
            var listRule = await _context.Rules.Where(x => x.NameCampaign == nameCampaign).ToListAsync();
            if (listRule == null)
                return null;
            return listRule.OrderBy(r => r.Priority).ToList();
        }
    }
}
