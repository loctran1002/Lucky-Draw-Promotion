using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyDrawPromotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>?> Get()
        {
            return await _userService.Get();
        }

        // GET api/<UserController>/123
        [HttpGet("{phone}")]
        public async Task<User?> Get(string phone)
        {
            return await _userService.Get(phone);
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return Ok(new RegisterViewModel());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return CreatedAtAction("Register", registerViewModel);

            var register = await _userService.RegisterAsync(registerViewModel);
            if (!register)
                return BadRequest("Tài khoản đã tồn tại");
            return Ok("Successful");
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return Ok(new LoginViewModel());
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return CreatedAtAction("Login", loginViewModel);

            var register = await _userService.LoginAsync(loginViewModel);
            if (!register)
            {
                //loginViewModel.ErrorMessage = ;
                return BadRequest("Sai tài khoản hoặc mật khẩu. Đăng nhập lại...");
            }
            return Ok("Successful");
        }

        // PUT api/<UserController>/5
        [HttpPut("{phone}")]
        public async Task<bool> Put(string phone, [FromBody] User user)
        {
            return await _userService.Put(phone, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{phone}")]
        public async Task<bool> Delete(string phone)
        {
            return await _userService.Delete(phone);
        }
    }
}
