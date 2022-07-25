using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        // GET: api/<SettingController>
        [HttpGet]
        public async Task<IEnumerable<Setting>?> Get()
        {
            return await _settingService.Get();
        }

        // GET api/<SettingController>/5
        [HttpGet("{id}")]
        public async Task<Setting?> Get(Guid id)
        {
            return await _settingService.Get(id);
        }

        // POST api/<SettingController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Setting setting)
        {
            return await _settingService.Post(setting);
        }

        // PUT api/<SettingController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Setting setting)
        {
            return await _settingService.Put(setting);
        }

        // DELETE api/<SettingController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _settingService.Delete(id);
        }
    }
}
