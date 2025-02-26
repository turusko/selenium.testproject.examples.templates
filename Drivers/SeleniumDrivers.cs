using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using selenium.testproject.examples.templates.Enums;
using OpenQA.Selenium.Remote;

namespace selenium.testproject.examples.templates.Drivers
{
    internal class SeleniumDrivers
    {
        public IWebDriver? Driver { get; set; }

        public SeleniumDrivers(BrowserType browser = BrowserType.Edge, bool remote = false, int remoteDriverTimeout = 5)
        {
            if (remote)
            {
                var uri = "http://localhost:4444";
                var options = GetOptions(browser);
                var commandTimeout = TimeSpan.FromMinutes(remoteDriverTimeout);
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
                if (Environment.GetEnvironmentVariable("Headless") == "true")
                {
                    chromeOptions.AddArgument("--headless");
                }
            }
            else if (options is FirefoxOptions firefoxOptions)
            {
                firefoxOptions.AddArgument("--start-maximized");
                firefoxOptions.AddArgument("--disable-notifications");
                if (Environment.GetEnvironmentVariable("Headless") == "true")
                {
                    firefoxOptions.AddArgument("--headless");
                }
            }
            else if (options is EdgeOptions edgeOptions)
            {
                edgeOptions.AddArgument("--start-maximized");
                edgeOptions.AddArgument("--disable-notifications");
                if (Environment.GetEnvironmentVariable("Headless") == "true")
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