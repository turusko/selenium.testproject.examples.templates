using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using selenium.testproject.examples.templates.Enums;

namespace selenium.testproject.examples.templates.Drivers
{

    class SeleniumDrivers
    {
        public IWebDriver Driver { get; set; }

        public SeleniumDrivers(BrowserType browser = BrowserType.Edge)
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

        public IWebDriver EdgeDriverSetup()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");

            return new EdgeDriver(options);

        }
        public IWebDriver FirefoxDriverSetup()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--headless");
            return new FirefoxDriver(options);

        }
        public IWebDriver ChromeDriverSetup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--headless");
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
