using Demoqa.Commands.Steps;

namespace Demoqa.UICollection.Smoke;

public partial class SmokeSuite
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
