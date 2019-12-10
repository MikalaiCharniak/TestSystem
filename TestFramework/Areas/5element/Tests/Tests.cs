using Microsoft.Extensions.Configuration;
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

        [SetUp]
        public void Setup()
        {
            _configuration = EnvironmentSettings.GetConfiguration();
            _exptectedProductForCompare = int.Parse(_configuration[
                "CheckComparisonProduct:exptectedProductForCompare"]);
            _searchVariable = _configuration["CheckSearchFunction:searchVariable"];
            Steps.InitBrowser();
        }

        [Test]
        public void CheckComparisonProduct()
        {
            UITest(() =>
            {
                var homePage = Steps.GetAndOpenHomePage();
                homePage.GoToPage();
                var laptopSectionPage = homePage.GoToLaptopSectionPage();
                laptopSectionPage.AddLaptopsToCompare(_exptectedProductForCompare);
                laptopSectionPage.OpenCompareWindow();
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
    }
}