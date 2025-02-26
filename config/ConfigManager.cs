using Microsoft.Extensions.Configuration;

namespace selenium.testproject.examples.templates.config
{
    public class ConfigManager
    {
        private static IConfigurationRoot _configuration;

        static ConfigManager()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            _configuration = builder.Build();
        }

        public static string GetValue(string key)
        {
            return _configuration[key] ?? throw new ArgumentException($"Configuration key '{key}' not found.");
        }
    }
}