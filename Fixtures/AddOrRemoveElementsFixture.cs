using OpenQA.Selenium;
using selenium.testproject.examples.templates.Drivers;
using selenium.testproject.examples.templates.Enums;
using selenium.testproject.examples.templates.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium.testproject.examples.templates.Fixtures
{
    public class AddOrRemoveElementsFixture : IDisposable
    {
        public readonly IWebDriver Driver;
        public readonly AddOrRemoveElementsSteps Steps;

        public AddOrRemoveElementsFixture() 
        {

            Driver =  new SeleniumDrivers(BrowserType.Edge, remote:true).Driver;
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
            Steps = new AddOrRemoveElementsSteps(Driver);

        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
