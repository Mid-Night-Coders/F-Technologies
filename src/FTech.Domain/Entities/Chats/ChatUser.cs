using FTech.Domain.Entities.Auth;
using FTech.Domain.Entities.Common;

namespace FTech.Domain.Entities.Chats
{
    public class ChatUser : Auditable<Guid>
    {
        public long UserId { get; set; }
        public Guid ChatId { get; set; }

        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
