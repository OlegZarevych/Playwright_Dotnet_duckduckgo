using Microsoft.Extensions.Logging;
using PlaywrightSharp;
using System;
using System.Threading.Tasks;

namespace duckduckGoPlaywright.Driver
{
    public class Browser
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private bool headless;
        public async Task<IBrowser> GetBrowser()
        {
            playwright = await Playwright.CreateAsync(GetLogger(), debug: "pw:api");
            await ChooseBrowser();

            return browser;
        }

        private async Task ChooseBrowser()
        {
            // TODO: change to config file
            headless = false;
            string browserName = "Chromium";

            switch (browserName)
            {
                case "Chromium":
                    browser = await playwright.Chromium.LaunchAsync(new LaunchOptions { Headless = headless });
                    break;
                default:
                    throw new Exception($"No such browser. Browser {browserName} not support yet");
            }
            
        }

        private ILoggerFactory GetLogger()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddFilter((f, _) => f == "PlaywrightSharp.Playwright");
                // TODO: Add some logger, like Nlog to write into file
            });

            return loggerFactory;
        }
    }
}