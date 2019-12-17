using OpenQA.Selenium;
using TestFramework.Areas._5element.Infrastructure;
using TestFramework.Areas._5element.Pages.Base;

namespace TestFramework.Areas._5element.Pages
{
    public class HomePage : FiveElementPageBase
    {
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageUrl = Paths.HomePageURL;
        }

        public LaptopSectionPage GoToLaptopSectionPage() =>
    new LaptopSectionPage(_driver, PageUrl);

        public DeliveryPage GoToDeliveryPage() =>
            new DeliveryPage(_driver, PageUrl);

        public void GoToPage() =>
            _driver.Navigate().GoToUrl(PageUrl);
    }
}