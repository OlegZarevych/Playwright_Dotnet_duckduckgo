using PlaywrightSharp;
using System.Linq;
using System.Threading.Tasks;

namespace duckduckGoPlaywright.Pages
{
    public class SearchResultPage
    {
        private readonly IPage page;

        private const string resultLinkList = "h2.result__title";
        private const string resultsLIST = "#links_wrapper";

        public SearchResultPage(IPage page)
        {
            this.page = page;
            this.page.ReloadAsync().GetAwaiter().GetResult();
        }

        public async Task<int> GetLinksCount()
        {
            await this.page.WaitForSelectorAsync(resultsLIST, WaitForState.Visible);
            var resultList = await this.page.QuerySelectorAllAsync(resultLinkList);
            return resultList.Count();
        }
    }
}