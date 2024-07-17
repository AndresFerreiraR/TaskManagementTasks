using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Tasks.Common.Common.Options;
using TaskManagement.Tasks.Infrastructure.Classes;
using TaskManagement.Tasks.Infrastructure.Contexts;
using TaskManagement.Tasks.Infrastructure.Interfaces;

namespace TaskManagement.Tasks.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<TaskContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.Configure<CosmosDbSettings>(configuration.GetSection("CosmosDbSettings"));
            services.AddSingleton<CosmosDbContext>();

            services.AddScoped<ITaskDL, TaskDL>();

            return services;
        }
    }
}