using DAL.Repositories;
using Domain.Ports;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ConfigureDomainExtension
    {
        public static void ConfigureDomain(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskProvider, TaskRepository>();
        }
    }
}