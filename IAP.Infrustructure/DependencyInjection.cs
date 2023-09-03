using IAP.Infrustructure.Interfaces;
using IAP.Infrustructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IAP.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .ConfigureDbConnection(configuration)
                .AddRepositories();
        }

        private static IServiceCollection ConfigureDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            return services
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IBasicRepository<>), typeof(BasicRepository<>))
                .AddScoped<IUserRepository, UserRepository>();
        }
    }
}
