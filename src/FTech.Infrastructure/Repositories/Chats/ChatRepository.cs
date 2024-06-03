using FTech.Domain.Entities.Chats;
using FTech.Infrastructure.Data;
using FTech.Infrastructure.Repositories.Base;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Twilio.TwiML.Voice;

namespace FTech.Infrastructure.Repositories.Chats
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        private readonly AppDbContext _appDbContext;
        public ChatRepository(AppDbContext appDbContext) : base(appDbContext)
            => _appDbContext = appDbContext;

        public async ValueTask<Chat> SelectByIdWithDetailsAsync(Expression<Func<Chat, bool>> expression, string[] includes)
        {
            IQueryable<Chat> entities = await GetAllAsync();

            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }

            return await entities.FirstOrDefaultAsync(expression);
        }
    }
}
