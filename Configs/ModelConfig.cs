using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Configs
{
    public static class ModelConfig
    {
        public static void AddDatabase(this IServiceCollection services, ConfigurationManager configurationManager)
            => services.AddDbContextFactory<ContextConfig>(options =>
                    {
                        options.UseMySql(configurationManager.GetConnectionString("Database"), 
                        builder => builder.MigrationsAssembly("SalesWebMvc"));
                    });
    }
}