using Microsoft.Extensions.Configuration;

namespace Numiteq.Common.Configuration
{
    public static class IConfigurationExtensions
    {
        public static string GetString(this IConfiguration configuration, string key, string defaultValue = null)
        {
            string value = configuration.GetSection(key)?.Value;
            return value ?? defaultValue;
        }

        public static int GetInt(this IConfiguration configuration, string key, int defaultValue = 0)
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