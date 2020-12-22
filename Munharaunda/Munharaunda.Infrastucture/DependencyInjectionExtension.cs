using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Munharaunda.Infrastucture.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Munharaunda.Infrastucture
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region DBContext
            // Register Entity Framework
            services.AddDbContext<MunharaundaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Munharaunda.Infrastucture")));
            
            
            #endregion
            return services;
        }
    }
}
