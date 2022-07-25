using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: api/<AdminController>
        [HttpGet]
        public async Task<IEnumerable<Admin>?> Get()
        {
            return await _adminService.Get();
        }

        // GET api/<AdminController>/5
        [HttpGet("{email}")]
        public async Task<Admin?> Get(string email)
        {
            return await _adminService.Get(email);
        }

        // POST api/<AdminController>
        [HttpPost]
        public async Task<bool> Post([FromBody] AdminViewModel adminViewModel)
        {
            return await _adminService.Post(adminViewModel);
        }

        // PUT api/<AdminController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] AdminViewModel adminViewModel)
        {
            return await _adminService.Put(adminViewModel);
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{email}")]
        public async Task<bool> Delete(string email)
        {
            return await _adminService.Delete(email);
        }
    }
}
