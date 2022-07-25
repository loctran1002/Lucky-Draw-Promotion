using LuckyDrawPromotion.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IAwardService
    {
        Task<IEnumerable<Award>?> Get();
        Task<Award?> Get(Guid id);
        Task<bool> Post([FromBody] Award award);
        Task<bool> Put(Guid id, [FromBody] Award award);
        Task<bool> Delete(Guid id);
    }
}