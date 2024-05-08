using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Tasks.Application.Classes;
using TaskManagement.Tasks.Application.Interfaces;
using TaskManagement.Tasks.Application.Mappings;

namespace TaskManagement.Tasks.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<ITaskBL, TaskBL>();

            return services;
        }
    }
}