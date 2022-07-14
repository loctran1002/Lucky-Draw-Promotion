using LuckyDrawPromotion.Models.Entity;
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
            var find = _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone);
            if (find == null)
                return null;
            return await find;
        }

        public async Task<bool> Post([FromBody] User user)
        {
            var userIsExist = await _context.Users.FindAsync(user.PhoneNumber);
            if (userIsExist != null || !checkPassword(user.PasswordHash))
                return false;

            user.PasswordHash = new PasswordHasher<string>().HashPassword(user.Fullname, user.PasswordHash);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
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
    }
}
