using OpenQA.Selenium;

namespace Selenium.Extensions;

public static partial class WebDriverExtensions
{
    public static bool ExpectTheElement(this IWebDriver driver, By locator, Func<Func<IWebElement>, bool> expression)
    {
        return expression(() => driver.FindElement(locator));
    }
    
    public static bool ExpectTheElement(this IWebDriver driver, By locator, Func<Func<IWebElement>, string, bool> expression, string expectedValue)
    {
        return expression(() => driver.FindElement(locator), expectedValue);
    }
    
    public static bool ExpectTheElements(this IWebDriver driver, By locator, Func<Func<IList<IWebElement>>, bool> expression)
    {
        return expression(() => driver.FindElements(locator));
    }
    
    public static bool ExpectTheElements(this IWebDriver driver, By locator, Func<Func<IList<IWebElement>>, string, bool> expression, string expectedValue)
    {
        return expression(() => driver.FindElements(locator), expectedValue);
    }
}