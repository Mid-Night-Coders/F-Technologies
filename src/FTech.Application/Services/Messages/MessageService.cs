using FTech.Application.DataTransferObjects.Messages;
using FTech.Application.Extensions;
using FTech.Application.Mapper;
using FTech.Application.ViewModels;
using FTech.Domain.Entities.Chats;
using FTech.Domain.Exceptions;
using FTech.Domain.Models.Paginations;
using FTech.Infrastructure.Repositories.Messages;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

namespace FTech.Application.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageService(
            IMessageRepository messageRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _messageRepository = messageRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async ValueTask<MessageViewModel> CreateMessageAsync(MessageCreationDTO messageCreationDTO)
        {
            var message = new Message()
            {
                SenderId = messageCreationDTO.SenderId,
                Text = messageCreationDTO.Text,
                //ParentId = messageCreationDTO.ParentId,
                CreatedAt = DateTime.UtcNow
            };

            try
            {
                message = await _messageRepository.AddAsync(message);
            }
            catch (Exception ex)
            {
                throw new ValidationException("message is not valid");
            }

            message = await _messageRepository.SelectByIdWithDetailsAsync(
                expression: x => x.Id == message.Id,
                includes: new string[] {/* nameof(Message.Parent),*/ nameof(Message.Sender) });

            return message.ToMessageViewModel();
        }

        public ValueTask<MessageViewModel> ModifyMessageAsync(MessageModificationDTO messageModificationDTO)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<MessageViewModel> RemoveMessageAsync(Guid messageId)
        {
            var message = await _messageRepository.SelectByIdAsync(messageId);

            if (message is null)
                throw new ValidationException("Message not found");

            var result = await _messageRepository.RemoveAsync(message);

            return result.ToMessageViewModel();
        }

        public async ValueTask<MessageViewModel> RetrieveMessageByIdAsync(Guid messageId)
        {
            var message = await _messageRepository.SelectByIdAsync(messageId);

            if (message is null)
                throw new ValidationException("Message not found");

            return message.ToMessageViewModel();
        }

        public async ValueTask<List<MessageViewModel>> RetrieveMessagesByChatIdAsync(QueryParameter queryParameter, Guid chatId)
        {
            var messages = (await _messageRepository.GetAllAsync())
                .Include(x => x.Sender)
               // .Include(x => x.Parent)
                .Where(x => x.SenderId == GetUserIdFromHttpContext())
                .AsNoTracking()
                .ToPagedList(
                    httpContext: _httpContextAccessor.HttpContext,
                    pageSize: queryParameter.Page.Size,
                    pageIndex: queryParameter.Page.Index
            );

            return messages.Select(x => x.ToMessageViewModel()).ToList();
        }

        public long GetUserIdFromHttpContext()
        {
            var userIdString = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

            return long.Parse(userIdString);
        }
    }
}
