using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class SettingService : ISettingService
    {
        private readonly PromotionDbContext _context;

        public SettingService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(Guid id)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting == null)
                return false;
            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Setting>?> Get()
        {
            var listSetting = await _context.Settings.ToListAsync();
            if (listSetting == null)
                return null;
            foreach (var temp in listSetting)
            {
                temp.TimeSend = temp.TimeSend.ToLocalTime();
            }
            return listSetting;
        }

        public async Task<Setting?> Get(Guid id)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting == null)
                return null;
            setting.TimeSend = setting.TimeSend.ToLocalTime();
            return setting;
        }

        public async Task<bool> Post(Setting setting)
        {
            var exist = await _context.Settings.FirstOrDefaultAsync(x => x.Id == setting.Id);
            if (exist != null)
                return false;
            setting.TimeSend = setting.TimeSend.ToUniversalTime();
            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Put(Setting setting)
        {
            var exist = await _context.Settings.FirstOrDefaultAsync(x => x.Id == setting.Id);
            if (exist == null)
                return false;
            setting.TimeSend = setting.TimeSend.ToUniversalTime();
            _context.Settings.Update(setting);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
