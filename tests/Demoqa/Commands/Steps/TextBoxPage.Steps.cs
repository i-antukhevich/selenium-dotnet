using Demoqa.Pages;
using OpenQA.Selenium;
using Selenium.Assertions;
using Selenium.Extensions;
using Serilog;

namespace Demoqa.Commands.Steps;

public static class TextBoxPageSteps
{
	public static void NavigateToTextBoxPage(IWebDriver page)
	{
		page.Url = "https://demoqa.com/text-box";
		page.WaitUntilPageIsLoaded();
	}

	public static void FillInFullname(IWebDriver page, string value, ILogger log)
	{
		page
			.WaitForElement(TextBoxPage.TextFieldContainer.Fullname.Input, ToBe.Enabled)
			.SendKeys(value);

		page.ExpectTheElement(TextBoxPage.TextFieldContainer.Fullname.Input, ToHave.EquivalentText, value);
	}
	
	public static void FillInEmail(IWebDriver page, string value)
	{
		page
			.WaitForElement(TextBoxPage.TextFieldContainer.Email.Input, ToBe.Enabled)
			.SendKeys(value);

		page.ExpectTheElement(TextBoxPage.TextFieldContainer.Email.Input, ToHave.EquivalentText, value);
	}
	
	public static void FillInCurrentAddress(IWebDriver page, string value)
	{
		page
			.WaitForElement(TextBoxPage.TextFieldContainer.CurrentAddress.Input, ToBe.Enabled)
			.SendKeys(value);

		page.ExpectTheElement(TextBoxPage.TextFieldContainer.CurrentAddress.Input, ToHave.EquivalentText, value);
	}
	
	public static void FillInPermanentAddress(IWebDriver page, string value)
	{
		page
			.WaitForElement(TextBoxPage.TextFieldContainer.PermanentAddress.Input, ToBe.Enabled)
			.SendKeys(value);

		page.ExpectTheElement(TextBoxPage.TextFieldContainer.PermanentAddress.Input, ToHave.EquivalentText, value);
	}
	
	public static void ClickOnSubmitButton(IWebDriver page)
	{
		page
			.WaitForElement(TextBoxPage.TextFieldContainer.SubmitButton, ToBe.Enabled)
			.Click();
		
		page.WaitForElement(TextBoxPage.OutputContainer.Name, ToBe.Displayed);
		page.WaitForElement(TextBoxPage.OutputContainer.Email, ToBe.Displayed);
		page.WaitForElement(TextBoxPage.OutputContainer.CurrentAddress, ToBe.Displayed);
		page.WaitForElement(TextBoxPage.OutputContainer.PermanentAddress, ToBe.Displayed);
	}
}
