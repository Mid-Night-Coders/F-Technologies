namespace FTech.Domain.Models.SMS;

public class SendResultSMS
{
    public int Code { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public SendResultSMS(string message)
    {
        Message = message;
    }
}
