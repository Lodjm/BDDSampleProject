using OpenQA.Selenium;

namespace BrowerAcceptanceTests.Support
{
    public class PageDriver
    {
        private readonly BrowserContext _browserContext;

        public PageDriver(BrowserContext browserContext)
        {
            _browserContext = browserContext;
        }

        public void GoTo(string url)
        {
            _browserContext.NavigateTo(url, false);
        }

        public string Title()
        {
            return _browserContext.Driver.Title;
        }

        public IWebElement GetElement(string id)
        {
            return _browserContext.Driver.FindElement(By.Id(id));
        }
    }
}
