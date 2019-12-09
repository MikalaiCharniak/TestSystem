using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestFramework.Core.Driver
{
    public static class DriverInstance 
    {
        private static IWebDriver _driver;

        public static IWebDriver GetInstance(string selectedBrowser = "default")
        {
            if (_driver == null)
            {
                switch (selectedBrowser)
                {
                    case "chrome":
                        _driver = new ChromeDriver();
                        break;
                    case "firefox":
                        _driver = new FirefoxDriver();
                        break;
                    default:
                        _driver = new FirefoxDriver();
                        break;
                }
            }
            return _driver;
        }

        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
