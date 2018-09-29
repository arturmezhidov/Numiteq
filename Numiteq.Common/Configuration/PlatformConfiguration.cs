using Microsoft.Extensions.Configuration;

namespace Numiteq.Common.Configuration
{
    public static class PlatformConfiguration
    {
        private const string CONFIGURATION_SECTION_NAME = "Configuration";

        public static string UploadsFolderPath;
        public static string SmtpServerName;
        public static int SmtpServerPort;
        public static string SmtpEmailAddress;
        public static string SmtpEmailPassword;

        public static void Init(IConfiguration configuration)
        {
            IConfigurationSection configurationSection = configuration.GetSection(CONFIGURATION_SECTION_NAME);

            UploadsFolderPath = configurationSection.GetString("UploadsFolderPath", "/uploads/");
            SmtpServerName = configurationSection.GetString("Smtp:SmtpServerName", "smtp.gmail.com");
            SmtpServerPort = configurationSection.GetInt("Smtp:SmtpServerPort", 587);
            SmtpEmailAddress = configurationSection.GetString("Smtp:SmtpEmailAddress", "numiteq.noreply@gmail.com");
            SmtpEmailPassword = configurationSection.GetString("Smtp:SmtpEmailPassword", "1q2w#E$R");
        }
    }
}