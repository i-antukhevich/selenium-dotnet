using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Options;

namespace Selenium.Browser.Builders;

public class ChromeBrowserBuilder : IBrowserBuilder
{
    private readonly ChromeOptions _chromeOptions = new();
    private readonly ChromeDriverService _service = ChromeDriverService.CreateDefaultService();

    public IBrowserBuilder WithArguments(IList<string> args)
    {
        _chromeOptions.AddArguments(args);
        return this;
    }

    public IBrowserBuilder WithTimeouts(TimeoutOptions timeouts)
    {
        _chromeOptions.ImplicitWaitTimeout = timeouts.Implicit;
        return this;
    }

    public IWebDriver Build()
    {
        return new ChromeDriver(_service, _chromeOptions);
    }
}