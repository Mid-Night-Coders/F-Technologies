namespace FTech.Domain.Models.SMS;

public class SMSToken
{
    public string message { get; set; } = string.Empty;
    public Data data { get; set; } = new Data();
    public string token_type { get; set; } = string.Empty;
}

public class Data
{
    public string token { get; set; } = string.Empty;
}

