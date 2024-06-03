using FTech.Domain.Entities.Auth;
using FTech.Domain.Entities.Chats;

namespace FTech.Application.ViewModels
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; }
        public Message Parent { get; set; }
    }
}
