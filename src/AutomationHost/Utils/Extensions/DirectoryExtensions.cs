namespace AutomationHost.Utils.Extensions;

public static class DirectoryExtensions
{
	public static string GetDirectoryPathAndCreateIfRequired(params string[] path)
	{
		return Directory.CreateDirectory(Path.Combine(path)).ToString();
	}
}
