using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Configs
{
    public static class ModelConfig
    {
        public static void AddDatabase(this IServiceCollection services, ConfigurationManager configurationManager)
                    => services.AddDbContextFactory<ContextConfig>(options =>
                    {
                        options.UseMySql(configurationManager.GetConnectionString("Database"), 
                        new MySqlServerVersion(new Version(8, 0, 34)),
                        builder => builder.MigrationsAssembly("SalesWebMvc"));
                    });
    }
}