using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class CodeService : ICodeService
    {
        private readonly PromotionDbContext _context;

        public CodeService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenarateCode (string nameCampaign)
        {
            var ins = await _context.InsCodes.FirstOrDefaultAsync(x => x.NameCampaign == nameCampaign);
            var num = ins.Length - ins.Prefix.Length - ins.Postfix.Length;
            string res = ins.Prefix;
            int maxRand = ins.Charset.Length;
            Random rand = new Random();
            for (var i = 0; i < num; i++)
            {
                res += ins.Charset[rand.Next(0, maxRand)];
            }
            res += ins.Postfix;
            return res;
        }

        public async Task<bool> CreateAsync(Code code)
        {
            var checkCampaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Name == code.NameCampaign);
            var checkGift = await _context.Gifts.FirstOrDefaultAsync(x => x.Id == code.IdGift);
            if (checkCampaign == null || checkGift == null || code.CreatedDate >= code.ExpiredDate)
                return false;

            var numOfCode = await _context.Codes.CountAsync(x => x.NameCampaign == code.NameCampaign);
            if (numOfCode >= checkCampaign.CodeCount)
                return false;

            while (true)
            {
                code.Id = await GenarateCode(code.NameCampaign);
                var checkCode = await _context.Codes.FirstOrDefaultAsync(x => x.Id == code.Id);
                if (checkCode == null)
                    break;
            }
            code.CreatedDate = code.CreatedDate.ToUniversalTime();
            code.ExpiredDate = code.ExpiredDate.ToUniversalTime();
            
            await _context.Codes.AddAsync(code);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var code = await _context.Codes.FirstOrDefaultAsync(x => x.Id == id);
            if (code == null)
                return false;
            _context.Codes.Remove(code);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Code>?> GetAsync(string nameCampaign)
        {
            var listCode = await _context.Codes.Where(x => x.NameCampaign == nameCampaign).ToListAsync();
            if (listCode == null)
                return null;
            foreach (var item in listCode)
            {
                item.CreatedDate = item.CreatedDate.ToLocalTime();
                item.ExpiredDate = item.ExpiredDate.ToLocalTime();
            }
            return listCode;
        }
    }
}
