using AventStack.ExtentReports;
using Serilog;
using Serilog.Configuration;
using Xunit;

namespace AutomationHost.Logging.Sinks;

public static class Extensions
{
	public static LoggerConfiguration XUnitSink
		(this LoggerSinkConfiguration loggerConfiguration, ITestOutputHelper output, string template, IFormatProvider formatProvider = null!)
	{
		return loggerConfiguration.Sink(new XunitSink(output, template, formatProvider));
	}

	public static LoggerConfiguration ExtentReportSink
	(this LoggerSinkConfiguration loggerConfiguration, ExtentTest test, string template, IFormatProvider formatProvider = null!)
	{
		return loggerConfiguration.Sink(new ExtentSink(test, template, formatProvider));
	}
}
