using OpenQA.Selenium;
using System.Threading;
using TestFramework.Areas._5element.Models;
using TestFramework.Areas._5element.Pages.Modals;

namespace TestFramework.Areas._5element.Pages.Common
{
    public static class ProductPageCommon
    {
        private const string _activeTabCssClass = "active";
        private const string _productDescriptionAnchorXPath = ".//a[@href='#description']";
        //private const string _productCharacteristicsAnchorXPath = ".//a[@href='#characteristics']";
        private const string _productServicesAnchorXPath = ".//a[@href='#services']";
        private const string _productReviewsAnchorXPath = ".//a[@href='#reviews-block']";
        private const string _productFAQAnchorXPath = ".//a[@href='#faq-block']";
        private const string _buttonFAQModalXPath = ".//a[@class='button js-button-invoke-modal review-button js-open-faq-form']";
        private const string _buttonReviewModalXPath = ".//a[@class='button js-button-invoke-modal review-button js-open-feedback-form']";

        public static bool GoToDescriptionAnchor(IWebDriver driver)
        {
            var descriptionAnchorLink = driver.FindElement(By.XPath(_productDescriptionAnchorXPath));
            descriptionAnchorLink.SendKeys(Keys.Space);
            Thread.Sleep(3000);
            var parentActiveTag = descriptionAnchorLink.FindElement(By.XPath("./parent::*"));
            descriptionAnchorLink.Click();
            Thread.Sleep(1000);
            return parentActiveTag.GetAttribute("class") == _activeTabCssClass;
        }

        public static bool GoToServicesAnchor(IWebDriver driver)
        {
            var serviceAnchorLink = driver.FindElement(By.XPath(_productServicesAnchorXPath));
            serviceAnchorLink.SendKeys(Keys.Space);
            Thread.Sleep(3000);
            var parentActiveTag = serviceAnchorLink.FindElement(By.XPath("./parent::*"));
            serviceAnchorLink.Click();
            Thread.Sleep(1000);
            return parentActiveTag.GetAttribute("class") == _activeTabCssClass;
        }

        public static bool GoToFAQAnchor(IWebDriver driver)
        {
            var FAQAnchorLink = driver.FindElement(By.XPath(_productFAQAnchorXPath));
            FAQAnchorLink.SendKeys(Keys.Space);
            Thread.Sleep(3000);
            var parentActiveTag = FAQAnchorLink.FindElement(By.XPath("./parent::*"));
            FAQAnchorLink.Click();
            Thread.Sleep(1000);
            return parentActiveTag.GetAttribute("class") == _activeTabCssClass;
        }

        public static bool GoToReviewAnchor(IWebDriver driver)
        {
            var reviewAnchorLink = driver.FindElement(By.XPath(_productReviewsAnchorXPath));
            reviewAnchorLink.SendKeys(Keys.Space);
            Thread.Sleep(3000);
            var parentActiveTag = reviewAnchorLink.FindElement(By.XPath("./parent::*"));
            reviewAnchorLink.Click();
            Thread.Sleep(1000);
            return parentActiveTag.GetAttribute("class") == _activeTabCssClass;
        }

        public static bool OpenFAQWindowAndWriteQuestion(IWebDriver driver, ProductQuestion productQuestion)
        {
            var FAQModalButton = driver.FindElement(By.XPath(_buttonFAQModalXPath));
            FAQModalButton.Click();
            return FAQModal.FillQuestionForm(driver, productQuestion);
        }

        public static bool OpenReviewWindowAndWriteReview(IWebDriver driver, ProductReview productReview)
        {
            var reviewModalButton = driver.FindElement(By.XPath(_buttonReviewModalXPath));
            reviewModalButton.Click();
            return ReviewModal.FillReviewForm(driver,productReview);
        }
    }
}
