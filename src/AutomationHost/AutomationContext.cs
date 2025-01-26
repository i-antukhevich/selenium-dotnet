using AutomationHost.Actor;
using AutomationHost.Logging;
using AutomationHost.Reporting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Selenium;

namespace AutomationHost;

public class AutomationContext : IDisposable
{
	public string ReportName { get; set; } = "common";
    public static readonly string BuildEnvironment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "local";
    
    private readonly ServiceProvider _services = new ServiceCollection()
        .AddSingleton<IConfiguration>(_ => new ConfigurationBuilder()
            .AddJsonFile("application.json")
            .AddJsonFile("application.env.json")
            .AddJsonFile("browser.json")
            .AddEnvironmentVariables()
            .Build()
        )
        .AddScoped<LogManager>(sp => new LogManager(sp.GetRequiredService<IConfiguration>()))
        .AddSingleton<ReportManager>()
        .AddSeleniumAbility()
        .BuildServiceProvider();

    public ServiceProvider Services => _services;

    public Actor.Actor StartActor(string username)
    {
        var actorInfo = new ConfigurationBuilder().AddJsonFile($"./Actors/{username}.actor.json").Build()
            .GetRequiredSection("Actor").Get<ActorInformation>()!;
        
        return new Actor.Actor(actorInfo);
    }

    public void Dispose()
    {
	    _services.GetRequiredService<ReportManager>().FlushReport(ReportName, BuildEnvironment);
	    _services.Dispose();
    }
}
