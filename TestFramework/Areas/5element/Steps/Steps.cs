using OpenQA.Selenium;
using TestFramework.Areas._5element.Models;
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

        public static bool OpenModalAndWriteQuestionProduct(ProductQuestion productQuestion)
        {
            if (ProductPageCommon.GoToFAQAnchor(_driver))
                return ProductPageCommon.OpenFAQWindowAndWriteQuestion(_driver, productQuestion);
            return false;
        }

        public static bool OpenModalAndWriteReviewProduct(ProductReview productReview)
        {
            if (ProductPageCommon.GoToReviewAnchor(_driver))
                return ProductPageCommon.OpenReviewWindowAndWriteReview(_driver, productReview);
            return false;
        }

        public static void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }
    }
}