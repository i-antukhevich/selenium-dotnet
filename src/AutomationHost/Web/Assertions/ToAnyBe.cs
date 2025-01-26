using OpenQA.Selenium;

namespace AutomationHost.Web.Assertions;

public static class ToAnyBe
{
    public static readonly Func<Func<IList<IWebElement>>, bool> Displayed = elements =>
    {
        try
        {
            return elements().Any(e => e is { Displayed: true });
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    };
    
    public static readonly Func<Func<IList<IWebElement>>, bool> Invisible = elements =>
    {
        try
        {
            return elements().Any(e => e is { Displayed: false });
        }
        catch (StaleElementReferenceException)
        {
            return true;
        }
        catch (NoSuchElementException)
        {
            return true;
        }
    };

    public static readonly Func<Func<IList<IWebElement>>, bool> Enabled = elements =>
    {
        try
        {
            return elements().Any(e => e is { Displayed: true, Enabled: true });
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    };
    
    public static readonly Func<Func<IList<IWebElement>>, bool> Disabled = elements =>
    {
        try
        {
            return elements().Any(e => e is { Displayed: true, Enabled: false });
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    };
}