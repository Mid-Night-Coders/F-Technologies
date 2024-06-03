using FTech.Domain.Entities.Chats;
using FTech.Infrastructure.Data;
using FTech.Infrastructure.Repositories.Base;

namespace FTech.Infrastructure.Repositories.ChatUsers
{
    public class ChatUserRepository : BaseRepository<ChatUser>, IChatUserRepository
    {
        public ChatUserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
