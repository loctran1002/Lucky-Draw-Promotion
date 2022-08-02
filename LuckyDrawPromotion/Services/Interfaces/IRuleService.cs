using LuckyDrawPromotion.Data.Entity;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IRuleService
    {
        Task<IEnumerable<Rule>?> GetAsync(string nameCampaign);
        Task<bool> AddAsync(Rule rule);
        Task<bool> Delete(Guid id);
    }
}