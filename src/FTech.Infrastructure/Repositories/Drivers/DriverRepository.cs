using FTech.Domain.Entities.Auth;
using FTech.Infrastructure.Data;
using FTech.Infrastructure.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace FTech.Infrastructure.Repositories.Drivers
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepostory
    {
        private readonly AppDbContext _appDbContext;
        public DriverRepository(AppDbContext appDbContext) : base(appDbContext)
            => _appDbContext = appDbContext;

        public async ValueTask<Driver> GetByLicenseNumberAsync(string licenseNumber)
        {
            var driver = await _appDbContext.Drivers
                .FirstOrDefaultAsync(x => x.LicenseNumber == licenseNumber);

            return driver;
        }
    }
}
