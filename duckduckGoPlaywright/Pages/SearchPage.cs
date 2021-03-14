using PlaywrightSharp;
using System.Threading.Tasks;

namespace duckduckGoPlaywright.Pages
{
    public class SearchPage
    {
        private readonly IPage page;

        private const string searchInput = "#search_form_input_homepage";
        private const string searchButton = "#search_button_homepage";

        public SearchPage(IPage page)
        {
            this.page = page;
        }

        public async void EnterSearchRequest(string text)
        {
            await this.page.WaitForSelectorAsync(searchInput, WaitForState.Visible);
            await this.page.FillAsync(searchInput, text);
        }

        public async Task<SearchResultPage> Search()
        {
            await this.page.ClickAsync(searchButton);
            return new SearchResultPage(this.page);
        }
    }
}