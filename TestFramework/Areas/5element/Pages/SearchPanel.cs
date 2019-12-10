using OpenQA.Selenium;
using TestFramework.Core.Driver;

namespace TestFramework.Areas._5element.Pages
{
    public class SearchPanel
    {
        private static string NoResultsMessageByXPath = ".//div[@class='multi-noResults']";
        private static string AllResultsByXPath = ".//span[@class='multi-badge']";
        public static bool IsNoResults()
        {
            try
            {
                var noResultsMessage = DriverInstance.GetInstance().FindElement(By.XPath(NoResultsMessageByXPath));
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return NoResultsMessageByXPath == null ? false : true;
        }

        public static bool IsNotZeroResults()
        {
            var allResultsBage = DriverInstance.GetInstance().FindElements(By.XPath(AllResultsByXPath))[0];
            var foundProductsCount = int.Parse(allResultsBage.GetAttribute("innerHTML"));
            return foundProductsCount > 0 ? true : false;
        }
    }
}
