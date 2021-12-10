using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using duckduckGoPlaywright.Pages;
using Xunit;

namespace duckduckGoPlaywright.Tests
{
    public class SearchTest : BaseTest
    {
        [Fact]
        public async void Search_ResultLinksCount_Equal10()
        {
            InitAndGo();

            var searchPage = new SearchPage(Page);

            searchPage.EnterSearchRequest("playwright");
            var resultPage = await searchPage.Search();

            var linkCount = await resultPage.GetLinksCount();

            Assert.Equal(10, linkCount);

            var extent = new ExtentReports();
            var spark = new ExtentSparkReporter("Spark.html");
            extent.AttachReporter(spark);
            extent.CreateTest("MyFirstTest")
              .Log(Status.Pass, "This is a logging event for MyFirstTest, and it passed!");
            extent.Flush();
        }
    }
}
