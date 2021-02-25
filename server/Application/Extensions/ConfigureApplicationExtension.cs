using Application.Middleware;
using Application.Services.Facades;
using Application.Services.JwtToken;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ConfigureApplicationExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthFacade, AuthFacade>();
            services.AddScoped<ITaskFacade, TaskFacade>();
        }

        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}