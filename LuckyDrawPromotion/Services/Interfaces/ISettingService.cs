using LuckyDrawPromotion.Data.Entity;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface ISettingService
    {
        Task<IEnumerable<Setting>?> Get();
        Task<Setting?> Get(Guid id);
        Task<bool> Post(Setting setting);
        Task<bool> Put(Setting setting);
        Task<bool> Delete(Guid id);
    }
}