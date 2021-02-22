using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.JwtToken
{
    class JwtTokenOptions
    {
        public const int LIFETIME = 10;
        public const string KEY = "mysupersecret_secretkey!123";
        public const string algorithm = SecurityAlgorithms.HmacSha256;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}