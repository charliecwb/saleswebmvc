using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Configs
{
    public static class ServicesConfig
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<SeedingService>();
            services.AddScoped<SellerService>();
        }
    }
}