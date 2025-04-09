using OpenQA.Selenium;

namespace Demoqa.Pages;

public static class TextBoxPage
{
	public static readonly By Header = By.CssSelector("h1.text-center");

	public static class TextFieldContainer
	{
		public static readonly By SubmitButton = By.CssSelector("#submit");
		
		public static class Fullname
		{
			public static readonly By Label = By.CssSelector("#userName-label");
			public static readonly By Input = By.CssSelector("#userName");
		}
		
		public static class Email
		{
			public static readonly By Label = By.CssSelector("#userEmail-label");
			public static readonly By Input = By.CssSelector("#userEmail");
		}

		public static class CurrentAddress
		{
			public static readonly By Label = By.CssSelector("#currentAddress-label");
			public static readonly By Input = By.CssSelector("#currentAddress");
		}

		public static class PermanentAddress
		{
			public static readonly By Label = By.CssSelector("#permanentAddress-label");
			public static readonly By Input = By.CssSelector("#permanentAddress");
		}
	}

	public static class OutputContainer
	{
		public static readonly By Name = By.CssSelector("p#name");
		public static readonly By Email = By.CssSelector("p#email");
		public static readonly By CurrentAddress = By.CssSelector("p#currentAddress");
		public static readonly By PermanentAddress = By.CssSelector("p#permanentAddress");
	}
}
