namespace IAP.Web
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }
    }
}
