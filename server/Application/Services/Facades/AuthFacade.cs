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
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthFacade(
            IUserRepository userRepository,
            IJwtTokenGenerator tokenGenerator
            )
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(_userRepository));
            _tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(_tokenGenerator));
        }
        
        public async Task<ValueTuple<long, string>> GetAuthDataAsync(string email, string password)
        {
            UserEntity user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
            
            Validators.IsNotNull(user, $"Incorrect email or password");

            return (user.Id, _tokenGenerator.GenerateToken(email, user.Id));
        }
    }
}