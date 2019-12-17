using OpenQA.Selenium;
using System.Threading;
using TestFramework.Areas._5element.Infrastructure;
using TestFramework.Areas._5element.Pages.Base;

namespace TestFramework.Areas._5element.Pages
{
    public class DeliveryPage : FiveElementPageBase
    {
        private const string firstTitleByXPath = "//div[@class='breadcrumbs']/a[1]";
        private const string secondTitleByXPath = "//div[@class='breadcrumbs']/a[2]";
        private const string thirdTitleByXPath = "//div[@class='breadcrumbs']/span";

        public DeliveryPage(IWebDriver driver, string routeFrom)
        {
            _driver = driver;
            switch (routeFrom)
            {
                case Paths.HomePageURL:
                    InitPageFromHomePage();
                    break;
            }
        }

        private void InitPageFromHomePage()
        {
            _driver.FindElement(By.XPath("//*[@class='header-nav-list']/li[2]/a")).Click();
            Thread.Sleep(1000);
        }

        public string GetBreadcrumbTitle()
        {
            var firstTitle = _driver.FindElement(By.XPath(firstTitleByXPath)).GetAttribute("title");
            var secondTitle = _driver.FindElement(By.XPath(secondTitleByXPath)).GetAttribute("title");
            var thirdTitle = _driver.FindElement(By.XPath(thirdTitleByXPath)).GetAttribute("innerHTML");
            return $"{firstTitle} {secondTitle} {thirdTitle}";
        }
    }
}
