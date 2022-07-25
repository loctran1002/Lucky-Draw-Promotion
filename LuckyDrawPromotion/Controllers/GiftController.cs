using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;

        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }

        // GET: api/<GiftsController>
        [HttpGet]
        public async Task<IEnumerable<Gift>?> Get()
        {
            return await _giftService.Get();
        }

        // GET api/<GiftsController>/5
        [HttpGet("{id}")]
        public async Task<Gift?> Get(Guid id)
        {
            return await _giftService.Get(id);
        }

        // POST api/<GiftsController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Gift gift)
        {
            return await _giftService.Post(gift);
        }

        // PUT api/<GiftsController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(Guid id, [FromBody] Gift gift)
        {
            return await _giftService.Put(id, gift);
        }

        // DELETE api/<GiftsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _giftService.Delete(id);
        }
    }
}
