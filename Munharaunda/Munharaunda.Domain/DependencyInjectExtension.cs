using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Services;
using Munharaunda.Domain.Utilities;

namespace Munharaunda.Domain
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplications(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IResponsesService, ResponsesService>();

            services.AddScoped<ICommonUtilities, CommonUtilities>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
