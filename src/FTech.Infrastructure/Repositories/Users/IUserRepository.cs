using FTech.Domain.Entities.Auth;
using FTech.Infrastructure.Repositories.Base;

namespace FTech.Infrastructure.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        ValueTask<User> GetByPhoneNumberAsync(string phoneNumber);
    }
}
