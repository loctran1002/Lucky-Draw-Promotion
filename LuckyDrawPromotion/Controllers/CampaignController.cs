using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        // GET: api/<CampaignController>
        [HttpGet]
        public async Task<IEnumerable<Campaign>?> Get()
        {
            return await _campaignService.Get();
        }

        // GET api/<CampaignController>/5
        [HttpGet("{name}")]
        public async Task<Campaign?> Get(string name)
        {
            return await _campaignService.Get(name);
        }

        // POST api/<CampaignController>
        [HttpPost]
        public async Task<bool> CreateAsync([FromBody] Campaign campaign)
        {
            return await _campaignService.CreateAsync(campaign);
        }

        // PUT api/<CampaignController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Campaign campaign)
        {
            return await _campaignService.Put(campaign);
        }

        // DELETE api/<CampaignController>/5
        [HttpDelete("{name}")]
        public async Task<bool> Delete(string name)
        {
            return await _campaignService.Delete(name);
        }
    }
}
