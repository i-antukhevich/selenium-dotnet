using OpenQA.Selenium;

namespace Selenium.Extensions;

public static class ByExtensions
{
    public static By With(this By locator, params string[] args)
    {
        var criteria = locator.Criteria;
        var mechanism = locator.Mechanism;
        
        if (args.Any())
        {
            for (int i = 0; i < args.Length; i++)
            {
                criteria = criteria.Replace("{" + i + "}", args[i]);
            }
        }

        return mechanism == By.CssSelector("").Mechanism
            ? By.CssSelector(criteria)
            : By.XPath(criteria);
    }
}