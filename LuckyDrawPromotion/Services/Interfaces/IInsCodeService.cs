using LuckyDrawPromotion.Data.Entity;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IInsCodeService
    {
        Task<IEnumerable<InsCode>?> Get();
        Task<InsCode?> Get(Guid id);
        Task<bool> AddAsync(InsCode insCode);
        Task<bool> Put(InsCode insCode);
        Task<bool> Delete(Guid id);
    }
}