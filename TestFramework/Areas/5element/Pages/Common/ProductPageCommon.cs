using OpenQA.Selenium;
using System.Threading;

namespace TestFramework.Areas._5element.Pages.Common
{
    public static class ProductPageCommon
    {
        private const string _activeTabCssClass = "active";
        private const string _productDescriptionAnchorXPath = ".//a[@href='#description']";
        private const string _productCharacteristicsAnchorXPath = ".//a[@href='#characteristics']";
        private const string _productServicesAnchorXPath = ".//a[@href='#services']";

        public static bool GoToDescriptionAnchor(IWebDriver driver)
        {
            var descriptionAnchorLink = driver.FindElement(By.XPath(_productDescriptionAnchorXPath));
            descriptionAnchorLink.SendKeys(Keys.Space);
            Thread.Sleep(3000);
            var parentActiveTag = descriptionAnchorLink.FindElement(By.XPath("./parent::*"));
            descriptionAnchorLink.Click();
            Thread.Sleep(1000);
            return parentActiveTag.GetAttribute("class") == _activeTabCssClass;
        }

        public static bool GoToServicesAnchor(IWebDriver driver)
        {
            var descriptionAnchorLink = driver.FindElement(By.XPath(_productServicesAnchorXPath));
            descriptionAnchorLink.SendKeys(Keys.Space);
            Thread.Sleep(3000);
            var parentActiveTag = descriptionAnchorLink.FindElement(By.XPath("./parent::*"));
            descriptionAnchorLink.Click();
            Thread.Sleep(1000);
            return parentActiveTag.GetAttribute("class") == _activeTabCssClass;
        }
    }
}
