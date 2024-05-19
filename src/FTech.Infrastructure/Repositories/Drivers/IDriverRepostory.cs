using FTech.Domain.Entities.Auth;
using FTech.Infrastructure.Repositories.Base;

namespace FTech.Infrastructure.Repositories.Drivers
{
    public interface IDriverRepostory : IBaseRepository<Driver>
    {
        ValueTask<Driver> GetByLicenseNumberAsync(string licenseNumber);
    }
}
