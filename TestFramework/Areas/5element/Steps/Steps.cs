using OpenQA.Selenium;
using TestFramework.Areas._5element.Pages;
using TestFramework.Core.Driver;
using TestFramework.Core.Settings;

namespace TestFramework.Areas._5element.Steps
{
    public class Steps
    {
        private static IWebDriver _driver;

        public static void InitBrowser()
        {
            _driver = DriverInstance.GetInstance(EnvironmentSettings.CurrentBrowser);
            _driver.Manage().Window.Maximize();
        }

        public static HomePage GetAndOpenHomePage()
        {
            var homePage = new HomePage(_driver);
            return homePage;
        }

        public static ComparePage GetAndOpenComparePage()
        {
            var comparePage = new ComparePage(_driver);
            return comparePage;
        }

        public static void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }
    }
}