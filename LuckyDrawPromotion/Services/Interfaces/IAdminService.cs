using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>?> Get();
        Task<Admin?> Get(string email);
        Task<bool> Post(AdminViewModel adminViewModel);
        Task<bool> Put(AdminViewModel adminViewModel);
        Task<bool> Delete(string email);
    }
}