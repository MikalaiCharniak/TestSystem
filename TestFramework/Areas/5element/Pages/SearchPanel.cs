using OpenQA.Selenium;

namespace TestFramework.Areas._5element.Pages
{
    public class SearchPanel
    {
        private static string NoResultsMessageByXPath = ".//div[@class='multi-noResults']";
        private static string AllResultsByXPath = ".//span[@class='multi-badge']";
        public static bool IsNoResults(IWebDriver _driver)
        {
            try
            {
                var noResultsMessage = _driver.FindElement(By.XPath(NoResultsMessageByXPath));
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return NoResultsMessageByXPath == null ? false : true;
        }

        public static bool IsNotZeroResults(IWebDriver _driver)
        {
            var allResultsBage = _driver.FindElements(By.XPath(AllResultsByXPath))[0];
            var foundProductsCount = int.Parse(allResultsBage.GetAttribute("innerHTML"));
            return foundProductsCount > 0 ? true : false;
        }
    }
}
