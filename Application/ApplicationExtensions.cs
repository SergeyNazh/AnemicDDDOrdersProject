using System.Reflection;

namespace Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            Assembly assembly = typeof(ApplicationExtensions).Assembly;
            return services
                .AddAutoMapper(assembly);
        }
    }
}
