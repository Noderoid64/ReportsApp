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
    public class AuthController : Controller
    {
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthController(
            IJwtTokenGenerator tokenGenerator,
            IUserRepository userRepository
        )
        {
            _tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetToken(string email, string password)
        {
            UserEntity user = await _userRepository.GetUserByEmailAsync(email);
            
            Validators.IsNotNull(user, $"User with email: {email} does not exist");
            Validators.IsFalse((!password.Equals(user.Password)), $"Incorrect password");
            
            return Json(_tokenGenerator.GenerateToken(email, user.Id));
        }
    }
}