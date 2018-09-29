using Microsoft.Extensions.Configuration;

namespace Numiteq.Common.Configuration
{
    public static class PlatformConfiguration
    {
        public static string UploadsFolderPath;
        public static string SmtpServerName;
        public static int SmtpServerPort;
        public static string SmtpEmailAddress;
        public static string SmtpEmailPassword;

        public static void Init(IConfiguration configuration)
        {
            UploadsFolderPath = configuration.GetString("UploadsFolderPath", "/uploads/");
            SmtpServerName = configuration.GetString("SmtpServerName", "smtp.gmail.com");
            SmtpServerPort = configuration.GetInt("SmtpServerPort", 587);
            SmtpEmailAddress = configuration.GetString("SmtpEmailAddress", "numiteq.noreply@gmail.com");
            SmtpEmailPassword = configuration.GetString("SmtpEmailPassword", "1q2w#E$R");
        }

        static string GetString(this IConfiguration configuration, string key, string defaultValue = null)
        {
            string value = configuration.GetSection(key)?.Value;
            return value ?? defaultValue;
        }
        static int GetInt(this IConfiguration configuration, string key, int defaultValue = 0)
        {
            string valueStr = configuration.GetString(key);
            if (int.TryParse(valueStr, out int value))
            {
                return value;
            }
            return defaultValue;
        }
    }
}