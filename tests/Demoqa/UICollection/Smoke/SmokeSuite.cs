using AutomationHost;
using Demoqa.Common;

namespace Demoqa.UICollection.Smoke;

[Collection(nameof(UICollection))]
public partial class SmokeSuite
	(UICollectionContext collection, ITestOutputHelper output)
	: SuiteContext(collection, output), IClassFixture<AutomationContext>
{
}
