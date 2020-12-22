using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Munharaunda.Domain
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplications(this IServiceCollection services, IConfiguration configuration)
        {



            return services;
        }
    }
}
