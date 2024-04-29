using FTech.Domain.Entities.Auth;
using FTech.Infrastructure.Data;
using FTech.Infrastructure.Repositories.Base;

namespace FTech.Infrastructure.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
