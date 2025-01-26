using OpenQA.Selenium;

namespace AutomationHost.Web.Assertions;

public static class ToHave
{
    public static readonly Func<Func<IWebElement>, string, bool> EquivalentText = (element, text) =>
    {
        try
        {
            return element().Text.Equals(text);
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
    
    public static readonly Func<Func<IWebElement>, string, bool> PartialText = (element, text) =>
    {
        try
        {
            return element().Text.Contains(text);
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
    
    public static readonly Func<Func<IWebElement>, bool> AnyText = (element) =>
    {
        try
        {
            return element().Text is not null && element().Text.Length > 0;
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