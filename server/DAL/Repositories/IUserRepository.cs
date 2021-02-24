using System.Threading.Tasks;
using Domain.Entities;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserByEmailAsync(string email);
    }
}