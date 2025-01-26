using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace AutomationHost.Web.Locator;

public class Locator(string pageDefinition)
{
    private readonly IConfiguration _json = AutomationContext.GetPageDefinition(pageDefinition);
    
    public By this[string key] => BuildLocator(key);

    private By BuildLocator(string key)
    {
        string locator = _json.GetRequiredSection(key).Get<string>()!;

        return locator.StartsWith(".//") || locator.StartsWith("//") || locator.StartsWith("/")
            ? By.XPath(locator)
            : By.CssSelector(locator);
    }
}