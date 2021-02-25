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
        
        public async Task<string> GetTokenAsync(string email, string password)
        {
            UserEntity user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
            
            Validators.IsNotNull(user, $"User with email: {email} does not exist");
            Validators.IsFalse((!password.Equals(user.Password)), $"Incorrect password");

            return _tokenGenerator.GenerateToken(email, user.Id);
        }
    }
}