using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Common.Interfaces;
using Server.Domain.Repositories;
using Server.Domain.Repositories.Inventory;
using Server.Infrastructure.Data.Context;
using Server.Infrastructure.Repositories;
using Server.Infrastructure.Repositories.Inventory;

namespace Server.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Context Registration - Internal class'ı DI container'a kaydet
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseFirebird(connectionString); // Firebird provider configuration

                // Development optimizations
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    options.EnableSensitiveDataLogging(); // SQL parameter logging
                    options.EnableDetailedErrors(); // Detailed error messages
                    options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information); // Console logging
                }

                options.EnableServiceProviderCaching(); // Performance optimization
            });

            // Interface Implementation Registration - Clean Architecture boundary
            services.AddScoped<IApplicationDbContext>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<ApplicationDbContext>(); // Internal context'i al
                return context; // Interface olarak döner - dış katmanlar sadece interface'i görür
            });

            // Repository Pattern Registration - Dependency inversion principle
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Generic repository
            services.AddScoped<IGoodsRepository, GoodsRepository>(); // Domain specific repository

            return services; // Fluent interface pattern
        }
    }
}
