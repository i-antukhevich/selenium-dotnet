using OpenQA.Selenium;

namespace Selenium.Assertions;

public static class ToAllBe
{
    public static readonly Func<Func<IList<IWebElement>>, bool> Displayed = elements =>
    {
        try
        {
            return elements().Any() && elements().All(e => e is { Displayed: true });
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
            return elements().All(e => e is { Displayed: false });
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
            return elements().Any() &&  elements().All(e => e is { Displayed: true, Enabled: true });
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
            return elements().Any() &&  elements().All(e => e is { Displayed: true, Enabled: false });
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