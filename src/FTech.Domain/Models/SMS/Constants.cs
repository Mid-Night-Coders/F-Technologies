﻿namespace FTech.Domain.Models.SMS;

public static class Constants
{
    public static string BASE_URL = "https://notify.eskiz.uz/api/";
    public static string LOGIN_URL = BASE_URL + "auth/login";
    public static string Send_SMS_URL = BASE_URL + "message/sms/send";
}