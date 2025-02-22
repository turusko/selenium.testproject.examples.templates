using selenium.testproject.examples.templates.Fixtures;
using selenium.testproject.examples.templates.PageObjects;


namespace selenium.testproject.examples.templates.Tests
{
    public class AddOrRemoveElementsTests : IClassFixture<AddOrRemoveElementsFixture>

    {
        private readonly AddOrRemoveElementsFixture _fixture;
        public AddOrRemoveElementsTests(AddOrRemoveElementsFixture fixture) : base()
        {
            _fixture = fixture;

        }
        [Fact]
        public void ClickingTheAddElementCreatesANewButton()
        {
            _fixture.Steps.GivenTheAddElementsButtonIsVisible();
            _fixture.Steps.WhenIClickTheAddElementsButton();
            _fixture.Steps.ThenTheDeleteButtonIsVisible();
        }

    }
}
