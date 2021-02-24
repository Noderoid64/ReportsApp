using System;
using System.Threading.Tasks;
using Application.Services.JwtToken;
using DAL.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Tools;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: Controller
    {
        private IJwtTokenGenerator _tokenGenerator;
        private IUserRepository _userRepository;
        public AuthController(
            IJwtTokenGenerator tokenGenerator,
            IUserRepository userRepository
            )
        {
            _tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
            _userRepository = userRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<string>> GetToken(string email, string password)
        {
            ActionResult result;
            try
            {
                UserEntity user = await _userRepository.GetUserByEmailAsync(email);
                Assert.IsNotNull(user, $"User with email: {email} does not exist");
                Assert.IsFalse((!password.Equals(user.Password)), $"Incorrect password");
                result = Json(_tokenGenerator.GenerateToken(email, user.Id));
            }
            catch (Exception e)
            {
                result = Problem(e.Message);
            }

            return result;
        }
    }
}