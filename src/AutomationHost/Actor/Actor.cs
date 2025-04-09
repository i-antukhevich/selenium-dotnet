using AutomationHost.Utils.Validators;
using OpenQA.Selenium;
using Serilog;
using Serilog.Debugging;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace AutomationHost.Actor;

public class Actor (ActorInformation information) : IDisposable
{
	private IWebDriver? _driver;
	private ILogger? _logger;
	
    public ActorInformation Information { get; } = information;

    public ILogger Log
    {
	    get => _logger ?? throw new LoggingFailedException($"The Actor {Information.Username} is not capable to log information");
	    set => _logger = value;
    }
    
    public IWebDriver Driver 
    {
	    get => _driver ?? throw new NoSuchDriverException($"The Actor {Information.Username} is not capable to interact with browser");
	    set => _driver = value;
    }

    public Actor Performs(Delegate command, params object[] args)
    {
	    Log.Information($"Actor {Information.Username} executes [{command.Method.Name}] step with parameters: {JsonConvert.SerializeObject(args)}");
        Validate.CommandArgsAndReturn(command, new object[] { Driver }.Concat(args).ToArray(), Log);
        return this;
    }

    public object? AsksFor(Delegate command, params object[] args)
    {
	    Log.Information($"Actor {Information.Username} executes [{command.Method.Name}] step with parameters: {JsonConvert.SerializeObject(args)}");
        return Validate.CommandArgsAndReturn(command, new object[] { Driver }.Concat(args).ToArray(), Log);
    }

    public T AsksFor<T>(Delegate command, params object[] args)
    {
        var value = AsksFor(command, args);

        try
        {
            return value is not null
                ? (T)value
                : throw new NullReferenceException($"Returned object is NULL and cannot be casted to type {typeof(T)}");
        }
        catch (InvalidCastException)
        {
            throw new InvalidCastException($"It is impossible to cast object {JsonConvert.SerializeObject(value)} to type {typeof(T)}");
        }
    }

    public void Dispose()
    {
        (_logger as IDisposable)?.Dispose();
        _driver?.Quit();
    }
}
