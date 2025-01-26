using OpenQA.Selenium;

namespace Selenium.Extensions;

public static class WebElementExtensions
{
	public static string GetElementValue(this IWebElement element)
	{
		return new List<string> { "input", "textarea" }.Contains(element.TagName)
			? element.GetDomProperty("value")
			: element.Text;
	}
}
