using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;
using Xunit;

namespace AutomationHost.Logging.Sinks;

public class XunitSink(ITestOutputHelper output, string template, IFormatProvider formatProvider) : ILogEventSink
{
	private readonly MessageTemplateTextFormatter _render = new (template, formatProvider);
	
	public void Emit(LogEvent logEvent)
	{
		using var writer = new StringWriter();
		_render.Format(logEvent, writer);
		output.WriteLine(writer.ToString());
	}
}
