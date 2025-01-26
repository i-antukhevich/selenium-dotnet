using OpenQA.Selenium;

namespace AutomationHost.Actors.Abilities;

public class BrowseTheWebAbility(IWebDriver driver) : IAbility
{
    public IWebDriver Driver { get; set; } = driver;

    public void Dispose()
    {
        Driver.Dispose();
        Driver = null!;
    }
}