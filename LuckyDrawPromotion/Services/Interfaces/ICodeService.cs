using LuckyDrawPromotion.Data.Entity;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface ICodeService
    {
        Task<IEnumerable<Code>?> GetAsync(string nameCampaign);
        Task<bool> CreateAsync(Code code);
        Task<bool> Delete(string Id);
    }
}