using OpenQA.Selenium;

namespace AutomationHost.Web.Assertions;

public static class ToBe
{
    public static readonly Func<Func<IWebElement>, bool> Displayed = element =>
    {
        try
        {
            return element() is { Displayed: true };
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
    
    public static readonly Func<Func<IWebElement>, bool> Invisible = element =>
    {
        try
        {
            return element() is { Displayed: false };
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

    public static readonly Func<Func<IWebElement>, bool> Enabled = element =>
    {
        try
        {
            return element() is { Displayed: true, Enabled: true };
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
    
    public static readonly Func<Func<IWebElement>, bool> Disabled = element =>
    {
        try
        {
            return element() is { Displayed: true, Enabled: false };
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