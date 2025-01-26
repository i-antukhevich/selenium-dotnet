using OpenQA.Selenium;
using Selenium.Extensions;

namespace Selenium.Assertions;

public static class ToAnyHave
{
    public static readonly Func<Func<IList<IWebElement>>, string, bool> EquivalentText = (elements, text) =>
    {
        try
        {
            return elements().Any(e => e.GetElementValue().Equals(text));
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
    
    public static readonly Func<Func<IList<IWebElement>>, string, bool> PartialText = (elements, text) =>
    {
        try
        {
            return elements().Any(e => e.GetElementValue().Contains(text));
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
    
    public static readonly Func<Func<IList<IWebElement>>, bool> AnyText = (elements) =>
    {
        try
        {
            return elements().Any(e => e.GetElementValue().Length > 0);
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
