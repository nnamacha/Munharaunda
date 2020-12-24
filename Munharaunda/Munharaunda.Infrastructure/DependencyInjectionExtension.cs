using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<MunharaundaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Munharaunda.Infrastructure")));
            
            
            #endregion
            return services;
        }
    }
}
