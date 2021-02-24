namespace Application.Services.JwtToken
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string email, long id);
    }
}