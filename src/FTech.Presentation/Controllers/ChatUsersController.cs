using FTech.Application.DataTransferObjects.ChatUsers;
using FTech.Application.Services.ChatUsers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTech.Presentation.Controllers
{
    [Route("api/connections")]
    [ApiController]
    public class ChatUsersController : ControllerBase
    {
        private readonly IChatUserService _chatUserService;

        public ChatUsersController(IChatUserService chatUserService)
            => _chatUserService = chatUserService;

        [HttpPost("add-member")]
        public async Task<IActionResult> PostChatUserAsync(ChatUserCreationDTO chatUserCreationDTO)
           => Ok(await _chatUserService.AddChatMemberAsync(chatUserCreationDTO));
    }
}
