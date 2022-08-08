using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuckyDrawPromotion.Services.Interfaces
{
    public interface IAwardService
    {
        Task<List<ListWinnerViewModel>> GetListAwardAsync(string phoneNumber, string nameCampaign);
        Task<bool> Post([FromBody] Award award);
        Task<bool> Delete(Guid id);
    }
}