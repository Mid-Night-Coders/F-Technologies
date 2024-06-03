using FTech.Application.DataTransferObjects.Chats;
using FTech.Application.Services.Chats;
using FTech.Domain.Models.Paginations;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTech.Presentation.Controllers
{
    [Route("api/chats")]
    [ApiController]
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatsController(IChatService chatService)
            => _chatService = chatService;

        [HttpPost("create-chat")]
        public async Task<IActionResult> PostPersonalChatAsync(PersonalChatCreationDTO chatCreationDTO)
            => Ok(await _chatService.CreatePersonalChatAsync(chatCreationDTO));

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetChatAsync(Guid chatId)
            => Ok(await _chatService.RetrieveChatByIdAsync(chatId));

        [HttpDelete("{chatId}")]
        public async Task<IActionResult> DeleteAsync(Guid chatId)
            => Ok(await _chatService.RemoveChatAsync(chatId));

        [HttpGet("all-chats")]
        public IActionResult GetAllChats([FromQuery] QueryParameter paginationParam)
            => Ok(_chatService.RetrieveChats(paginationParam));

        [HttpDelete("{chatId}/clear-chat")]
        public async Task<IActionResult> ClearChatMessagesAsync(Guid chatId)
            => Ok(await _chatService.ClearChatMessagesAsync(chatId));
    }
}
