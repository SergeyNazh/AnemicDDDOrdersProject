using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared.Validation
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services, Assembly assembly)
        {
            services.AddScoped<IValidator, DefaultValidator>();
            Type validationHandlerDataType = typeof(IValidationHandler<,>);
            Type validationHandlerType = typeof(IValidationHandler<>);
            IEnumerable<Type> types = assembly.DefinedTypes
                .Where(t => t.IsClass);
            foreach (Type type in types) 
            {
                IEnumerable<Type> serviceTypes = type.GetInterfaces()
                    .Where(it => it.IsConstructedGenericType 
                        && (it.GetGenericTypeDefinition() == validationHandlerDataType || it.GetGenericTypeDefinition() == validationHandlerType));
                foreach (Type serviceType in serviceTypes)
                {
                    services.AddScoped(serviceType, type);
                }
            }
            return services;
        }
    }
}
