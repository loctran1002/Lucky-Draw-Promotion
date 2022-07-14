using LuckyDrawPromotion.Models.Entity;
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
        [HttpGet]
        public async Task<IEnumerable<Award>?> Get()
        {
            return await _awardService.Get();
        }

        // GET api/<AwardController>/5
        [HttpGet("{id}")]
        public async Task<Award?> Get(Guid id)
        {
            return await _awardService.Get(id);
        }

        // POST api/<AwardController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Award award)
        {
            return await _awardService.Post(award);
        }

        // PUT api/<AwardController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(Guid id, [FromBody] Award award)
        {
            return await _awardService.Put(id, award);
        }

        // DELETE api/<AwardController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _awardService.Delete(id);
        }
    }
}
