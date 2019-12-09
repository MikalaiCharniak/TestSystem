using OpenQA.Selenium;
using TestFramework.Core.Abstractions;
using TestFramework.Areas._5element.Infrastructure;

namespace TestFramework.Areas._5element.Pages
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageUrl = Paths.HomePageURL;
        }

        public LaptopSectionPage GoToLaptopSectionPage() =>
    new LaptopSectionPage(_driver, PageUrl);

        public void GoToPage() =>
            _driver.Navigate().GoToUrl(PageUrl);
    }
}