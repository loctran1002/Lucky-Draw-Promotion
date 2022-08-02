using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsCodeController : ControllerBase
    {
        private readonly IInsCodeService _insCodeService;

        public InsCodeController(IInsCodeService insCodeService)
        {
            _insCodeService = insCodeService;
        }

        // GET: api/<InsCodeController>
        [HttpGet]
        public async Task<IEnumerable<InsCode>?> Get()
        {
            return await _insCodeService.Get();
        }

        // GET api/<InsCodeController>/5
        [HttpGet("{id}")]
        public async Task<InsCode?> Get(Guid id)
        {
            return await _insCodeService.Get(id);
        }

        // POST api/<InsCodeController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InsCode insCode)
        {
            var add = await _insCodeService.CreateAsync(insCode);
            if (!add)
                return BadRequest("Cách tạo code đã tồn tại");
            return Ok("Successful");
        }

        // DELETE api/<InsCodeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var del = await _insCodeService.Delete(id);
            if (!del)
                return BadRequest("Xóa thất bại");
            return Ok("Successful");
        }
    }
}
