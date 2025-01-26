using AventStack.ExtentReports;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;

namespace AutomationHost.Logging.Sinks;

public class ExtentSink(ExtentTest test, string template, IFormatProvider formatProvider) : ILogEventSink
{
	private readonly MessageTemplateTextFormatter _render = new (template, formatProvider);
	
	public void Emit(LogEvent logEvent)
	{
		var logLevel = logEvent.Level.ToString();

		using var message = new StringWriter();
		_render.Format(logEvent, message);

		test.Log(logLevel switch
		{
			"Information" => Status.Info,
			"Warning" => Status.Warning,
			"Error" => Status.Error,
			"Fatal" => Status.Fail,
			"Debug" => Status.Skip,
			_ => Status.Info
		}, message.ToString());
	}
}
