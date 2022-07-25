using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class UserService : IUserService
    {
        private readonly PromotionDbContext _context;

        public UserService(PromotionDbContext context)
        {
            _context = context;
        }

        // Function: check password
        // - Password should contain uppercase and lowercase letters.
        // - Password should contain letters and numbers.
        // - Minimum length of the password is 6.
        public bool checkPassword(string password)
        {
            if (password.Length < 6)
                return false;
            return true;
        }

        public async Task<bool> Delete(string phone)
        {
            var userIsExist = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone);
            if (userIsExist == null)
                return false;
            _context.Users.Remove(userIsExist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>?> Get()
        {
            var listUser = _context.Users.ToListAsync();
            if (listUser == null)
                return null;
            return await listUser;
        }

        public async Task<User?> Get(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone);
        }

        public async Task<bool> Put(string phone, [FromBody] User user)
        {
            var userIsExist = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone);
            if (userIsExist == null)
                return false;
            _context.Users.Remove(userIsExist);
            await _context.SaveChangesAsync();

            userIsExist = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == user.PhoneNumber);
            if (userIsExist != null || !checkPassword(user.PasswordHash))
                return false;

            user.PasswordHash = new PasswordHasher<string>().HashPassword(user.Fullname, user.PasswordHash);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
        {
            var userIsExist = await _context.Users.FindAsync(loginViewModel.PhoneNumber);
            if (userIsExist == null)
                return false;

            var result = new PasswordHasher<string>().VerifyHashedPassword(userIsExist.Fullname, userIsExist.PasswordHash, loginViewModel.Password);
            if (result == PasswordVerificationResult.Failed)
                return false;

            return true;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
        {
            var userIsExist = await _context.Users.FindAsync(registerViewModel.PhoneNumber);
            if (userIsExist != null)
                return false;

            var newUser = new User()
            {
                Fullname = registerViewModel.FullName,
                Address = registerViewModel.Address,
                PhoneNumber = registerViewModel.PhoneNumber,
                PasswordHash = new PasswordHasher<string>().HashPassword(registerViewModel.FullName, registerViewModel.Password),
                DoB = registerViewModel.Birthday,
                Position = registerViewModel.Position,
                TypeBusiness = registerViewModel.TypeBusiness,
                Block = false
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}