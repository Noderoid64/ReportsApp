using Domain.Entities;

namespace Application.Services.JwtToken
{
    public interface ITokenService
    {
        string CreateToken(UserEntity user);
    }
}