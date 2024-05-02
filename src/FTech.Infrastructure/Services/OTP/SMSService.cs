using FTech.Domain.Models.SMS;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using System.Net.Http.Headers;
using System.Text;
namespace FTech.Infrastructure.Services.OTP;
public class SMSService : ISMSService
{
    private string TOKEN = string.Empty;
    private readonly string _email;
    private readonly string _secretKey;
    private readonly IConfiguration _configuration;

    public SMSService(IConfiguration configuration)
    {
        _configuration = configuration;
        _email = _configuration["SmsSettings:Email"];
        _secretKey = _configuration["SmsSettings:SecretKey"];
        GetToken();
    }

    public async ValueTask<SendResultSMS> SendOtpAsync(string phoneNumber)
    {
        int code = GetRandomCode();
        var sms = new SMSData()
        {
            mobile_phone = phoneNumber.Replace("+", ""),
            from = "4546",
            message = CreateSMS(code),
            callback_url = "https://eskiz.uz/sms"
        };

        using var httpClient = new HttpClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(sms),
            Encoding.UTF8, "application/json");

        var htm = new HttpRequestMessage(HttpMethod.Post, Constants.Send_SMS_URL);
        htm.Content = httpContent;
        htm.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);

        var httpResponse = await httpClient.SendAsync(htm);

        if (httpResponse.IsSuccessStatusCode)
        {
            var result = new SendResultSMS("Successfully sent!");
            result.Success = true;
            result.Code = code;
            return result;
        }
        else
        {
            var result = new SendResultSMS("Something went wrong!");
            result.Success = false;
            return result;
        }
    }

    private async Task<string> LoginAsync()
    {
        using var httpClient = new HttpClient();
        var data = new
        {
            email = _email,
            password = _secretKey
        };
        var httpContent = new StringContent(JsonConvert.SerializeObject(data),
            Encoding.UTF8, "application/json");
        var httpResponse = await httpClient.PostAsync(Constants.LOGIN_URL, httpContent);

        if (httpResponse.IsSuccessStatusCode)
        {
            var json = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SMSToken>(json).data.token;
        }
        else
        {
            return httpResponse.StatusCode.ToString();
        }
    }

    private void GetToken()
    {
        if (string.IsNullOrEmpty(TOKEN))
        {
            TOKEN = LoginAsync().Result;
        }
    }

    private int GetRandomCode()
    {
        Random random = new Random();
        return random.Next(10000, 99999);
    }

    private string CreateSMS(int code)
        => $"""- This is test from Eskiz""";

    public void Dispose()
        => GC.SuppressFinalize(this);

}
