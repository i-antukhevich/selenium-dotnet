using AutomationHost.Actors.Abilities;
using AutomationHost.Web.Browser;
using OpenQA.Selenium;
using UITestsCollection.Fixtures;

namespace UITestsCollection.Collections;

public class UICollection : CollectionContext
{
    public IWebDriver Driver { get; set; }

    public UICollection()
    {
        Driver = new ChromeBrowserBuilder().BuildFromSettings();
        Actor.Add(new BrowseTheWebAbility(Driver));
    }

    public override void Dispose()
    {
        base.Dispose();
        Driver.Quit();
    }
}