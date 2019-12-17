using OpenQA.Selenium;
using System.Threading;
using TestFramework.Core.Abstractions;

namespace TestFramework.Areas._5element.Pages.Base
{
    public class FiveElementPageBase : Page
    {
        private const string _searchUrl = "#/search/";
        private const string _searchInputByXPath = ".//input[@id='q']";
        private const string _cartProductsNumberByXPath = "//span[@class='header-elements-cart-qty ']";

        private void OpenSearchInput()
        {
            var searchURL = $"{_driver.Url}{_searchUrl}";
            _driver.Navigate().GoToUrl(searchURL);
        }

        public virtual void WriteSearchQuery(string searchVariable)
        {
            OpenSearchInput();
            var searchInput = _driver.FindElement(By.XPath(_searchInputByXPath));
            searchInput.Clear();
            searchInput.SendKeys(searchVariable);
            Thread.Sleep(5000);
        }

        public int CartProductsNumber
        {
            get { 
            return int.Parse(_driver.FindElement(By.XPath(_cartProductsNumberByXPath)).GetAttribute("innerHTML"));
            }
        }
    }
}
