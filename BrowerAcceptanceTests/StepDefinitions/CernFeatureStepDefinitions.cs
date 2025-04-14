using BrowerAcceptanceTests.Support;
using OpenQA.Selenium;

namespace BrowerAcceptanceTests.StepDefinitions
{
    [Binding]
    public class CernFeatureStepDefinitions
    {
        private readonly PageDriver _pageDriver;
        private IWebElement? _toolbar;

        public CernFeatureStepDefinitions(PageDriver pageDriver)
        {
            _pageDriver = pageDriver;
        }

        [Given("I load the page of {string}")]
        [When("I load the page of {string}")]
        public void WhenILoadThePageOf(string url)
        {
            _pageDriver.GoTo(url);
        }

        [Then("The page title is {string}")]
        public void ThenThePageTitleIs(string title)
        {
            Assert.Equal(title, _pageDriver.Title());
        }

        [When("I retrieve the top ribbon")]
        public void WhenIRetrieveTheTopRibbon()
        {
            _toolbar = _pageDriver.GetElement("cern-toolbar");
            Assert.NotNull(_toolbar);
        }

        [Then("The the text of the first link is {string}")]
        public void ThenTheTheTitleOfTheFirstLinkIs(string text)
        {
            if (_toolbar == null)
            {
                Assert.Fail("Toolbar not found");
            }
            var h1 = _toolbar.FindElements(By.XPath("h1"));
            var a = h1[0].FindElement(By.XPath("a"));

            Assert.Equal(text, a.Text);
        }

    }
}
