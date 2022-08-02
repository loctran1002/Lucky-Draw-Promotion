using LuckyDrawPromotion.Data.Entity;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IInsCodeService
    {
        Task<IEnumerable<InsCode>?> Get();
        Task<InsCode?> Get(Guid id);
        Task<bool> CreateAsync(InsCode insCode);
        Task<bool> Delete(Guid id);
    }
}