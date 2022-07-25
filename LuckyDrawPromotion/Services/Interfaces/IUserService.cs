using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>?> Get();
        Task<User?> Get(string phone);
        Task<bool> Put(string phone, [FromBody] User user);
        Task<bool> Delete(string phone);

        Task<bool> RegisterAsync(RegisterViewModel registerViewModel);
        Task<bool> LoginAsync(LoginViewModel loginViewModel);
    }
}