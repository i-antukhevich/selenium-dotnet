namespace Selenium.Options;

public class BrowserOptions
{
    public required string Profile { get; set; }
    
    public required IList<BrowserProfileOptions> Profiles { get; set; }
    
    public required TimeoutOptions Timeouts { get; set; }
}