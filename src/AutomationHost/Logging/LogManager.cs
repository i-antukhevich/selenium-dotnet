using AutomationHost.Logging.Sinks;
using AventStack.ExtentReports;
using Microsoft.Extensions.Configuration;
using Serilog;
using Xunit;


namespace AutomationHost.Logging;

public class LogManager(IConfiguration configuration)
{
	public ILogger CreateLogger(ExtentTest test, ITestOutputHelper? output = null)
	{
		return output is null
			? new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger()
			: new LoggerConfiguration().ReadFrom.Configuration(configuration)
				.WriteTo.ExtentReportSink(test, "{Message}{NewLine}{Exception}")
				.WriteTo.XUnitSink(output, "{Timestamp:HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
				.CreateLogger();
	}
}
