using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        // GET: api/<LogController>
        [HttpGet]
        public async Task<IEnumerable<Log>?> Get()
        {
            return await _logService.Get();
        }

        // GET api/<LogController>/5
        [HttpGet("{priotity}")]
        public async Task<Log?> Get(int priotity)
        {
            return await _logService.Get(priotity);
        }

        // POST api/<LogController>
        [HttpPost]
        public async Task<bool> CreateAsync(Log log)
        {
            return await _logService.CreateAsync(log);
        }
    }
}
