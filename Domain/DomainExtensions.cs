using Domain.Validation.Shared;
using Microsoft.Extensions.DependencyInjection;
using Shared.Validation;
using System.Reflection;

namespace Domain
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            Assembly currentAssembly = typeof(DomainExtensions).Assembly;
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(currentAssembly);
            });
            services.AddValidation(currentAssembly);
            services.AddScoped<CustomerExistingHelper>();
            return services;
        }
    }
}
