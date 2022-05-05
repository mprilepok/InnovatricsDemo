using Microsoft.Extensions.Configuration;

namespace InnovatricsDemo.Core.Helpers
{
    public class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        public static string GetStrValue(string section, string key)
        {
            LoadConfiguration();
            return _configuration.GetSection(section)[key];
        }

        public static IConfiguration GetConfiguration()
        {
            LoadConfiguration();
            return _configuration;
        }

        public static string GetStrValue(string key)
        {
            LoadConfiguration();
            return _configuration[key];
        }

        public static int GetIntValue(string section, string key)
        {
            LoadConfiguration();
            int.TryParse(_configuration.GetSection(section)[key], out int value);
            return value;
        }

        public static int GetIntValue(string key)
        {
            LoadConfiguration();
            int.TryParse(_configuration[key], out int value);
            return value;
        }

        public static bool GetBoolValue(string key)
        {
            LoadConfiguration();
            bool.TryParse(_configuration[key], out bool value);
            return value;
        }

        private static void LoadConfiguration()
        {
            if (_configuration == null)
            {
                _configuration = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json", true, true)
                       .Build();
            }
        }
    }
}
