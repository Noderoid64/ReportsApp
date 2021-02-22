using System;
using Application.Services.JwtToken;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: Controller
    {
        private IJwtTokenGenerator _tokenGenerator;

        public AuthController(IJwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
        }
        
        [HttpGet]
        public ActionResult<string> GetToken(string email, string password)
        {
            ActionResult result;
            try
            {
                result = Json(_tokenGenerator.GenerateToken(email, password));
            }
            catch (Exception e)
            {
                result = Problem(e.Message);
            }

            return result;
        }
    }
}