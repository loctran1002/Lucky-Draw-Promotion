using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class LogService : ILogService
    {
        private readonly PromotionDbContext _context;

        public LogService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Log log)
        {
            var find = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == log.NameCampaign);
            if (find == null)
                return false;

            var count = await _context.Logs.CountAsync();
            var listLog = await (from l in _context.Logs
                                 where l.NameCampaign == log.NameCampaign
                                 select l).ToListAsync();
            if (listLog.Count() < 3)
            {
                log.Priority = count + 1;
                await _context.Logs.AddAsync(log);
                await _context.SaveChangesAsync();
                return true;
            }
            int i;
            for (i = 1; i < listLog.Count(); i++)
            {
                listLog[i - 1].Content = listLog[i].Content;
            }
            listLog[i].Content = log.Content;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Log>?> Get()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<Log?> Get(int priotity)
        {
            return await _context.Logs.FirstOrDefaultAsync(x => x.Priority == priotity);
        }
    }
}
