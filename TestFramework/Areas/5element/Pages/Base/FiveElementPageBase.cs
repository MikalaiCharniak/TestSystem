using OpenQA.Selenium;
using System.Threading;
using TestFramework.Core.Abstractions;

namespace TestFramework.Areas._5element.Pages.Base
{
    public class FiveElementPageBase : Page
    {
        private const string _searchUrl = "#/search/";
        private const string searchInputByXPath = ".//input[@id='q']";

        private void OpenSearchInput()
        {
            var searchURL = $"{_driver.Url}{_searchUrl}";
            _driver.Navigate().GoToUrl(searchURL);
        }

        public virtual void WriteSearchQuery(string searchVariable)
        {
            OpenSearchInput();
            var searchInput = _driver.FindElement(By.XPath(searchInputByXPath));
            searchInput.Clear();
            searchInput.SendKeys(searchVariable);
            Thread.Sleep(5000);
        }
    }
}
