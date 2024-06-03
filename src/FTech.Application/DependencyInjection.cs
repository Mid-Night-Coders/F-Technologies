using FTech.Application.Services.Auth;
using FTech.Application.Services.Chats;
using FTech.Application.Services.Helpers;
using FTech.Application.Services.JWT;
using FTech.Application.Services.Messages;
using FTech.Infrastructure.Repositories.Chats;
using FTech.Infrastructure.Repositories.ChatUsers;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FTech.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IChatUserRepository, ChatUserRepository>();

            return services;
        }
    }
}
