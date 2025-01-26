using AutomationHost.Actors;
using Microsoft.Extensions.Configuration;

namespace AutomationHost;

public static class AutomationContext
{
    public static readonly string BuildEnvironment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "local";

    public static readonly IConfiguration AppConfiguration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("application.json", true, true)
            .AddJsonFile("application.env.json", true, true)
            .AddEnvironmentVariables()
            .Build();
    
    public static readonly IConfiguration BrowserConfiguration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("browser.json", true, true)
            .AddEnvironmentVariables()
            .Build();

    public static ActorInformation GetActorInformation(string actor) => new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile($"./Actors/{actor}.actor.json", true, true)
            .Build().Get<ActorInformation>()!;

    public static IConfiguration GetPageDefinition(string page) => new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile($"./Pages/{page}.page.json", true, true)
            .Build();
}