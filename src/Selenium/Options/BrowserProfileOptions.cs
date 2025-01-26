namespace Selenium.Options;

public class BrowserProfileOptions
{
    public required string Name { get; set; }
    
    public required IList<string> Arguments { get; set; }
}