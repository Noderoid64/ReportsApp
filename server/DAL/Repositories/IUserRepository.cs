using System.Threading.Tasks;
using Domain.Entities;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}