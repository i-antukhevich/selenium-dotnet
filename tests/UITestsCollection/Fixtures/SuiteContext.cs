namespace UITestsCollection.Fixtures;

public abstract class SuiteContext : IDisposable
{
    protected SuiteContext()
    {
        
    }
    
    public virtual void Dispose()
    {
        // TODO release managed resources here
    }
}