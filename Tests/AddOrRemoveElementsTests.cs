using selenium.testproject.examples.templates.Fixtures;
using selenium.testproject.examples.templates.PageObjects;


namespace selenium.testproject.examples.templates.Tests
{
    public class AddOrRemoveElementsTests : AddOrRemoveElementsFixture
    {
        public AddOrRemoveElementsTests() : base()
        {

        }
        [Fact]
        public void ClickingTheAddElementCreatesANewButton()
        {
            _steps.GivenTheAddElementsButtonIsVisible();
            _steps.WhenIClickTheAddElementsButton();
            _steps.ThenTheDeleteButtonIsVisible();
        }
    }
}
