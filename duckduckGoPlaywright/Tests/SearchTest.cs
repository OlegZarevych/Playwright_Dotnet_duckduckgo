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
        }
    }
}
