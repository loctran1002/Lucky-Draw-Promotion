using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class AwardService : IAwardService
    {
        private readonly PromotionDbContext _context;

        public AwardService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(Guid id)
        {
            var awardIsExist = await _context.Awards.FirstOrDefaultAsync(x => x.Id == id);
            if (awardIsExist == null)
                return false;
            _context.Awards.Remove(awardIsExist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Award>?> Get()
        {
            return await _context.Awards.ToListAsync();
        }

        public async Task<Award?> Get(Guid id)
        {
            return await _context.Awards.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Post([FromBody] Award award)
        {
            var userIsExist = await _context.Users.FirstOrDefaultAsync(x => x .PhoneNumber == award.PhoneNumberUser);
            //var codeIsExist = await _context.Codes.FirstOrDefaultAsync(x => x.Id == award.IdCode);
            var awardIsExist = await _context.Awards.FirstOrDefaultAsync(x => x.Id == award.Id);
            if (userIsExist == null || awardIsExist != null)
                return false;

            if (award.UsedDate != null)
                if (award.UsedDate > DateTime.Now)
                    return false;
                else
                {
                    award.UsedDate = Convert.ToDateTime(award.UsedDate).ToUniversalTime();
                }

            await _context.Awards.AddAsync(award);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Put(Guid id, [FromBody] Award award)
        {
            var awardIsExist = await _context.Awards.FindAsync(award.Id);
            if (awardIsExist == null)
                return false;

            _context.Remove(awardIsExist);
            await _context.SaveChangesAsync();


            awardIsExist = await _context.Awards.FindAsync(award.Id);
            var checkIsExist = await _context.Awards.FirstOrDefaultAsync(x => x.IdCode == award.IdCode
                                                                           && x.PhoneNumberUser == award.PhoneNumberUser
                                                                           && x.UsedDate == award.UsedDate);
            if (awardIsExist != null || checkIsExist != null)
                return false;

            if (award.UsedDate > DateTime.Now)
                return false;
            award.UsedDate = DateTime.UtcNow;

            await _context.Awards.AddAsync(award);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
