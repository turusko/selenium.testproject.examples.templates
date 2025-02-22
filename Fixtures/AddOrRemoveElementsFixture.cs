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
    public class AddOrRemoveElementsFixture
    {
        protected readonly IWebDriver _driver;
        protected readonly AddOrRemoveElementsSteps _steps;

        public AddOrRemoveElementsFixture() 
        { 

            _driver =  new SeleniumDrivers(BrowserType.Edge).Driver;
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
            _steps = new AddOrRemoveElementsSteps(_driver);

        } 
    }
}
