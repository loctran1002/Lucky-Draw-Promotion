using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        private readonly IAwardService _awardService;

        public AwardController(IAwardService awardService)
        {
            _awardService = awardService;
        }

        // GET: api/<AwardController>
        [HttpGet("{nameCampaign}")]
        public async Task<List<ListWinnerViewModel>> GetListAward(string nameCampaign)
        {
            return await _awardService.GetListAwardAsync(string.Empty, nameCampaign);
        }

        // GET api/<AwardController>/5
        [HttpGet]
        public async Task<List<ListWinnerViewModel>> GetMyAward(string phoneNumber, string nameCampaign)
        {
            return await _awardService.GetListAwardAsync(phoneNumber, nameCampaign);
        }

        // POST api/<AwardController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Award award)
        {
            return await _awardService.Post(award);
        }

        // DELETE api/<AwardController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _awardService.Delete(id);
        }
    }
}
