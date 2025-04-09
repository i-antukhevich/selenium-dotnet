using AutomationHost;
using Demoqa.Commands.Steps;
using Demoqa.Common;

namespace Demoqa.TextBoxPageCollection.Smoke;

[Collection(nameof(TextBoxPageCollection))]
public class SmokeSuite(TextBoxPageCollectionContext collection, ITestOutputHelper output)
	: SuiteContext(collection, output), IClassFixture<AutomationContext>
{
	[Fact]
	public void DoTest()
	{
		Actor
			.Performs(TextBoxPageSteps.NavigateToTextBoxPage)
			.Performs(TextBoxPageSteps.FillInFullname, Actor.Information.Username)
			.Performs(TextBoxPageSteps.FillInEmail, Actor.Information.Email)
			.Performs(TextBoxPageSteps.FillInCurrentAddress, "current address")
			.Performs(TextBoxPageSteps.FillInPermanentAddress, "permanent address")
			.Performs(TextBoxPageSteps.ClickOnSubmitButton);
	}
	
	[Fact]
	public void DoTest2()
	{
		Actor
			.Performs(TextBoxPageSteps.NavigateToTextBoxPage)
			.Performs(TextBoxPageSteps.FillInFullname, Actor.Information.Username)
			.Performs(TextBoxPageSteps.FillInEmail, Actor.Information.Email)
			.Performs(TextBoxPageSteps.FillInCurrentAddress, "current address")
			.Performs(TextBoxPageSteps.FillInPermanentAddress, "permanent address")
			.Performs(TextBoxPageSteps.ClickOnSubmitButton);
	}
	
	[Fact]
	public void DoTest3()
	{
		Actor
			.Performs(TextBoxPageSteps.NavigateToTextBoxPage)
			.Performs(TextBoxPageSteps.FillInFullname, Actor.Information.Username)
			.Performs(TextBoxPageSteps.FillInEmail, Actor.Information.Email)
			.Performs(TextBoxPageSteps.FillInCurrentAddress, "current address")
			.Performs(TextBoxPageSteps.FillInPermanentAddress, "permanent address")
			.Performs(TextBoxPageSteps.ClickOnSubmitButton);
	}
}
