using LuckyDrawPromotion.Data.Entity;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface ILogService
    {
        Task<IEnumerable<Log>?> Get();
        Task<Log?> Get(int priotity);
        Task<bool> CreateAsync(Log log);
    }
}