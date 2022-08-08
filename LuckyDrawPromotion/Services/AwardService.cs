using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;
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
            var code = await _context.Codes.FirstOrDefaultAsync(x => x.Id == awardIsExist.IdCode);
            if (code.UsedCount == 0)
                return false;
            code.UsedCount--;
            _context.Awards.Remove(awardIsExist);
            _context.Codes.Update(code);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ListWinnerViewModel>> GetListAwardAsync(string phoneNumber, string nameCampaign)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == nameCampaign);
            if (campaign == null)
                return new List<ListWinnerViewModel>();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                var listCode = await (from c in _context.Codes
                                      join g in _context.Gifts on c.IdGift equals g.Id
                                      where c.NameCampaign == nameCampaign && g.Name != "Chúc bạn may mắn lần sau"
                                      select c).ToListAsync();
                var listWinner = (from c in listCode
                                  join a in _context.Awards on c.Id equals a.IdCode
                                  orderby a.UsedDate descending
                                  select new ListWinnerViewModel
                                  {
                                      PhoneNumber = a.PhoneNumberUser,
                                      Date = Convert.ToDateTime(a.UsedDate).ToLocalTime(),
                                      Award = _context.Gifts.First(x => x.Id == c.IdGift).Name
                                  }).ToList();
                return listWinner;
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            if (user == null)
                return new List<ListWinnerViewModel>();
            var listWinners = (from c in _context.Codes
                              join a in _context.Awards on c.Id equals a.IdCode
                              where a.PhoneNumberUser == phoneNumber && c.NameCampaign == nameCampaign
                              orderby a.UsedDate descending
                              select new ListWinnerViewModel
                              {
                                  PhoneNumber = a.PhoneNumberUser,
                                  Date = Convert.ToDateTime(a.UsedDate).ToLocalTime(),
                                  Award = _context.Gifts.First(x => x.Id == c.IdGift).Name
                              }).ToList();
            return listWinners;
        }

        public async Task<bool> Post([FromBody] Award award)
        {
            var userIsExist = await _context.Users.FirstOrDefaultAsync(x => x .PhoneNumber == award.PhoneNumberUser);
            var codeIsExist = await _context.Codes.FirstOrDefaultAsync(x => x.Id == award.IdCode);
            var awardIsExist = await _context.Awards.FirstOrDefaultAsync(x => x.Id == award.Id);
            if (userIsExist == null || codeIsExist == null || awardIsExist != null)
                return false;

            if (codeIsExist.UsedCount == codeIsExist.LimitUsage)
                return false;
            codeIsExist.UsedCount++;

            if (award.UsedDate != null)
                if (award.UsedDate > DateTime.Now)
                    return false;
                else
                {
                    award.UsedDate = Convert.ToDateTime(award.UsedDate).ToUniversalTime();
                }

            await _context.Awards.AddAsync(award);
            _context.Codes.Update(codeIsExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
