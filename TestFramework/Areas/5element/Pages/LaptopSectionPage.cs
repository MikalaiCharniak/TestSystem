using OpenQA.Selenium;
using System;
using System.Threading;
using TestFramework.Areas._5element.Infrastructure;
using TestFramework.Areas._5element.Pages.Base;

namespace TestFramework.Areas._5element.Pages
{
    public class LaptopSectionPage : FiveElementPageBase
    {
        private const string _addToCompareButtonsXPath = ".//div[@title='В сравнение']";
        private const string _compareWindowXPath = ".//a[@class='js-bottom-compare']";
        private const string _cartButtonsXPath = "//div[@class='row flex-buy-buttons-mob-listing']/button[1]";
        private const string _cartModalCloseButtonXPath = "//button[@class='mfp-close']";
        private IWebElement _compareWindow;
        public LaptopSectionPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public LaptopSectionPage(IWebDriver driver, string routeFrom)
        {
            _driver = driver;
            switch (routeFrom)
            {
                case Paths.HomePageURL:
                    InitPageFromHomePage();
                    break;
            }
        }
        public void AddLaptopsToCompare(int laptopsNumber)
        {
            var addToCompareButtons = _driver.FindElements(By.XPath(_addToCompareButtonsXPath));
            for (int i = 1; i < laptopsNumber + 1; i++)
            {
                ScrollToElement(_driver, addToCompareButtons[i]);
                Thread.Sleep(5000);
                addToCompareButtons[i].Click();
            }
        }
        public void AddLaptopsToCart(int laptopsNumber)
        {
            var cartButtons = _driver.FindElements(By.XPath(_cartButtonsXPath));
            Thread.Sleep(1000);
            for (int i = 0; i < laptopsNumber; i++)
            {
                cartButtons[i].SendKeys(Keys.Space);
                Thread.Sleep(1000);
                try
                {
                    _driver.FindElement(By.XPath(_cartModalCloseButtonXPath)).Click();
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                }
                Thread.Sleep(10000);
            }
            Thread.Sleep(1000);
        }
        public void OpenCompareWindow()
        {
            Thread.Sleep(10000);
            _compareWindow = _driver.FindElement(By.XPath(_compareWindowXPath));
            _compareWindow.Click();
        }
        private void InitPageFromHomePage()
        {
            _driver.FindElement(By.XPath("//nav[@class='menu-goods']/ul/li[8]/a")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//div[@class='sidebar-menu-item-body  ']/ul/li[1]/a")).Click();
            Thread.Sleep(1000);
        }
    }
}
