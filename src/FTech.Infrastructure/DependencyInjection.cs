using FTech.Infrastructure.Data;
using FTech.Infrastructure.Repositories.Users;
using FTech.Infrastructure.Services.OTP;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FTech.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<AppDbContext>(options =>
                //options.UseSqlServer(configuration.GetConnectionString("Default")));
                options.UseNpgsql(configuration.GetConnectionString("postgresql")));

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //SMS
            services.AddScoped<ISMSService, SMSService>();

            return services;
        }
    }
}
