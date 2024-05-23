using FTech.Application.Mappings;
using FTech.Application.Services.Cars;
using FTech.Application.Services.Categories;
using FTech.Infrastructure.Repositories.Base;
using FTech.Infrastructure.Services.Cars;

namespace FTech.Presentation.Extentions
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddCustomExtention(this IServiceCollection services)
        {
            // Repository
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Car Service
            services.AddScoped<ICarService, CarService>();


            // Category service
            services.AddScoped<ICategoryService , CategoryService>();

            // automapper
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
