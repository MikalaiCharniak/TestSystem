using OpenQA.Selenium;
using System.Threading;
using TestFramework.Areas._5element.Models;

namespace TestFramework.Areas._5element.Pages.Modals
{
    public static class FAQModal
    {
        private const string _cityInputXPath = ".//input[@name='UF_LOCATION']";
        private const string _phoneInputXPath = ".//input[@name='UF_PHONE']";
        private const string _questionInputXPath = ".//textarea[@name='UF_QUESTION']";
        private const string _captchaId = "recaptcha-anchor";
        private const string _buttonSubmitId = "save_faq";

        public static bool FillQuestionForm(IWebDriver driver, ProductQuestion productQuestion)
        {
            var cityInput = driver.FindElement(By.XPath(_cityInputXPath));
            cityInput.Clear();
            var phoneInput = driver.FindElement(By.XPath(_phoneInputXPath));
            phoneInput.Clear();
            var questionInput = driver.FindElement(By.XPath(_questionInputXPath));
            questionInput.Clear();
            cityInput.SendKeys(productQuestion.City);
            phoneInput.SendKeys(productQuestion.PhoneNumber);
            questionInput.SendKeys(productQuestion.QuestionBody);
            var captchaCheckBox = driver.FindElement(By.Id(_captchaId));
            captchaCheckBox.Click();
            Thread.Sleep(3000);
            return driver.FindElement(By.Id(_buttonSubmitId)).Enabled;
        }
    }
}