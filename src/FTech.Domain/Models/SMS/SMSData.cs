namespace FTech.Domain.Models.SMS;

public class SMSData
{
    public string mobile_phone { get; set; } = string.Empty;
    public string message { get; set; } = string.Empty;
    public string from { get; set; } = string.Empty;
    public string callback_url { get; set; } = string.Empty;
}