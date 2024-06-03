using FTech.Domain.Entities.Chats;
using FTech.Domain.Entities.Common;
using FTech.Domain.Entities.Drivers;
using FTech.Domain.Enums;

namespace FTech.Domain.Entities.Auth
{
    public class User : Auditable<long>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Salt { get; set; }
        public string? PasswordHash { get; set; }

        public Role Role { get; set; }

        public Driver? Driver { get; set; }
        public virtual List<Message> Messages { get; set; }
        public virtual IEnumerable<ChatUser> Chats { get; set; }
    }
}
   