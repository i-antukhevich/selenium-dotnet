using AutomationHost;
using AutomationHost.Actors;

namespace UITestsCollection.Fixtures;

public abstract class CollectionContext : IDisposable
{
    public Actor Actor { get; protected set; }
    
    protected CollectionContext()
    {
        Actor = new ActorBuilder("Automation Bot")
            .WithInformation(AutomationContext.GetActorInformation("agent"))
            .Build();
    }
    
    public virtual void Dispose()
    {
        Actor.Dispose();
    }
}