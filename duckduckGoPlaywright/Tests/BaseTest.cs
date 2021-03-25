using PlaywrightSharp;
using System;
using System.Threading.Tasks;

namespace duckduckGoPlaywright
{
    public class BaseTest : IAsyncDisposable
    {
        private IBrowserContext browserContext;
        private IBrowser browser;


        public BaseTest()
        {

        }

        private async Task<IPage> Init()
        {
            this.browser = await new Driver.Browser().GetBrowser();
            browserContext = await browser.NewContextAsync(new BrowserContextOptions { BypassCSP = true, Viewport = null, RecordVideo = new RecordVideoOptions {Dir = @"C:\results" } });
            return await browserContext.NewPageAsync();

        }

        private async Task<IResponse> GoTo()
        {
            this.Page = Init().GetAwaiter().GetResult();

            this.Page.Request += requestHandler;
            this.Page.Response += responseHandler;

            return await Page.GoToAsync("https://duckduckgo.com/");
        }

        protected async void InitAndGo()
        {
             await GoTo();
        }

        protected IPage Page { get; private set; }

        private void requestHandler(object sender, RequestEventArgs e)
        {
            // TODO: Write to logger
            Console.WriteLine($"Request: {e.Request.Url}");
            Console.WriteLine($"Request timing {e.Request.Timing}");
        }

        private void responseHandler(object sender, ResponseEventArgs e)
        {
            Console.WriteLine($"Response: {e.Response.Url} and status code: {e.Response.Status}");
        }

        public async ValueTask DisposeAsync()
        {
            await Page.CloseAsync();
            await browserContext.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
