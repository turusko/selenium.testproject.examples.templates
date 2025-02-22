using FluentAssertions;
using OpenQA.Selenium;
using selenium.testproject.examples.templates.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium.testproject.examples.templates.StepDefinitions
{
    public class AddOrRemoveElementsSteps
    {
        private readonly AddOrRemoveElementsPage _page;
        public AddOrRemoveElementsSteps(IWebDriver driver) 
        {
            _page = new AddOrRemoveElementsPage(driver);
        }

        public void GivenTheAddElementsButtonIsVisible()
        {
            _page.IsAddElementsButtonVisible().Should().BeTrue();
        }
        public void WhenIClickTheAddElementsButton()
        {
            _page.ClickAddElementsButton();
        }

        public void ThenTheDeleteButtonIsVisible()
        {
            _page.IsDeleteButtonVisible().Should().BeTrue();
        }
    }
}
