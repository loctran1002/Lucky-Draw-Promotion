using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : ControllerBase
    {
        private readonly IRuleService _ruleService;

        public RuleController(IRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        // GET: api/<RuleController>
        [HttpGet("{nameCampaign}")]
        public async Task<IEnumerable<Rule>?> GetAsync(string nameCampaign)
        {
            return await _ruleService.GetAsync(nameCampaign);
        }

        // POST api/<RuleController>
        [HttpPost]
        public async Task<IActionResult> AddRule([FromBody] Rule rule)
        {
            var addRule = await _ruleService.AddAsync(rule);
            if (!addRule)
                return BadRequest("Điều lệ thêm vào không hợp lệ");
            return Ok("Successful");
        }

        // DELETE api/<RuleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removeRule = await _ruleService.Delete(id);
            if (!removeRule)
                return BadRequest("Delete unsuccessfully");
            return Ok("Successful");
        }
    }
}
