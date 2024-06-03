using FTech.Domain.Entities.Chats;
using FTech.Infrastructure.Repositories.Base;

using System.Linq.Expressions;

namespace FTech.Infrastructure.Repositories.Chats
{
    public interface IChatRepository : IBaseRepository<Chat>
    {
        ValueTask<Chat> SelectByIdWithDetailsAsync(
            Expression<Func<Chat, bool>> expression,
            string[] includes);
    }
}
