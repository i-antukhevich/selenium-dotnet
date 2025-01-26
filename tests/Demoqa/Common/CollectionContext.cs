using AutomationHost;
using AutomationHost.Actor;
using AutomationHost.Logging;
using AutomationHost.Reporting;
using AventStack.ExtentReports;
using Microsoft.Extensions.DependencyInjection;

namespace Demoqa.Common;

public abstract class CollectionContext : IDisposable
{
	private const string ReportName = "Demoqa";
	public readonly LogManager LogManager;
	private readonly ReportManager _reportManager;
	private ExtentTest? _collection;
	private ExtentTest? _suite;
	
	public Actor Actor { get; }

	protected CollectionContext(AutomationContext context, string actor)
	{
		Actor = context.StartActor(actor);
		LogManager = context.Services.GetRequiredService<LogManager>();
		_reportManager = context.Services.GetRequiredService<ReportManager>();

		context.ReportName = ReportName;
	}

	public ExtentTest GetCurrentExtentTest(ITestContext testContext)
	{
		var collection = testContext.TestCollection?.TestCollectionDisplayName!;
		var suite = testContext.Test?.TestCase.TestClassSimpleName!;
		var test = testContext.Test?.TestCase.TestCaseDisplayName!;

		_collection ??= _reportManager.CreateCollection(collection);

		_suite = _suite == null!
				? _collection.CreateNode(suite)
				: _suite.Test.Name == suite
					? _suite
					: _collection.CreateNode(suite);

		return _suite.CreateNode(test);
	}
	
	public void Dispose()
	{
		Actor.Dispose();
	} 
}
