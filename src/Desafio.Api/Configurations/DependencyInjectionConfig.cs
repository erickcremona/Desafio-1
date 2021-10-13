using Desafio.Application.Contracts;
using Desafio.Application.Services;
using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Notifications;
using Desafio.Domain.Services;
using Desafio.Infra.Data.Contexts;
using Desafio.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Desafio.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Context>();

            services.AddScoped<IApplicationProduct, ServiceApplicationProduct>();
            services.AddScoped<IApplicationCategory, ServiceApplicationCategory>();
            services.AddScoped<IApplicationSupplier, ServiceApplicationSupplier>();

            services.AddScoped<IServiceProduct, ServiceDomainProduct>();
            services.AddScoped<IServiceCategory, ServiceDomainCategory>();
            services.AddScoped<IServiceSupplier, ServiceDomainSupplier>();

            services.AddScoped<IRepositoryProduct, RepositoryProduct>();
            services.AddScoped<IRepositoryCategory, RepositoryCategory>();
            services.AddScoped<IRepositoryAddress, RepositoryAddress>();
            services.AddScoped<IRepositorySupplier, RepositorySupplier>();

            services.AddScoped<INotification, Notifier>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}
