using FTech.Application.DataTransferObjects.Chats;
using FTech.Application.Extensions;
using FTech.Application.Mapper;
using FTech.Application.Services.Helpers;
using FTech.Application.ViewModels;
using FTech.Domain.Entities.Chats;
using FTech.Domain.Models.Paginations;
using FTech.Infrastructure.Repositories.Chats;
using FTech.Infrastructure.Repositories.ChatUsers;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FTech.Application.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IChatUserRepository _chatUserRepository;

        public ChatService(
            IChatRepository chatRepository,
            IHttpContextAccessor httpContextAccessor,
            IPasswordHasher passwordHasher,
            IChatUserRepository chatUserRepository)
        {
            _chatRepository = chatRepository;
            _httpContextAccessor = httpContextAccessor;
            _passwordHasher = passwordHasher;
            _chatUserRepository = chatUserRepository;
        }

        public async ValueTask<ChatViewModel> ClearChatMessagesAsync(Guid chatId)
        {
            var chat = await _chatRepository.SelectByIdWithDetailsAsync(
                expression: x => x.Id == chatId,
                includes: new string[] { nameof(Chat.Messages) });

            if (chat is null)
                throw new ValidationException("chat not found");

            chat.Messages.Clear();
            await _chatRepository.SaveChangesAsync();

            return chat.ToChatViewModel();
        }

        public async ValueTask<Guid> CreatePersonalChatAsync(PersonalChatCreationDTO personalChatCreationDTO)
        {
            var userId = GetUserIdFromHttpContext();
            var link = CreateLink(personalChatCreationDTO.UserId, userId);

            return await CreateChatAsync(link: link);
        }

        public ValueTask<ChatViewModel> ModifyChatAsync(ChatModificationDTO chatModificationDTO)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<ChatViewModel> RemoveChatAsync(Guid ChatId)
        {
            var chat = await _chatRepository.SelectByIdAsync(ChatId);

            if (chat is null)
                throw new ValidationException("chat not found");

            chat = await _chatRepository.RemoveAsync(chat);

            return chat.ToChatViewModel();
        }

        public async ValueTask<ChatViewModel> RetrieveChatByIdAsync(Guid ChatId)
        {
            var chat = await _chatRepository.SelectByIdWithDetailsAsync(
                expression: x => x.Id == ChatId,
                includes: new string[] { nameof(Chat.Users) });

            if (chat is null)
                throw new ValidationException("chat not found");

            return chat.ToChatViewModel();
        }

        public async ValueTask<List<ChatViewModel>> RetrieveChats(QueryParameter queryParameter)
        {
            var chats = (await _chatRepository.GetAllAsync())
                .Include(x => x.Users)
                .ToPagedList(
                    httpContext: _httpContextAccessor.HttpContext,
                    pageSize: queryParameter.Page.Size,
                    pageIndex: queryParameter.Page.Index
                );

            var chatList = chats
                .Select(x => x.ToChatViewModel()).ToList();

            return chatList;
        }

        private long GetUserIdFromHttpContext()
        {
            var stringValue = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (stringValue is null)
                throw new ValidationException("Can not get userId from HttpContext");

            return long.Parse(stringValue);
        }

        private string CreateLink(long user1Id, long user2Id)
        {
            var kichik = user1Id < user2Id ? user1Id : user2Id;
            var katta = user1Id > user2Id ? user1Id : user2Id;
            var linkstring = _passwordHasher.Encrypt(kichik.ToString(), katta.ToString());

            return linkstring;
        }

        private async ValueTask<Guid> CreateChatAsync(
            string? link = null)
        {
            Chat chat = null;
            if (link is not null)
            {
                chat = await _chatRepository
                    .SelectByIdWithDetailsAsync(
                        expression: user => user.Link == link,
                        includes: Array.Empty<string>());

                if (chat is not null)
                {
                    return chat.Id;
                }
            }

            chat = new Chat()
            {
                Link = link,
                //Title = title,
                CreatedAt = DateTime.UtcNow,
                OwnerId = GetUserIdFromHttpContext()
            };

            try
            {
                chat = await _chatRepository.AddAsync(chat);
            }
            catch (Exception ex)
            {
                throw new ValidationException("chat is not valid, error occurred adding", ex);
            }

            return chat.Id;
        }
    }
}
