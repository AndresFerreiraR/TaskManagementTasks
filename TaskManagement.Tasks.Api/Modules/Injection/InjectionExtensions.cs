using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Tasks.Api.Modules.GlobalException;

namespace TaskManagement.Tasks.Api.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandler>();
            return services;
        }
    }
}