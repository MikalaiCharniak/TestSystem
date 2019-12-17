using OpenQA.Selenium;
using TestFramework.Areas._5element.Pages;
using TestFramework.Areas._5element.Pages.Common;
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

        public static bool IsTransitionBetweenProductTabs()
        {
            var IsServicesTab = ProductPageCommon.GoToServicesAnchor(_driver);
            var IsDescriptionTab = ProductPageCommon.GoToDescriptionAnchor(_driver);
            return IsServicesTab && IsDescriptionTab;
        }

        public static void OpenModalAndWriteQuestionProduct()
        {
            if (ProductPageCommon.GoToFAQAnchor(_driver))
                ProductPageCommon.OpenFAQWindowAndWriteQuestion(_driver);
        }

        public static void OpenModalAndWriteReviewProduct()
        {
            if (ProductPageCommon.GoToReviewAnchor(_driver))
                ProductPageCommon.OpenReviewWindowAndWriteReview(_driver);
        }

        public static void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }
    }
}