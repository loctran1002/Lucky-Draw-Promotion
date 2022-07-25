using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Models;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LuckyDrawPromotion.Services
{
    public class AdminService : IAdminService
    {
        private readonly PromotionDbContext _context;

        public AdminService(PromotionDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string email)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Email == email);
            if (admin == null)
                return false;
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Admin>?> Get()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin?> Get(string email)
        {
            return await _context.Admins.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> Post(AdminViewModel adminViewModel)
        {
            var exist = await _context.Admins.FirstOrDefaultAsync(x => x.Email == adminViewModel.Email);
            if (exist != null)
                return false;

            var newAdmin = new Admin()
            {
                Email = adminViewModel.Email,
                PasswordHash = new PasswordHasher<string>().HashPassword(adminViewModel.Fullname, adminViewModel.Password),
                Fullname = adminViewModel.Fullname
            };

            await _context.Admins.AddAsync(newAdmin);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Put(AdminViewModel adminViewModel)
        {
            var exist = await _context.Admins.FirstOrDefaultAsync(x => x.Email == adminViewModel.Email);
            if (exist == null)
                return false;

            exist.PasswordHash = new PasswordHasher<string>().HashPassword(adminViewModel.Fullname, adminViewModel.Password);
            exist.Fullname = adminViewModel.Fullname;

            _context.Admins.Update(exist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
