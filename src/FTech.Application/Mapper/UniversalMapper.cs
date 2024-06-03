using FTech.Application.ViewModels;
using FTech.Domain.Entities.Chats;

namespace FTech.Application.Mapper
{
    public static class UniversalMapper
    {
        public static MessageViewModel ToMessageViewModel(this Message message)
        {
            return new MessageViewModel()
            {
                Id = message.Id,
                Text = message.Text,
                //Parent = message.Parent,
                Sender = message.Sender,
            };
        }

        public static ChatViewModel ToChatViewModel(this Chat chat)
        {
            if (chat is null) throw new ArgumentNullException(nameof(chat));

            return new ChatViewModel()
            {
                Id = chat.Id,
                Title = chat.Title,
                Link = chat.Link,
                MembersCount = chat.Users is null ? 0 : chat.Users.Select(x => x.User).ToList().Count,
                OwnerId = chat.OwnerId,
                CreatedAt = chat.CreatedAt,
            };
        }
    }
}
