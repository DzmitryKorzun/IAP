using IAP.Services.Implementations;
using IAP.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IAP.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICompanyService, CompanyService>();
        }
    }
}
