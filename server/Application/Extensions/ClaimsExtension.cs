using System.Linq;
using System.Security.Claims;
using Tools;

namespace Application.Extensions
{
    public static class ClaimsExtension
    {
        public static long RetrieveUserId(this ClaimsPrincipal user)
        {
            string userId = user.Claims?.FirstOrDefault(c => c.Type.Equals("Id"))?.Value;
            Validators.IsNotNull(userId);
            return long.Parse(userId);
        }
    }
}