using FTech.Domain.Entities.Auth;
using FTech.Infrastructure.Repositories.Base;

namespace FTech.Infrastructure.Repositories.Drivers
{
    public interface IDriverRepostory : IBaseRepository<Driver>
    {
        ValueTask<Driver> GetByPhoneNumberAsync(string phoneNumber);
        ValueTask<Driver> GetByLicenseNumberAsync(string licenseNumber);
    }
}
