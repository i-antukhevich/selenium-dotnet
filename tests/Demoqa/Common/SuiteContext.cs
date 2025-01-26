using AutomationHost.Actor;
using AutomationHost.Utils.Extensions;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace Demoqa.Common;

public abstract class SuiteContext : IDisposable
{
	public ExtentTest Test { get; }

	protected Actor Actor { get; }
	
	protected SuiteContext(CollectionContext collection, ITestOutputHelper output)
	{
		Actor = collection.Actor;
		Test = collection.GetCurrentExtentTest(TestContext.Current);
		Actor.Log = collection.LogManager.CreateLogger(Test, output);
	}
	
	public void Dispose()
	{
		string screenshotsPath = DirectoryExtensions.GetDirectoryPathAndCreateIfRequired(
			Path.Combine(Directory.GetCurrentDirectory(), "screenshots"));

		string screenshot = Path.Combine(screenshotsPath,
			$"{TestContext.Current.TestCollection?.TestCollectionDisplayName}." +
			$"{TestContext.Current.TestClass?.TestClassSimpleName}." +
			$"{TestContext.Current.TestCase?.TestCaseDisplayName}.png");

		try
		{
			(Actor.Driver as ITakesScreenshot)?.GetScreenshot().SaveAsFile(screenshot);
			Thread.Sleep(3000);
			Test.AddScreenCaptureFromPath(screenshot);
		}
		catch
		{
			Actor.Log.Warning("No screenshot provided");
		}
		
		Actor.Log = null!;
	}
}
