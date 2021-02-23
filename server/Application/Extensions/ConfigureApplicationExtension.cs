using Application.Dtos;
using Application.Services.Mappers;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ConfigureApplicationExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped <IMapper<TaskDto, TaskEntity>, TaskMapperService>();
        }
    }
}