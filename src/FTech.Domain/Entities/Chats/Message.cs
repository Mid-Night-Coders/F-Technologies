using FTech.Domain.Entities.Auth;
using FTech.Domain.Entities.Common;

namespace FTech.Domain.Entities.Chats
{
    public class Message : Auditable<Guid>
    {
        public string Text { get; set; }
        public long SenderId { get; set; }
        public Guid ChatId { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual User Sender { get; set; }
        public virtual Message Parent { get; set; }
        public virtual List<Message> Childrens { get; set; }
    }       
}