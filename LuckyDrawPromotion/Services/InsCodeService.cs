using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class InsCodeService : IInsCodeService
    {
        private readonly PromotionDbContext _context;

        public InsCodeService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(InsCode insCode)
        {
            var ins = await _context.InsCodes.FirstOrDefaultAsync(x => x.Id == insCode.Id);
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == insCode.NameCampaign);
            if (ins != null || campaign == null)
                return false;
            await _context.InsCodes.AddAsync(ins);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var ins = await _context.InsCodes.FirstOrDefaultAsync(x => x.Id == id);
            if (ins == null)
                return false;
            _context.InsCodes.Remove(ins);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<InsCode>?> Get()
        {
            return await _context.InsCodes.ToListAsync();
        }

        public async Task<InsCode?> Get(Guid id)
        {
            return await _context.InsCodes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Put(InsCode insCode)
        {
            var ins = await _context.InsCodes.FirstOrDefaultAsync(x => x.Id == insCode.Id);
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == insCode.NameCampaign);
            if (ins == null || campaign == null)
                return false;
            _context.InsCodes.Update(insCode);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
