using OpenQA.Selenium;
using System.Threading;
using TestFramework.Areas._5element.Infrastructure;
using TestFramework.Areas._5element.Models;
using TestFramework.Areas._5element.Pages.Base;

namespace TestFramework.Areas._5element.Pages
{
    public class LoginPage : FiveElementPageBase
    {
        private const string _loginWithEmailTabId = "login-tab-bpm-email";
        private const string _emailInputXPath = ".//input[@type='email']";
        private const string _passwordInputXPath = ".//input[@type='password']";
        private const string _loginButton = ".//a[@class='button js-submit']";

        public LoginPage(IWebDriver driver, string routeFrom)
        {
            PageUrl = Paths.LoginPageURL;
            _driver = driver;
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void SwitchToEmailLoginTab()
        {
            var loginWithEmailTab = _driver.FindElement(By.Id(_loginWithEmailTabId));
            loginWithEmailTab.Click();
        }

        public void FillAuthFields(User user)
        {
            Thread.Sleep(1000);
            var emailInput = _driver.FindElement(By.XPath(_emailInputXPath));
            var passwordInput = _driver.FindElements(By.XPath(_passwordInputXPath))[1];
            emailInput.Clear();
            emailInput.SendKeys(user.Email);
            Thread.Sleep(1000);
            passwordInput.Clear();
            passwordInput.SendKeys(user.Password);
        }

        public void Login()
        {
            Thread.Sleep(3000);
            var submitButton = _driver.FindElement(By.XPath(_loginButton));
            Thread.Sleep(3000);
            submitButton.Click();
        }

        public bool CheckAuthorize()
        {
            _driver.Navigate().GoToUrl(Paths.CabinetURL);
            return _driver.Url == Paths.CabinetURL;
        }
    }
}
