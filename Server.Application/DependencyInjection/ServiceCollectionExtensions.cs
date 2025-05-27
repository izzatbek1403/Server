using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Common.Mappings;
using System.Reflection;

namespace Server.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly(); // Çalışan assembly'yi al

            // MediatR registration - CQRS pattern için - tüm Command/Query Handler'ları bulur
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(assembly));

            // AutoMapper registration - Entity-DTO mapping için - MappingProfile'ı yükler
            services.AddAutoMapper(typeof(MappingProfile));

            // FluentValidation registration - Model validation için - tüm Validator'ları bulur
            services.AddValidatorsFromAssembly(assembly);

            return services; // Fluent interface için services döner
        }
    }
}
