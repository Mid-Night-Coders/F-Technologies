using FTech.Domain.Entities.Chats;
using FTech.Infrastructure.Data;
using FTech.Infrastructure.Repositories.Base;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FTech.Infrastructure.Repositories.Messages
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly AppDbContext _appDbContext;

        public MessageRepository(AppDbContext context) : base(context)
            => _appDbContext = context;

        public async ValueTask<Message> SelectByIdWithDetailsAsync(Expression<Func<Message, bool>> expression, string[] includes)
        {
            var query = _appDbContext.Messages.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
