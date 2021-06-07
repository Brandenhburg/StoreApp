using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace StoreApp.Services
{
    public static class IdentityOptionService
    {
        public static void ConfigureIdentityOptions(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(configure =>
            {
                configure.Password.RequiredLength = 8;

                configure.Lockout.MaxFailedAccessAttempts = 5;

                configure.User.RequireUniqueEmail = true;
                configure.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            });
        }
    }
}
