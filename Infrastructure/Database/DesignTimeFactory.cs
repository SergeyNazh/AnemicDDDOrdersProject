using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<OrdersDbContext>
    {
        public OrdersDbContext CreateDbContext(string[] args)
        {
            string configurationPath = "infrasettings.json";
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(configurationPath, false);
            IConfiguration configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("SqlServer")!;
            DbContextOptionsBuilder<OrdersDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>()
                .UseSqlServer(connectionString);
            return new OrdersDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
