using FTech.Application.DataTransferObjects.ChatUsers;
using FTech.Domain.Entities.Chats;

namespace FTech.Application.Services.ChatUsers
{
    public interface IChatUserService
    {
        ValueTask<ChatUser> AddChatMemberAsync(ChatUserCreationDTO chatUserCreationDTO);
    }
}
