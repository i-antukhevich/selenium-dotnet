using System.ComponentModel;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using Selenium.Browser.Builders;
using Selenium.Options;

namespace Selenium.Browser;

public class BrowserManager(IOptions<BrowserOptions> options)
{
    public IWebDriver StartDriver()
    {
        var profile = options.Value.Profiles.FirstOrDefault(o => o.Name == options.Value.Profile)
                      ?? throw new InvalidEnumArgumentException($"There is no profile exist with name {options.Value.Profile}");
        
        return options.Value.Profile switch
        {
            "chrome" => new ChromeBrowserBuilder().WithTimeouts(options.Value.Timeouts).WithArguments(profile.Arguments).Build(),
            _ => throw new InvalidEnumArgumentException($"There is no implementation for {options.Value.Profile} exist")
        };
    }
}