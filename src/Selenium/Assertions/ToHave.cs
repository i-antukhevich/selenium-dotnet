using OpenQA.Selenium;
using Selenium.Extensions;

namespace Selenium.Assertions;

public static class ToHave
{
    public static readonly Func<Func<IWebElement>, string, bool> EquivalentText = (element, text) =>
    {
        try
        {
            return element().GetElementValue().Equals(text);
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
            return element().GetElementValue().Contains(text);
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
            return element().GetElementValue().Length > 0;
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
