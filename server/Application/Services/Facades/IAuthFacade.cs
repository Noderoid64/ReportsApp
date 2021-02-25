using System;
using System.Threading.Tasks;

namespace Application.Services.Facades
{
    public interface IAuthFacade
    {
        Task<ValueTuple<long, string>> GetAuthDataAsync(string email, string password);
    }
}