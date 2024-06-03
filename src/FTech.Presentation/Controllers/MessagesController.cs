using FTech.Application.DataTransferObjects.Messages;
using FTech.Application.Services.Messages;
using FTech.Domain.Models.Paginations;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FTech.Presentation.Controllers
{
    [Route("api/massages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("create-message")]
        public async ValueTask<IActionResult> CreateMessageAsync([FromBody] MessageCreationDTO messageCreationDTO)
        {
            var message = await _messageService.CreateMessageAsync(messageCreationDTO);

            return Ok(message);
        }

        [HttpDelete("delete-message/{messageId}")]
        public async ValueTask<IActionResult> DeleteMessageAsync(Guid messageId)
        {
            await _messageService.RemoveMessageAsync(messageId);

            return Ok();
        }

        [HttpPut("edit-message")]
        public async ValueTask<IActionResult> UpdateMessageAsync([FromBody] MessageModificationDTO messageEditDTO)
        {
            var message = await _messageService.ModifyMessageAsync(messageEditDTO);

            return Ok(message);
        }

        [HttpGet("retrieve-message/{messageId}")]
        public async ValueTask<IActionResult> GetMessageAsync(Guid messageId)
        {
            var message = await _messageService.RetrieveMessageByIdAsync(messageId);

            return Ok(message);
        }

        [HttpGet("retrieve-message-chat")]
        public async ValueTask<IActionResult> RetrieveMessagesByChatAsync([FromQuery] QueryParameter parameter, Guid chatId)
        {
            var messages = await _messageService.RetrieveMessagesByChatIdAsync(parameter, chatId);

            return Ok(messages);
        }
    }
}
