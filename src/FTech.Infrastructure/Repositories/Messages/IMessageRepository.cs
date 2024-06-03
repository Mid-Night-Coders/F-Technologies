using FTech.Domain.Entities.Chats;
using FTech.Infrastructure.Repositories.Base;

using System.Linq.Expressions;

namespace FTech.Infrastructure.Repositories.Messages
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        ValueTask<Message> SelectByIdWithDetailsAsync(
           Expression<Func<Message, bool>> expression,
           string[] includes);
    }
}
