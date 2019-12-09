using OpenQA.Selenium;
using TestFramework.Areas._5element.Infrastructure;
using TestFramework.Core.Abstractions;

namespace TestFramework.Areas._5element.Pages
{
    public class ComparePage : Page
    {
        private const string compareProductsArrayByXPath =
            ".//div[@class='product-item product-item-shortblock item js-product-item']";

        public ComparePage(IWebDriver driver)
        {
            PageUrl = Paths.CompareURL;
            _driver = driver;
            _driver.Navigate().GoToUrl("https://5element.by/compare");
        }

        public bool CheckNumberOfComporasionProducts(int expectedNumber)
        {
            var productForCompare = _driver.FindElements(By.XPath(compareProductsArrayByXPath));
            var result = productForCompare.Count == expectedNumber ? true : false;
            return result;
        }
    }
}
