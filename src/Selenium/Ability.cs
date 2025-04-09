using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Selenium.Browser;
using Selenium.Options;

namespace Selenium;

public static class Ability
{
    public static TimeSpan FluentTimeout { get; private set; }
    
    public static IServiceCollection AddSeleniumAbility(this IServiceCollection collection)
    {
        var configuration = collection.BuildServiceProvider().GetRequiredService<IConfiguration>()
            .GetRequiredSection("browser");

        FluentTimeout = configuration.GetRequiredSection("timeouts:fluent").Get<TimeSpan>();
        
        collection
            .Configure<BrowserOptions>(configuration)
            .AddSingleton<BrowserManager>();

        return collection;
    }
}