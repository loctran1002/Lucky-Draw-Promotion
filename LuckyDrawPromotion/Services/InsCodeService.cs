using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class InsCodeService : IInsCodeService
    {
        private readonly PromotionDbContext _context;
        public LogService _logService;

        public InsCodeService(PromotionDbContext context, LogService logService)
        {
            _context = context;
            _logService = logService;
        }

        public async Task<bool> CreateAsync(InsCode insCode)
        {
            var ins = await _context.InsCodes.FirstOrDefaultAsync(x => x.Id == insCode.Id);
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == insCode.NameCampaign);
            if (ins != null || campaign == null)
                return false;
            await _context.InsCodes.AddAsync(insCode);
            await _context.SaveChangesAsync();

            Log log = new Log()
            {
                Content = "Thêm cách tạo code",
                NameCampaign = campaign.Name
            };
            await _logService.CreateAsync(log);
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
    }
}
