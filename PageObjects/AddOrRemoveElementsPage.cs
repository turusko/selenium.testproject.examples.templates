using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium.testproject.examples.templates.PageObjects
{
    public class AddOrRemoveElementsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private By ElementsButton = By.XPath("//button[text()=\"Add Element\"]");
        private By DeleteButton = By.XPath("//button[text()=\"Delete\"]");


        public AddOrRemoveElementsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        }

        public bool IsAddElementsButtonVisible()
        {
            return _driver.FindElement(ElementsButton).Displayed;
        }

        public void ClickAddElementsButton()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ElementsButton));
            _driver.FindElement(ElementsButton).Click();
        }

        public bool IsDeleteButtonVisible()
        {
            return _driver.FindElement(DeleteButton).Displayed;
        }
    }
}
