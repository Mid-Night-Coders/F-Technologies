using FTech.Application.DataTransferObjects.ChatUsers;
using FTech.Domain.Entities.Chats;
using FTech.Infrastructure.Repositories.ChatUsers;

using Microsoft.AspNetCore.Http;

namespace FTech.Application.Services.ChatUsers
{
    public class ChatUserService : IChatUserService
    {
        private readonly IChatUserRepository _chatUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatUserService(
            IChatUserRepository chatUserRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _chatUserRepository = chatUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async ValueTask<ChatUser> AddChatMemberAsync(ChatUserCreationDTO chatUserCreationDTO)
        {
            var chatUser = new ChatUser
            {
                UserId = chatUserCreationDTO.UserId,
                ChatId = chatUserCreationDTO.ChatId,
            };

            return await _chatUserRepository.AddAsync(chatUser);
        }
    }
}
