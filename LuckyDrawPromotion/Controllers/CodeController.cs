using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        public readonly ICodeService _codeService;

        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        // GET: api/<CodeController>
        [HttpGet("{nameCampaign}")]
        public async Task<IEnumerable<Code>?> Get(string nameCampaign)
        {
            return await _codeService.GetAsync(nameCampaign);
        }

        // POST api/<CodeController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Code code)
        {
            var add = await _codeService.CreateAsync(code);
            if (!add)
                return BadRequest("Mã code đã tồn tại");
            return Ok("Successful");
        }

        // DELETE api/<CodeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var del = await _codeService.Delete(id);
            if (!del)
                return BadRequest("Xóa thất bại");
            return Ok("Successful");
        }
    }
}
