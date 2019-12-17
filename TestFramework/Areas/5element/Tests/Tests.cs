using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.IO;
using System.Threading;
using TestFramework.Areas._5element.Pages;
using TestFramework.Areas._5element.Steps;
using TestFramework.Core.Abstractions;
using TestFramework.Core.Settings;

namespace TestFramework.Tests.Source
{
    public class Tests : PageTestBase
    {
        private IConfiguration _configuration;
        private int _exptectedProductForCompare;
        private string _searchVariable;
        private string _expectedBreadcrumbTitle;
        private int _expectedCountProductsInCart;
        private readonly ILogger _logger;

        public Tests(ILogger<Tests> logger)
        {
            _logger = logger;
        }

        [SetUp]
        public void Setup()
        {
            _configuration = EnvironmentSettings.GetConfiguration();
            _exptectedProductForCompare = int.Parse(_configuration[
                "CheckComparisonProduct:exptectedProductForCompare"]);
            _searchVariable = _configuration["CheckSearchFunction:searchVariable"];
            _expectedBreadcrumbTitle = _configuration[""];
            _expectedCountProductsInCart = int.Parse(_configuration[""]);
            _logger.LogInformation("Inital data for testing successfully setup!");
            Steps.InitBrowser();
        }

        [Test]
        public void CheckComparisonProduct()
        {
            UITest(() =>
            {
                var homePage = Steps.GetAndOpenHomePage();
                homePage.GoToPage();
                _logger.LogInformation("Tests -> CheckComparisonProduct -> Open Home Page: successfully");
                var laptopSectionPage = homePage.GoToLaptopSectionPage();
                _logger.LogInformation("Tests -> CheckComparisonProduct -> Go to Laptot section page: successfully");
                laptopSectionPage.AddLaptopsToCompare(_exptectedProductForCompare);
                laptopSectionPage.OpenCompareWindow();
                _logger.LogInformation("Tests -> CheckComparisonProduct -> Open compare window: successfully");
                Thread.Sleep(1000);
                var compareWindow = Steps.GetAndOpenComparePage();
                Thread.Sleep(1000);
                var result = compareWindow.CheckNumberOfComporasionProducts(_exptectedProductForCompare);
                Assert.IsTrue(result);
                TestContext.AddTestAttachment(Path.GetTempFileName());
            });
        }

        [Test]
        public void CheckSearchFunction()
        {
            UITest(() =>
            {
                var homePage = Steps.GetAndOpenHomePage();
                homePage.GoToPage();
                homePage.WriteSearchQuery(_searchVariable);
                var isSearchResultExist = SearchPanel.IsNotZeroResults()
                    && !SearchPanel.IsNoResults();
                Assert.IsTrue(isSearchResultExist);
            });
        }

        [Test]
        public void CheckDeliveryPage()
        {
            UITest(() =>
            {
                var homePage = Steps.GetAndOpenHomePage();
                homePage.GoToPage();
                var deliveryPage = homePage.GoToDeliveryPage();
                var breadrcumbTitle = deliveryPage.GetBreadcrumbTitle();
                Assert.AreEqual(breadrcumbTitle, _expectedBreadcrumbTitle);
            });
        }

        [Test]
        public void CheckAddingProductsToCart()
        {

            UITest(() =>
            {
                var homePage = Steps.GetAndOpenHomePage();
                homePage.GoToPage();
                _logger.LogInformation("Tests -> CheckComparisonProduct -> Open Home Page: successfully");
                var laptopSectionPage = homePage.GoToLaptopSectionPage();
                _logger.LogInformation("Tests -> CheckComparisonProduct -> Go to Laptot section page: successfully");
                var cartProductCount = laptopSectionPage.CartProductsNumber;
                Assert.AreEqual(_expectedCountProductsInCart, cartProductCount);
            });
        }
    }
}