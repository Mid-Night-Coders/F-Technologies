using FTech.Application.DataTransferObjects.Messages;
using FTech.Application.Services.Messages;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace FTech.Presentation.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;

        public ChatHub(IMessageService messageService)
            => _messageService = messageService;

        public async Task SendMessage(MessageCreationDTO messageCreationDTO)
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            messageCreationDTO.SenderId = long.Parse(userId);
            var message = await _messageService.CreateMessageAsync(messageCreationDTO);

            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
