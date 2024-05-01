using FTech.Application.Services.Auth;
using FTech.Application.Services.Helpers;
using FTech.Application.Services.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace FTech.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
