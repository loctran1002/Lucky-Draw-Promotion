using LuckyDrawPromotion.Data.Entity;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface ICampaignService
    {
        Task<IEnumerable<Campaign>?> Get();
        Task<Campaign?> Get(string name);
        Task<bool> CreateAsync(Campaign campaign);
        Task<bool> Put(Campaign campaign);
        Task<bool> Delete(string name);
    }
}