using AutomationHost;
using Demoqa.Common;
using Microsoft.Extensions.DependencyInjection;
using Selenium.Browser;

namespace Demoqa.UICollection;

[CollectionDefinition(nameof(UICollection))]
public class UICollection : ICollectionFixture<UICollectionContext>
{
}

public class UICollectionContext : CollectionContext
{
	public UICollectionContext(AutomationContext context) : base(context, "TestAutomation")
	{
		Actor.Driver = context.Services.GetRequiredService<BrowserManager>().StartDriver();
	}
}
