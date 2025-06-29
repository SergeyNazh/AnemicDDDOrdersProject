using Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IConfigurationBuilder AddInfrastructure(this IConfigurationBuilder configurationBuilder)
        {
            string configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "infrasettings.json");
            configurationBuilder
                .AddJsonFile(configurationPath, false);
            return configurationBuilder;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SqlServer")!;
            return services.AddDbContextPool<IDatabaseContext, OrdersDbContext>(optionsBuilder =>
            {
                optionsBuilder
                    .UseSqlServer(connectionString);
            });
        }
    }
}
