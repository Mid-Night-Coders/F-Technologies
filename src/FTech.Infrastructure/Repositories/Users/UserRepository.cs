using FTech.Domain.Entities.Auth;
using FTech.Infrastructure.Data;
using FTech.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FTech.Infrastructure.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
            => _appDbContext = appDbContext;

        public async ValueTask<User> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _appDbContext.Users
                .FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }
    }
}
