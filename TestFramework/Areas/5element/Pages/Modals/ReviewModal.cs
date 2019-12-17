using OpenQA.Selenium;
using System.Threading;
using TestFramework.Areas._5element.Models;

namespace TestFramework.Areas._5element.Pages.Modals
{
    public class ReviewModal
    {
        private const string _cityInputXPath = ".//input[@name='UF_LOCATION']";
        private const string _plusesInputXPath = ".//textarea[@name='UF_TEXT_PLUS']";
        private const string _minusesInputXPath = ".//textarea[@name='UF_TEXT_MINUS']";
        private const string _resumeInputXPath = ".//textarea[@name='UF_TEXT_RESUME']";
        private const string _captchaId = "recaptcha-anchor";
        private const string _buttonSubmitId = "save";


        public static bool FillReviewForm(IWebDriver driver, ProductReview productReview)
        {
            var cityInput = driver.FindElement(By.XPath(_cityInputXPath));
            cityInput.Clear();
            var plusesInput = driver.FindElement(By.XPath(_plusesInputXPath));
            plusesInput.Clear();
            var minusesInput = driver.FindElement(By.XPath(_minusesInputXPath));
            minusesInput.Clear();
            var resumeInput = driver.FindElement(By.XPath(_resumeInputXPath));
            cityInput.SendKeys(productReview.City);
            plusesInput.SendKeys(productReview.ProductAdvantages);
            minusesInput.SendKeys(productReview.ProductDisadvantages);
            resumeInput.SendKeys(Keys.Space);
            resumeInput.Clear();
            resumeInput.SendKeys(productReview.ReviewBody);
            var captchaCheckBox = driver.FindElement(By.Id(_captchaId));
            captchaCheckBox.SendKeys(Keys.Space);
            captchaCheckBox.Click();
            Thread.Sleep(3000);
            return driver.FindElement(By.Id(_buttonSubmitId)).Enabled;
        }
    }
}
