using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
        }
    }
}