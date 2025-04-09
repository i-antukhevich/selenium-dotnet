using AutomationHost;
using Demoqa.Common;
using Microsoft.Extensions.DependencyInjection;
using Selenium.Browser;

namespace Demoqa.TextBoxPageCollection;

[CollectionDefinition(nameof(TextBoxPageCollection))]
public class TextBoxPageCollection : ICollectionFixture<TextBoxPageCollectionContext>
{
}

public class TextBoxPageCollectionContext : CollectionContext
{
	public TextBoxPageCollectionContext(AutomationContext context) : base(context, "TestAutomation")
	{
		Actor.Driver = context.Services.GetRequiredService<BrowserManager>().StartDriver();
	}
}

