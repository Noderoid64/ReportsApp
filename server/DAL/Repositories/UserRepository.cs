using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserEntity> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u =>
                u.Email.Equals(email) &&
                u.Password.Equals(password)
            );
        }
    }
}