using FTech.Domain.Entities.Auth;
using FTech.Domain.Entities.Common;

namespace FTech.Domain.Entities.Chats
{
    public class Chat : Auditable<Guid>
    {
        public string? Link { get; set; }
        public string? Title { get; set; }
        public long? OwnerId { get; set; }

        public virtual User Owner { get; set; }
        public virtual IEnumerable<ChatUser> Users { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}
