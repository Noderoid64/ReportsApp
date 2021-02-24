using System;
using System.Threading.Tasks;
using Application.Models;
using Application.Services.Facades;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthFacade _authFacade;

        public AuthController(IAuthFacade authFacade)
        {
            _authFacade = authFacade ?? throw new ArgumentNullException(nameof(authFacade));
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetToken(string email, string password)
        {
            return Json(await _authFacade.GetTokenAsync(email, password));
        }
    }
}