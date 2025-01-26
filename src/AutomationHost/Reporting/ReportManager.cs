using AutomationHost.Utils.Extensions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace AutomationHost.Reporting;

public class ReportManager
{
	private readonly ExtentReports _report = new();

	public ExtentTest CreateCollection(string collectionName)
	{
		lock (_report)
		{
			return _report.CreateTest(collectionName);
		}
	}
	
	public void FlushReport(string reportName, string environment = "local")
	{
		var reportsDirectory = DirectoryExtensions
			.GetDirectoryPathAndCreateIfRequired(Directory.GetCurrentDirectory(), "reports");

		lock (_report)
		{
			_report.AddSystemInfo("Report Name", reportName);
			_report.AddSystemInfo("Environment", environment);
			_report.AddSystemInfo("Tester", "Automation");

			_report.AttachReporter(new ExtentSparkReporter(Path.Combine(reportsDirectory, $"{reportName}.html"))
			{
				Config = new ExtentSparkReporterConfig
				{
					ReportName = reportName,
					Theme = Theme.Dark,
					DocumentTitle = reportName,
					OfflineMode = true
				}
			});
		
			_report.Flush();
		}
	}
}
