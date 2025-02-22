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

    class SeleniumDrivers
    {
        public IWebDriver Driver { get; set; }

        public SeleniumDrivers(BrowserType browser = BrowserType.Edge, bool remote = false)
        {
            if (remote)
            {
                var uri = "http://localhost:4444";
                ICapabilities capabilities;
                switch (browser)
                {
                    case BrowserType.Chrome:
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--start-maximized");
                        chromeOptions.AddArgument("--disable-notifications");
                        if (Environment.GetEnvironmentVariable("Headless") == "true")
                        {
                            chromeOptions.AddArgument("--headless");
                        }
                        capabilities = chromeOptions.ToCapabilities();
                        break;
                    case BrowserType.Firefox:
                        var firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArgument("--start-maximized");
                        firefoxOptions.AddArgument("--disable-notifications");
                        if (Environment.GetEnvironmentVariable("Headless") == "true")
                        {
                            firefoxOptions.AddArgument("--headless");
                        }
                        capabilities = firefoxOptions.ToCapabilities();
                        break;
                    case BrowserType.Edge:
                        var edgeOptions = new EdgeOptions();
                        edgeOptions.AddArgument("--start-maximized");
                        if (Environment.GetEnvironmentVariable("Headless") == "true")
                        {
                            edgeOptions.AddArgument("--headless");
                        }
                        capabilities = edgeOptions.ToCapabilities();
                        break;
                    default:
                        throw new ArgumentException($"Browser '{browser}' is not supported for remote execution.");
                }
                var commandTimeout = TimeSpan.FromMinutes(5);
                Driver = new RemoteWebDriver(new Uri(uri), capabilities, commandTimeout);
            }
            else
            {
                switch (browser)
                {
                    case BrowserType.Chrome:
                        Driver = ChromeDriverSetup();
                        break;
                    case BrowserType.Firefox:
                        Driver = FirefoxDriverSetup();
                        break;
                    case BrowserType.Edge:
                        Driver = EdgeDriverSetup();
                        break;
                    default:
                        throw new ArgumentException($"Browser '{browser}' is not supported.");
                }
            }
        }

        public IWebDriver EdgeDriverSetup()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");
            if (Environment.GetEnvironmentVariable("Headless") == "true")
            {
                options.AddArgument("--headless");
            }
            return new EdgeDriver(options);

        }
        public IWebDriver FirefoxDriverSetup()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            if (Environment.GetEnvironmentVariable("Headless") == "true")
            {
                options.AddArgument("--headless");
            }
            return new FirefoxDriver(options);

        }
        public IWebDriver ChromeDriverSetup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            if (Environment.GetEnvironmentVariable("Headless") == "true")
            {
                options.AddArgument("--headless");
            }
            return new ChromeDriver(options);
        }

        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                Driver = null;
            }

        }
    }
}
