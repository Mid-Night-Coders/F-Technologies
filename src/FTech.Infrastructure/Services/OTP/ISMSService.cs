using FTech.Domain.Models.SMS;

namespace FTech.Infrastructure.Services.OTP;

public interface ISMSService
{
    ValueTask<SendResultSMS> SendOtpAsync(string phoneNumber);
}
