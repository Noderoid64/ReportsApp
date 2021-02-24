using Application.Middleware;
using Application.Models;
using Application.Models.Dtos;
using Application.Services.Facades;
using Application.Services.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ConfigureApplicationExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped <IBiCollectionMapper<TaskDto, TaskEntity>, TaskMapperService>();
            services.AddScoped<IAuthFacade, AuthFacade>();
            services.AddScoped<ITaskFacade, TaskFacade>();
        }

        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}