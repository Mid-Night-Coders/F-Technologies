using FTech.Application.DataTransferObjects.Chats;
using FTech.Application.ViewModels;
using FTech.Domain.Models.Paginations;

namespace FTech.Application.Services.Chats
{
    public interface IChatService
    {
        ValueTask<Guid> CreatePersonalChatAsync(PersonalChatCreationDTO personalChatCreationDTO);
        ValueTask<List<ChatViewModel>> RetrieveChats(QueryParameter queryParameter);
        ValueTask<ChatViewModel> RetrieveChatByIdAsync(Guid ChatId);
        ValueTask<ChatViewModel> ModifyChatAsync(ChatModificationDTO chatModificationDTO);
        ValueTask<ChatViewModel> RemoveChatAsync(Guid ChatId);
        ValueTask<ChatViewModel> ClearChatMessagesAsync(Guid chatId);
    }
}
