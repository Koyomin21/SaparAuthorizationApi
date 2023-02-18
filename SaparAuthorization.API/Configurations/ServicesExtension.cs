using SaparAuthorization.Business.Services.Users;
using SaparAuthorization.Business.Services.Authentication;
using SaparAuthorization.Domain.Repositories;

namespace SaparAuthorization.Api.Configurations
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

    }
}
