using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Extensions;

public static partial class WebDriverExtensions
{
    private static readonly TimeSpan Timeout = Ability.FluentTimeout;

    public static IWebElement WaitForElement(this IWebDriver driver, By locator, Func<Func<IWebElement>, bool> expression)
    {
        new DefaultWait<IWebDriver>(driver) { Timeout = Timeout }
            .Until(page => page.ExpectTheElement(locator, expression));

        try
        {
            return driver.FindElement(locator);
        }
        catch (StaleElementReferenceException)
        {
            return null!;
        }
        catch (NoSuchElementException)
        {
            return null!;
        }
    }
    
    public static IWebElement WaitForElement(this IWebDriver driver, By locator, Func<Func<IWebElement>, string, bool> expression, string expectedValue)
    {
        new DefaultWait<IWebDriver>(driver) { Timeout = Timeout }
            .Until(page => page.ExpectTheElement(locator, expression, expectedValue));

        try
        {
            return driver.FindElement(locator);
        }
        catch (StaleElementReferenceException)
        {
            return null!;
        }
        catch (NoSuchElementException)
        {
            return null!;
        }
    }
    
    public static IList<IWebElement> WaitForElement(this IWebDriver driver, By locator, Func<Func<IList<IWebElement>>, bool> expression)
    {
        new DefaultWait<IWebDriver>(driver) { Timeout = Timeout }
            .Until(page => page.ExpectTheElements(locator, expression));

        return driver.FindElements(locator);
    }
    
    public static IList<IWebElement> WaitForElement(this IWebDriver driver, By locator, Func<Func<IList<IWebElement>>, string, bool> expression, string expectedValue)
    {
        new DefaultWait<IWebDriver>(driver) { Timeout = Timeout }
            .Until(page => page.ExpectTheElements(locator, expression, expectedValue));

        return driver.FindElements(locator);
    }

    public static void WaitUntilPageIsLoaded(this IWebDriver driver)
    {
	    new DefaultWait<IWebDriver>(driver) { Timeout = Timeout }
		    .Until(page =>
		    {
			    try
			    {
				    var initialLength = page.FindElement(By.CssSelector("body")).Text.Length;
				    Thread.Sleep(1000);

				    return page.FindElement(By.CssSelector("body")).Text.Length == initialLength;
			    }
			    catch (StaleElementReferenceException)
			    {
				    return false;
			    }
			    catch (NoSuchElementException)
			    {
				    return false;
			    }
		    });
    }
}
