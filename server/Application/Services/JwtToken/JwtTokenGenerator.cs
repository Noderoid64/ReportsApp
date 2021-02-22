using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.JwtToken
{
    class JwtTokenGenerator : IJwtTokenGenerator
    {
        private List<UserCredentials> users = new List<UserCredentials>()
        {
            new UserCredentials()
            {
                Email = "admin@gmail.com",
                Password = "admin"
            }
        };
        
        public string GenerateToken(string email, string password)
        {
            var identity = GetIdentity(email, password);
            if (identity == null)
            {
                throw new Exception("Invalid username or password");
            }
 
            DateTime now = DateTime.UtcNow;
            
            JwtSecurityToken jwt = new JwtSecurityToken(
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(JwtTokenOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(
                    JwtTokenOptions.GetSymmetricSecurityKey(), 
                    JwtTokenOptions.algorithm)
            );
            
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
 
        private ClaimsIdentity GetIdentity(string email, string password)
        {
            ClaimsIdentity claimsIdentity = null;
            
            UserCredentials person = users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email)
                };
                claimsIdentity = new ClaimsIdentity(
                        claims, 
                        "Token", 
                        ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType
                        );
            }
 
            return claimsIdentity;
        }
    }
}