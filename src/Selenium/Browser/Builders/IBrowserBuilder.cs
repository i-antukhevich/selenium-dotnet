using OpenQA.Selenium;
using Selenium.Options;

namespace Selenium.Browser.Builders;

public interface IBrowserBuilder
{
    IBrowserBuilder WithArguments(IList<string> args);
    IBrowserBuilder WithTimeouts(TimeoutOptions timeouts);
    IWebDriver Build();
}