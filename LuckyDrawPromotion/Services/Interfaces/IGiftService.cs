using LuckyDrawPromotion.Data.Entity;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IGiftService
    {
        Task<IEnumerable<Gift>?> Get();
        Task<Gift?> Get(Guid id);
        Task<bool> Post(Gift gift);
        Task<bool> Put(Guid id, Gift gift);
        Task<bool> Delete(Guid id);
    }
}