using SaparAuthorization.Domain.Repositories;

namespace SaparAuthorization.Api.Configurations
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
