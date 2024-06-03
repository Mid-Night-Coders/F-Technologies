using FTech.Application.DataTransferObjects.Messages;
using FTech.Application.ViewModels;
using FTech.Domain.Models.Paginations;

namespace FTech.Application.Services.Messages
{
    public interface IMessageService
    {
        ValueTask<MessageViewModel> CreateMessageAsync(MessageCreationDTO messageCreationDTO);
        ValueTask<List<MessageViewModel>> RetrieveMessagesByChatIdAsync(QueryParameter queryParameter, Guid chatId);
        ValueTask<MessageViewModel> RetrieveMessageByIdAsync(Guid messageId);
        ValueTask<MessageViewModel> ModifyMessageAsync(MessageModificationDTO messageModificationDTO);
        ValueTask<MessageViewModel> RemoveMessageAsync(Guid messageId);
    }
}
