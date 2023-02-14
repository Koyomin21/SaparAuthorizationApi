using SaparAuthorization.Domain;
using Microsoft.EntityFrameworkCore;

namespace SaparAuthorization.Api.Configurations
{
    public static class DbConfigurationExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString, optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly("SaparAuthorization.Domain");
                });
            });
        }
    }
}
