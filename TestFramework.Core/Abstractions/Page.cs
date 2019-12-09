using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace TestFramework.Core.Abstractions
{
    public abstract class Page
    {
        private const int _incrementScrollHeight = 100;
        private string _url;
        public string PageUrl
        {
            get
            {
                return _url;
            }
            set
            {
                if (string.IsNullOrEmpty(_url))
                    _url = value;
            }
        }
        protected IWebDriver _driver;

        public virtual void ScrollToElement(IWebDriver driver, IWebElement element, int startScroll = 100)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();
            }
            catch (Exception ex)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript($"scroll(0,{startScroll});");
                this.ScrollToElement(driver, element, startScroll + _incrementScrollHeight);
            }
        }
    }
}