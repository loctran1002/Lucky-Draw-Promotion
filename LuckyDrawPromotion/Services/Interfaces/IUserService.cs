using LuckyDrawPromotion.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>?> Get();
        Task<User?> Get(string phone);
        Task<bool> Post([FromBody] User user);
        Task<bool> Put(string phone, [FromBody] User user);
        Task<bool> Delete(string phone);
    }
}