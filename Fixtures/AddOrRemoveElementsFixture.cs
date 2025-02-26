using OpenQA.Selenium;
using selenium.testproject.examples.templates.config;
using selenium.testproject.examples.templates.Drivers;
using selenium.testproject.examples.templates.Enums;
using selenium.testproject.examples.templates.StepDefinitions;

namespace selenium.testproject.examples.templates.Fixtures
{
    public class AddOrRemoveElementsFixture : IDisposable
    {
        public readonly IWebDriver Driver;
        public readonly AddOrRemoveElementsSteps Steps;

        public AddOrRemoveElementsFixture()
        {
            Driver = new SeleniumDrivers().Driver;
            var url = ConfigManager.GetValue("TestEnv:BaseUrl");
            Driver.Navigate().GoToUrl(url);
            Steps = new AddOrRemoveElementsSteps(Driver);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}