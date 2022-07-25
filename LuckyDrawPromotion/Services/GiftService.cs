using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class GiftService : IGiftService
    {
        private readonly PromotionDbContext _context;

        public GiftService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(Guid id)
        {
            var gift = await _context.Gifts.FirstOrDefaultAsync(x => x.Id == id);
            if (gift == null)
                return false;
            _context.Gifts.Remove(gift);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Gift>?> Get()
        {
            var listGift = await _context.Gifts.ToListAsync();
            if (listGift == null)
                return null;
            foreach (var gift in listGift)
            {
                gift.CreatedDate = gift.CreatedDate.ToLocalTime();
            }
            return listGift;
        }

        public async Task<Gift?> Get(Guid id)
        {
            var gift = await _context.Gifts.FirstOrDefaultAsync(x => x.Id == id);
            gift.CreatedDate = gift.CreatedDate.ToLocalTime();
            return gift;
        }

        public async Task<bool> Post(Gift gift)
        {
            var exist = await _context.Gifts.FirstOrDefaultAsync(x => x.Id == gift.Id);
            if (exist != null)
                return false;
            gift.CreatedDate = gift.CreatedDate.ToUniversalTime();
            await _context.Gifts.AddAsync(gift);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Put(Guid id, Gift gift)
        {
            var exist = await _context.Gifts.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
                return false;
            _context.Gifts.Remove(exist);
            await _context.SaveChangesAsync();

            gift.CreatedDate = gift.CreatedDate.ToUniversalTime();
            await _context.Gifts.AddAsync(gift);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
