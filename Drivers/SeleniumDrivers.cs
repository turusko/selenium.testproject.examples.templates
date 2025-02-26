using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using selenium.testproject.examples.templates.Enums;
using OpenQA.Selenium.Remote;
using selenium.testproject.examples.templates.config;

namespace selenium.testproject.examples.templates.Drivers
{
    internal class SeleniumDrivers
    {
        public readonly IWebDriver? Driver;
        private readonly bool _headless;

        public SeleniumDrivers()
        {
            _headless = ConfigManager.GetValue("DriverConfig:Headless") == "True";
            BrowserType browser;
            var configBrowser = ConfigManager.GetValue("DriverConfig:Browser");
            var remote = ConfigManager.GetValue("DriverConfig:Remote:Enabled") == "True";

            switch (configBrowser)
            {
                case "Chrome":
                    browser = BrowserType.Chrome;
                    break;

                case "Firefox":
                    browser = BrowserType.Firefox;
                    break;

                case "Edge":
                    browser = BrowserType.Edge;
                    break;

                default:
                    throw new ArgumentException($"Browser '{configBrowser}' is not supported.");
            }

            if (remote)
            {
                var uri = ConfigManager.GetValue("DriverConfig:Remote:GridURL");
                int timeout = int.Parse(ConfigManager.GetValue("DriverConfig:Remote:RemoteTimeoutMinutes"));
                var options = GetOptions(browser);
                var commandTimeout = TimeSpan.FromMinutes(timeout);
                Driver = new RemoteWebDriver(new Uri(uri), options.ToCapabilities(), commandTimeout);
            }
            else
            {
                Driver = SetupLocalDriver(browser);
            }
        }

        private DriverOptions GetOptions(BrowserType browser)
        {
            DriverOptions options = browser switch
            {
                BrowserType.Chrome => new ChromeOptions(),
                BrowserType.Firefox => new FirefoxOptions(),
                BrowserType.Edge => new EdgeOptions(),
                _ => throw new ArgumentException($"Browser '{browser}' is not supported.")
            };

            if (options is ChromeOptions chromeOptions)
            {
                chromeOptions.AddArgument("--start-maximized");
                chromeOptions.AddArgument("--disable-notifications");
                if (_headless)
                {
                    chromeOptions.AddArgument("--headless");
                }
            }
            else if (options is FirefoxOptions firefoxOptions)
            {
                firefoxOptions.AddArgument("--start-maximized");
                firefoxOptions.AddArgument("--disable-notifications");
                if (_headless)
                {
                    firefoxOptions.AddArgument("--headless");
                }
            }
            else if (options is EdgeOptions edgeOptions)
            {
                edgeOptions.AddArgument("--start-maximized");
                edgeOptions.AddArgument("--disable-notifications");
                if (_headless)
                {
                    edgeOptions.AddArgument("--headless");
                }
            }

            return options;
        }

        private IWebDriver SetupLocalDriver(BrowserType browser)
        {
            new DriverManager().SetUpDriver(browser switch
            {
                BrowserType.Chrome => new ChromeConfig(),
                BrowserType.Firefox => new FirefoxConfig(),
                BrowserType.Edge => new EdgeConfig(),
                _ => throw new ArgumentException($"Browser '{browser}' is not supported.")
            });

            var options = GetOptions(browser);

            return browser switch
            {
                BrowserType.Chrome => new ChromeDriver((ChromeOptions)options ?? throw new InvalidCastException("Invalid ChromeOptions.")),
                BrowserType.Firefox => new FirefoxDriver((FirefoxOptions)options ?? throw new InvalidCastException("Invalid FirefoxOptions.")),
                BrowserType.Edge => new EdgeDriver((EdgeOptions)options ?? throw new InvalidCastException("Invalid EdgeOptions.")),
                _ => throw new ArgumentException($"Browser '{browser}' is not supported.")
            };
        }

        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}