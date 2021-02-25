using System;
using System.Threading.Tasks;
using Application.Services.JwtToken;
using DAL.Repositories;
using Domain.Entities;
using Tools;

namespace Application.Services.Facades
{
    public class AuthFacade: IAuthFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthFacade(
            IUserRepository userRepository,
            ITokenService tokenService
            )
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        
        public async Task<ValueTuple<long, string>> GetAuthDataAsync(string email, string password)
        {
            UserEntity user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
            
            Validators.IsNotNull(user, $"Incorrect email or password");

            return (user.Id, _tokenService.CreateToken(user));
        }
    }
}