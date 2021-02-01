using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Munharaunda.Domain.Contracts;
using Munharaunda.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Munharaunda.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IMunharaundaRepository, MunharaundaRepository>();
            #region DBContext
            // Register Entity Framework

            var test = configuration.GetConnectionString("Default");
            services.AddDbContext<MunharaundaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Munharaunda.Infrastructure")));

            services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44330");
            });


            #endregion
            return services;
        }
    }
}
