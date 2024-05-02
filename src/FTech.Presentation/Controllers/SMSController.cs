using FTech.Infrastructure.Services.OTP;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Twilio.TwiML.Messaging;

namespace FTech.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService sms_service;

        public SMSController(ISMSService sms_service)
        {
            this.sms_service = sms_service;
        }

        [HttpPost]
        public async Task<IActionResult> SendSMSAsync([FromBody] string phoneNumber)
        {
            var result = await sms_service.SendOtpAsync(phoneNumber);
            if (result.Success)
            {
                return Ok("SMS muvaffaqiyatli yuborildi.");
            }
            else
            {
                return Ok("SMS yuborishda xatolik yuz berdi.");
            }
        }
    }
}
