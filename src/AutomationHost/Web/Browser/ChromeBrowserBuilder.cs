using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationHost.Web.Browser;

public class ChromeBrowserBuilder
{
    private readonly ChromeOptions _options = new();
    private readonly ChromeDriverService _service = ChromeDriverService.CreateDefaultService();

    public IWebDriver BuildFromSettings()
    {
        var configuration = AutomationContext.BrowserConfiguration;
        
        _options.ImplicitWaitTimeout = configuration.GetRequiredSection("timeouts:implicit").Get<TimeSpan>();
        _options.AddArguments(configuration.GetRequiredSection("arguments").Get<string[]>());

        return new ChromeDriver(_service, _options);
    }
}